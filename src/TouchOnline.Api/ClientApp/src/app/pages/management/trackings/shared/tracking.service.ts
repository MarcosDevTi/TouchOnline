import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Tracking } from './tracking';

@Injectable({
  providedIn: 'root'
})
export class TrackingService {

  apiTracking = environment.apiTracking;
  constructor(private http: HttpClient) { }

  getTrackings(): Observable<Tracking[]> {
    const url = this.apiTracking + 'GetTrackings';
    return this.http.get<Tracking[]>(url);
  }
}
