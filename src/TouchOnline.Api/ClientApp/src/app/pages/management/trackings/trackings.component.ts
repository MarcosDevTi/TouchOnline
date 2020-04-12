import { Component, OnInit } from '@angular/core';
import { TrackingService } from './shared/tracking.service';
import { TrackingItem } from './shared/trackingItem';
import { VisitorService } from 'src/app/shared/visitor.service';
import { MatDialog } from '@angular/material';
import { TrackingDetailsComponent } from './tracking-details/tracking-details.component';
import { Visitor } from './shared/visitor';
import { ManagementService } from '../shared/management.service';
import { Counts } from './../../../core/navbar/counts';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-trackings',
  templateUrl: './trackings.component.html',
  styleUrls: ['./trackings.component.css']
})
export class TrackingsComponent implements OnInit {
  date = new FormControl(new Date());
  counts: Counts;
  trackingItems: Visitor[] = [];
  displayedColumns: string[] = 
  ['email', 'city', 'country', 'region', 'languageSystem', 'languageBrowser', 'keyboardName', 
  'pagesCount', 'resultCount', 'dateCreateUser', 'firstLessonDate', 'lastLessonDate', 'countResultsForUser'];

  constructor(
    private trackingService: TrackingService,
    private managementService: ManagementService,
    public dialog: MatDialog,
    ) { }

  ngOnInit() {
    this.trackingService.getTrackings(new Date()).subscribe(trackings => {
      this.trackingItems = trackings
    } );
    this.managementService.GetCounts().subscribe(_ => this.counts = _)
  }

  changeDate(e){
    console.log('e', e)
    this.trackingService.getTrackings(e.value).subscribe(trackings => {
      this.trackingItems = trackings
    } );
  }

}


