import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Profile } from './profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  dealerPath: string = environment.dealersApiUrl + 'Dealers/'
  constructor(private http: HttpClient) { }

  getDealer(id): Observable<Profile> {
    return this.http.get<Profile>(this.dealerPath + id)
  }

  editDealer(id, payload): Observable<null> {
    return this.http.put<null>(this.dealerPath + id, payload)
  }

  changePassword(payload) {
    return this.http.put(environment.identityApiUrl + 'identity/changePassword', payload);
  }
}
