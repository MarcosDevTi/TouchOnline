import { Component, OnInit } from '@angular/core';
import { TrackingService } from './shared/tracking.service';
import { TrackingItem } from './shared/trackingItem';
import { VisitorService } from 'src/app/shared/visitor.service';
import { MatDialog } from '@angular/material';
import { TrackingDetailsComponent } from './tracking-details/tracking-details.component';
import { Visitor } from './shared/visitor';

@Component({
  selector: 'app-trackings',
  templateUrl: './trackings.component.html',
  styleUrls: ['./trackings.component.css']
})
export class TrackingsComponent implements OnInit {
  trackingItems: Visitor[] = [];
  displayedColumns: string[] = 
  ['email', 'city', 'country', 'region', 'languageSystem', 'languageBrowser', 'keyboardName', 'pagesCount', 'resultCount'];

  constructor(
    private trackingService: TrackingService,
    public dialog: MatDialog,
    ) { }

  ngOnInit() {
    this.trackingService.getTrackings().subscribe(trackings => {
      console.log('kkk', trackings)
      this.trackingItems = trackings
    } )
  }

}


