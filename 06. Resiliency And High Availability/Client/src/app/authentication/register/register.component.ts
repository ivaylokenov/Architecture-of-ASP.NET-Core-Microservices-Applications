import { Component, OnInit, resolveForwardRef } from '@angular/core';
import { RegisterModelForm } from './register.model';
import { FormGroup, FormBuilder } from 'ngx-strongly-typed-forms';
import { Validators } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  loginForm: FormGroup<RegisterModelForm>;
  constructor(private fb: FormBuilder, private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group<RegisterModelForm>({
      email: ['', Validators.required],
      password: ['', Validators.required],
      name: ['', Validators.required],
      phoneNumber: ['', Validators.required]
    })
  }

  login() {
    const form = this.loginForm.value;

    const { email, password } = form;
    const userData = { email, password };

    const { name, phoneNumber } = form;
    const dealerData = { name, phoneNumber };

    this.authenticationService.register(userData).subscribe(res => {
      this.authenticationService.setToken(res['token']);

      this.authenticationService.createDealer(dealerData).subscribe(res => {
        this.authenticationService.setId(res);

        this.router.navigate(['']).then(() => {
          window.location.reload();
        });
      })
    })
  }
}
