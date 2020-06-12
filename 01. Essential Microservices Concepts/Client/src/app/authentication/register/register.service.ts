import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  registerPath: string = environment.apiUrl + "identity/register"
  constructor(private http: HttpClient) { }

  register(payload): Observable<any> {
      return this.http.post(this.registerPath, payload);
  }
}
