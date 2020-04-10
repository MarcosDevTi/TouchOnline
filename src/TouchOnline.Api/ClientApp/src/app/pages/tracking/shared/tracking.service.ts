import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RecordedTracking } from './recorded-tracking';
import { VisitorService } from '../../../shared/visitor.service';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { PageVisited } from './pageVisited';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { UserInformations } from 'src/app/shared/user-informations';

@Injectable({
  providedIn: 'root'
})
export class TrackingService {
  baseUrl = environment.apiTracking;
  visitedList: PageVisited[] = [];
  
  startDate = this.getUtc();

  getUtc(){
    const now = new Date;
  const utc_timestamp = Date.UTC(now.getUTCFullYear(), now.getUTCMonth(), now.getUTCDate(),
    now.getUTCHours(), now.getUTCMinutes(), now.getUTCSeconds(), now.getUTCMilliseconds());
    return new Date(utc_timestamp);
  }

  constructor(private http: HttpClient, private visitorService: VisitorService,
    public translate: TranslateService,
    private router: Router,
    private route: ActivatedRoute) { }

  setvisitedPages(page: string) {
    const objIndex = this.visitedList.findIndex((obj => obj.name === page));
    if (objIndex === -1) {
      this.visitedList.push({ name: page, count: 1 });
    } else {
      this.visitedList[objIndex].count++;
    }
  }

  containsVisitedPages(): boolean {
    return this.visitedList.length > 0;
  }

  reinitializerVisitedPages() {
    this.startDate = new Date();
    this.visitedList = [];
  }

  sendTrackingResult() {
    const idStorage = localStorage.getItem('userId');
    const userInfo: UserInformations = JSON.parse(localStorage.getItem('userInfo'));
    const keyboardId = localStorage.getItem('bkId');
    const lang = localStorage.getItem('lang');

    const recTracking = new RecordedTracking();
    recTracking.visitedPages = JSON.stringify(this.visitedList);
    recTracking.startDate = this.startDate;
    recTracking.endDate = this.getUtc();
    recTracking.userId = idStorage === 'undefined' ? null : idStorage;
    recTracking.country = userInfo.country;
    recTracking.region = userInfo.region;
    recTracking.city = userInfo.city;
    recTracking.languageSystem = lang;
    recTracking.languageBrowser = navigator.language;
    recTracking.keyboradId = keyboardId;
    this.visitorService.getIp().subscribe(_ => {
      recTracking.ip = _.ip;
      this.saveResult(recTracking);
    });

    this.reinitializerVisitedPages();
  }

  saveResult(recordedTracking: RecordedTracking) {
    console.log('obj sended to save', recordedTracking);
    this.http.post(this.baseUrl + 'SaveTracking', recordedTracking).pipe(
      catchError(this.handleError),
      map(_ => _)
    ).subscribe(_ => console.log('saved', _));
  }

  private handleError(error: any): Observable<any> {
    return throwError(error);
  }
}
