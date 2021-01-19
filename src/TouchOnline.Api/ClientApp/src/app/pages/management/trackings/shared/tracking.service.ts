import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Tracking } from './tracking';
import { TrackingItem } from './trackingItem';
import { RecordedTracking } from 'src/app/pages/tracking/shared/recorded-tracking';
import { Visitor } from './visitor';
import { VisitorDay } from './visitor-day';

@Injectable({
  providedIn: 'root'
})
export class TrackingService {

  apiTracking = environment.apiTracking;
  constructor(private http: HttpClient) { }

  getTrackings(date: Date): Observable<Visitor[]> {
    const url = this.apiTracking + 'GetTrackings?date=' + date.toDateString();
    return this.http.get<any[]>(url);
  }

  getTrackingsLastMinute(): Observable<Visitor[]> {
    const url = this.apiTracking + 'GetTrackingsLastMinute';
    return this.http.get<any[]>(url);
  }

  getCountsDay(date: Date): Observable<VisitorDay> {
    const url = this.apiTracking + 'GetCountsDay?date=' + date.toDateString();
    return this.http.get<VisitorDay>(url);
  }

  getVisitors(date): Observable<Visitor[]> {
    const url = this.apiTracking + 'getVisitors?day="' + date + '"';
    return this.http.get<any[]>(url);
  }

  getTester(): Observable<any> {
    const url = this.apiTracking + 'tester';
    return this.http.get<any>(url);
  }
}
