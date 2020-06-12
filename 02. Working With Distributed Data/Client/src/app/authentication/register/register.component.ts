import { Component, OnInit } from '@angular/core';
import { RegisterModelForm } from './register.model';
import { LoginService } from '../login/login.service';
import { FormGroup, FormBuilder } from 'ngx-strongly-typed-forms';
import { Validators } from '@angular/forms';
import { RegisterService } from './register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  loginForm: FormGroup<RegisterModelForm>;
  constructor(private fb: FormBuilder, private registerService: RegisterService, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group<RegisterModelForm>({
      email: ['', Validators.required],
      password: ['', Validators.required],
      name: ['', Validators.required],
      phoneNumber: ['', Validators.required]
    })
  }

  login() {
    this.registerService.register(this.loginForm.value).subscribe(res => {
      this.router.navigate(['auth']);
    })
  }

}
