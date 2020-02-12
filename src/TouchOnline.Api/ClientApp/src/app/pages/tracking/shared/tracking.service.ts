import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RecordedTracking } from './recorded-tracking';
import { VisitorService } from '../../../shared/visitor.service';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { PageVisited } from './pageVisited';

@Injectable({
  providedIn: 'root'
})
export class TrackingService {
  baseUrl = environment.apiTracking;
  visitedList: PageVisited[] = [];
  startDate = new Date();

  constructor(private http: HttpClient, private visitorService: VisitorService) { }

  setvisitedPages(page: string) {
    const objIndex = this.visitedList.findIndex((obj => obj.name === page));
    if (objIndex === -1) {
      this.visitedList.push({ name: page, count: 1 });
    } else {
      this.visitedList[objIndex].count++;
    }

    console.log('list pages', this.visitedList);
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
    const recTracking = new RecordedTracking();
    recTracking.visitedPages = JSON.stringify(this.visitedList);
    recTracking.startDate = this.startDate;
    recTracking.endDate = new Date();
    recTracking.userId = idStorage === "undefined" ? null: idStorage;
    this.visitorService.getIp().subscribe(_ => {
      recTracking.ip = _.ip;
      this.saveResult(recTracking);
    });

    this.reinitializerVisitedPages();
  }

  saveResult(recordedTracking: RecordedTracking) {

    this.http.post(this.baseUrl + 'SaveTracking', recordedTracking).pipe(
      catchError(this.handleError),
      map(_ => _)
    ).subscribe(_ => console.log('saved', _));
  }

  private handleError(error: any): Observable<any> {
    return throwError(error);
  }
}
