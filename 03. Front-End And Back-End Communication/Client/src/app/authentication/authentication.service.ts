import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  registerPath: string = environment.identityApiUrl + "identity/register"
  loginPath: string = environment.identityApiUrl + "identity/login";
  createDealerPath: string = environment.dealersApiUrl + "dealers"
  dealerIdPath: string = environment.dealersApiUrl + "dealers/id";

  constructor(private http: HttpClient) { }

  register(payload): Observable<any> {
      return this.http.post(this.registerPath, payload);
  }

  createDealer(payload) : Observable<any> {
      return this.http.post(this.createDealerPath, payload);
  }

  login(payload) : Observable<any> {
      return this.http.post(this.loginPath, payload);
  }

  getDealerId() : Observable<any> {
      return this.http.get(this.dealerIdPath);
  }

  setToken(token) {
    localStorage.setItem('token', token);
  }

  setId(dealerId) {
    localStorage.setItem('dealerId', dealerId);
  }
}
