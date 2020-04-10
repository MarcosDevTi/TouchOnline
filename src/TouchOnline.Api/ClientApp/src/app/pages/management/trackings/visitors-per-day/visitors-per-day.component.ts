import { Component, OnInit } from '@angular/core';
import { TrackingService } from '../shared/tracking.service';

@Component({
  selector: 'app-visitors-per-day',
  templateUrl: './visitors-per-day.component.html',
  styleUrls: ['./visitors-per-day.component.css']
})
export class VisitorsPerDayComponent implements OnInit {
  visitors: any[] = [];
  displayedColumns: string[] = ['ip', 'userId', 'countResult', 'listPages', 'appPages', 'endDate', 'startDate', 'actions'];
  constructor(private trackingService: TrackingService) { }

  ngOnInit(): void {
  }

}
