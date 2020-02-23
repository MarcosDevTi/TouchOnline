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
  displayedColumns: string[] = ['ip', 'userId', 'endDate', 'startDate', 'actions'];

  constructor(
    private trackingService: TrackingService,
    private visitorService: VisitorService,
    public dialog: MatDialog,
    ) { }

  ngOnInit() {
    this.trackingService.getTrackings().subscribe(trackings => {
      this.trackingItems = trackings
      // trackings.forEach(_ => 
      //   this.visitorService.getLocationWithIp(_.ip).subscribe(v => console.log(v))
      //   )
    } )
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


