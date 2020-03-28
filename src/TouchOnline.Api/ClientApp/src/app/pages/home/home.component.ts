import { Component, OnInit } from '@angular/core';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(
    private trackingService: TrackingService, 
    public translate: TranslateService
    ) { }

  ngOnInit() {
    this.trackingService.setvisitedPages('home');
  }

}
