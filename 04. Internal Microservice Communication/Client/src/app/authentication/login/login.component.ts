import { Component, OnInit, Output, EventEmitter, resolveForwardRef } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormGroup, FormBuilder } from 'ngx-strongly-typed-forms';
import { AuthenticationService } from '../authentication.service';
import { LoginFormModel } from './login.model';
import { ActivatedRoute, Router } from '@angular/router';
import { RouterExtService } from 'src/app/shared/rouer-ext.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup<LoginFormModel>;
  returnUrl: string;
  @Output() emitter: EventEmitter<string> = new EventEmitter<string>();

  constructor(private fb: FormBuilder, private authenticationService: AuthenticationService, private route: ActivatedRoute, private router: Router,private routerService: RouterExtService) { 
    if(localStorage.getItem('token')) {
      this.router.navigate(['cars'])
    }
  }

  ngOnInit(): void {
    localStorage.removeItem('token');
    this.loginForm = this.fb.group<LoginFormModel>({
      email: ['', Validators.required],
      password: ['', Validators.required],
    })
  }

  login() {
    this.authenticationService.login(this.loginForm.value).subscribe(res => {
      this.authenticationService.setToken(res['token']);

      this.authenticationService.getDealerId().subscribe(res => {
        this.authenticationService.setId(res);

        this.router.navigate(['']).then(() => {
          window.location.reload();
        });
      })
    })
  }
}
