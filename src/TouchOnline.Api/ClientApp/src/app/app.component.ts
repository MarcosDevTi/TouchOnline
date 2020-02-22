import { Component, OnInit, OnDestroy, HostListener } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { TrackingService } from './pages/tracking/shared/tracking.service';
import { ApplicationService } from './pages/application/application.service';
import { VisitorService } from './shared/visitor.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DmApp';
  constructor(
    private trackingService: TrackingService,
    private applicationService: ApplicationService,
    private visitorService: VisitorService
  ) {

  }
  subscription: Subscription;

  ngOnInit(): void {
    this.startup();
    const source = interval(20000);
    this.subscription = source.subscribe(val => {
      this.send();
    });

    window.addEventListener('onunload', (e) => {
      this.send();
    });
  }

  startup() {
    this.getLocation();
    this.applicationService.getKeyboardDefault().subscribe(_ => {
      if (_) {
        if (!this.containsLocal('kb')) {
          localStorage.setItem('kb', JSON.stringify(_.data));
        }
        if (!this.containsLocal('bkId')) {
          localStorage.setItem('bkId', _.id)
        }
        if (!this.containsLocal('keyCodes')) {
          localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
        }
      }
    });
  }

  getLocation() {
    if (!this.containsLocal('kb') || !this.containsLocal('bkId') || !this.containsLocal('keyCodes')) {
      this.visitorService.getIp().subscribe(x => {
        if (x.ip) {
          this.visitorService.getLocationWithIp(x.ip).subscribe((_: Location) => {
            this.applicationService.getKeyboardWithLanguageCode('fr-CA').subscribe(k => console.log('keyboard', k))
          })
        }
      }
      )
    }
  }

  send() {
    if (this.trackingService.containsVisitedPages()) {
      this.trackingService.sendTrackingResult();
    }
  }

  containsLocal(key: string): boolean {
    return !!localStorage.getItem(key);
  }
}
