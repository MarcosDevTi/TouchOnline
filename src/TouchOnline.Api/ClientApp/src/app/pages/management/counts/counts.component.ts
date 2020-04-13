import { Component, OnInit, OnDestroy } from '@angular/core';
import { ManagementService } from '../shared/management.service';
import { Counts } from 'src/app/core/navbar/counts';

import { interval } from 'rxjs';
import { TrackingService } from '../trackings/shared/tracking.service';
import { Visitor } from '../trackings/shared/visitor';

@Component({
  selector: 'app-counts',
  templateUrl: './counts.component.html',
  styleUrls: ['./counts.component.css']
})
export class CountsComponent implements OnInit, OnDestroy {
  counts: Counts
  trackingItems: Visitor[] = [];
  displayedColumns: string[] = 
  ['email', 'city', 'country', 'region', 'languageSystem', 'languageBrowser', 'keyboardName', 
  'pagesCount', 'resultCount', 'dateCreateUser', 'firstLessonDate', 'lastLessonDate', 'countResultsForUser'];
  sub;
  constructor(
    private managementService: ManagementService,
    private trackingService: TrackingService) { }
  ngOnInit() {
    this.sub = interval(2000)
      .subscribe((val) =>
      {
        this.trackingService.getTrackingsLastMinute().subscribe(trackings => {
          this.trackingItems = trackings
        } );
        this.managementService.GetCounts().subscribe(_ => this.counts = _)
      }
        
      );

  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}