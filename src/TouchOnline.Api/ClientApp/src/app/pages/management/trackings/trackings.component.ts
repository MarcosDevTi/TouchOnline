import { Component, OnInit } from '@angular/core';
import { TrackingService } from './shared/tracking.service';
import { TrackingItem } from './shared/trackingItem';
import { VisitorService } from 'src/app/shared/visitor.service';

@Component({
  selector: 'app-trackings',
  templateUrl: './trackings.component.html',
  styleUrls: ['./trackings.component.css']
})
export class TrackingsComponent implements OnInit {
  trackingItems: TrackingItem[];

  constructor(
    private trackingService: TrackingService,
    private visitorService: VisitorService
    ) { }

  ngOnInit() {
    this.trackingService.getTrackings().subscribe(trackings => {
      trackings.forEach(_ => this.visitorService.getLocationWithIp(_.ip).subscribe(v =>
        console.log(v)))
    } )
  }

}
