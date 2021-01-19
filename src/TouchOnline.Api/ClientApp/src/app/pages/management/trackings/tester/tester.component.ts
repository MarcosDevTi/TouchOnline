import { Component, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { TrackingService } from '../shared/tracking.service';

@Component({
  selector: 'app-tester',
  templateUrl: './tester.component.html',
  styleUrls: ['./tester.component.css']
})
export class TesterComponent implements OnInit {
  showPage = true;
  constructor(
    private trackingService: TrackingService,
  ) { }

  ngOnInit() {
    interval(2000)
      .subscribe((val) => {
        this.trackingService.getTester().subscribe(
          result => {
            console.log('blz', result);
            this.showPage = true;
          },
          error => {
            console.log('error', error);
            this.showPage = false;
          }
        );
      }
      );
  }

}
