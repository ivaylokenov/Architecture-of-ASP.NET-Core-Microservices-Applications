import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService  implements HttpInterceptor {
  constructor(public router: Router, private toastr: ToastrService) {
  }
 
  intercept(req: HttpRequest<any>, next: HttpHandler) {
 
    return next.handle(req).pipe(
      catchError((error) => {
        if (error.error.validationDetails) {
          for(var key in error.error.errors){
            console.log(error.error.errors[key])
            error.error.errors[key].forEach(element => {
              this.toastr.error("Error", element, {
                timeOut: 0,
                extendedTimeOut: 0
              })
            });
  
          }
        }
        else {
        error.error.forEach(element => {
          this.toastr.error("Error", element, {
            timeOut: 0,
            extendedTimeOut: 0
          })
        });
      }
        return throwError(error.error);
      })
    )
  }
}