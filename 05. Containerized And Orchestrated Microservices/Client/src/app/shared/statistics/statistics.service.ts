import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Statistics } from './statistics.model';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {
  carsPath: string = environment.statisticsApiUrl + 'statistics';

  constructor(private http: HttpClient) { }

  getStatistics(): Observable<Statistics> {
    return this.http.get<Statistics>(this.carsPath);
  }
}
