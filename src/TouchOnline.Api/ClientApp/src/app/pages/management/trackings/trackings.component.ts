import { Component, OnInit } from '@angular/core';
import { TrackingService } from './shared/tracking.service';
import { TrackingItem } from './shared/trackingItem';
import { VisitorService } from 'src/app/shared/visitor.service';
import { MatDialog } from '@angular/material';
import { TrackingDetailsComponent } from './tracking-details/tracking-details.component';

@Component({
  selector: 'app-trackings',
  templateUrl: './trackings.component.html',
  styleUrls: ['./trackings.component.css']
})
export class TrackingsComponent implements OnInit {
  trackingItems: any[] = [];
  displayedColumns: string[] = ['ip', 'userId', 'countResult', 'listPages', 'appPages', 'endDate', 'startDate', 'actions'];

  constructor(
    private trackingService: TrackingService,
    public dialog: MatDialog,
    ) { }

  ngOnInit() {
    this.trackingService.getTrackings().subscribe(trackings => {
      this.trackingItems = trackings
    } )
  }

  onlyWithResults() {
    this.trackingService.getTrackings().subscribe(trackings => {
      this.trackingItems = trackings.filter(_ => this.containsResult(_.visitedPages) !== 0)
    } )
  }

  allList() {
    this.trackingService.getTrackings().subscribe(trackings => {
      this.trackingItems = trackings
    } )
  }

  clear() {
    this.trackingItems = [];
  }

  containsResult(txt: string) {
    const txtArr = txt.split('"');
    return txtArr.filter(_ => _ === 'result').length;
  }

  containsListPages(txt: string) {
    const txtArr = txt.split('"');
    return txtArr.filter(_ => _.includes('list')).length;
  }

  containsApp(txt: string) {
    const txtArr = txt.split('"');
    return txtArr.filter(_ => _ === 'app').length;
  }

  openDialog(trackingItem): void { 
    console.log(trackingItem);
    const dialogRef = this.dialog.open(TrackingDetailsComponent, {
      data: this.trackingItems.filter(_ => _.ip === trackingItem.ip)[0]
    });


    dialogRef.afterClosed().subscribe(result => {
     
    });
  }

}


