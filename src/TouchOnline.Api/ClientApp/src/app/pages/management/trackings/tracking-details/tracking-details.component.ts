import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { VisitorService } from 'src/app/shared/visitor.service';
import { TrackingDetails } from '../shared/tracking-details';

@Component({
  selector: 'app-tracking-details',
  templateUrl: './tracking-details.component.html',
  styleUrls: ['./tracking-details.component.css']
})
export class TrackingDetailsComponent implements OnInit {
  trackingDetails: TrackingDetails
  constructor(
    public dialogRef: MatDialogRef<TrackingDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private visitorService: VisitorService
  ) { }

  ngOnInit() {
    this.visitorService.getLocationWithIp(this.data[0].ip).subscribe((_: any) => {
      this.trackingDetails = new TrackingDetails();
      this.trackingDetails.country = _.country
      this.trackingDetails.regionName = _.regionName
      this.trackingDetails.city = _.city
      this.trackingDetails.zip = _.zip
      this.trackingDetails.lat = _.lat
      this.trackingDetails.lon = _.lon
      this.trackingDetails.isp = _.isp
      this.trackingDetails.org = _.org
      this.trackingDetails.as = _.as
      this.trackingDetails.mobile = _.mobile

    })
  }

}
