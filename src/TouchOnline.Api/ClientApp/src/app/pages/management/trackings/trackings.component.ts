import { Component, OnInit } from '@angular/core';
import { TrackingService } from './shared/tracking.service';
import { TrackingItem } from './shared/trackingItem';
import { VisitorService } from 'src/app/shared/visitor.service';
import { MatDialog } from '@angular/material';
import { TrackingDetailsComponent } from './tracking-details/tracking-details.component';
import { Visitor } from './shared/visitor';
import { ManagementService } from '../shared/management.service';
import { Counts } from './../../../core/navbar/counts';

@Component({
  selector: 'app-trackings',
  templateUrl: './trackings.component.html',
  styleUrls: ['./trackings.component.css']
})
export class TrackingsComponent implements OnInit {
  counts: Counts;
  trackingItems: Visitor[] = [];
  displayedColumns: string[] = 
  ['email', 'city', 'country', 'region', 'languageSystem', 'languageBrowser', 'keyboardName', 
  'pagesCount', 'resultCount', 'dateCreateUser', 'firstLessonDate', 'lastLessonDate'];

  constructor(
    private trackingService: TrackingService,
    private managementService: ManagementService,
    public dialog: MatDialog,
    ) { }

  ngOnInit() {
    this.trackingService.getTrackings().subscribe(trackings => {
      this.trackingItems = trackings
    } );
    this.managementService.GetCounts().subscribe(_ => this.counts = _)
  }

}


