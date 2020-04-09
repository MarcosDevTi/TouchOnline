import { Component, OnInit, OnDestroy, HostListener } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { TrackingService } from './pages/tracking/shared/tracking.service';
import { ApplicationService } from './pages/application/application.service';
import { VisitorService } from './shared/visitor.service';
import { TranslateService } from '@ngx-translate/core';
import { KeyServiceService } from './pages/application/application/keyboard/key.service';
import { BeginnerLessonsService } from './pages/lessons/beginner-list/shared/beginner-lessons.service';
import { LocalServiceService } from './shared/local-service.service';
import { CacheService } from './shared/cache.service';
import { ActivatedRoute, Router } from '@angular/router';


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
    private visitorService: VisitorService,
    public translate: TranslateService,
    private localServiceService: LocalServiceService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    translate.addLangs(['en', 'fr', 'pt']);

    // const browserLang = translate.getBrowserLang();
    // translate.use(browserLang.match(/en|fr|pt/) ? browserLang : 'en');
  }
  subscription: Subscription;

  ngOnInit(): void {
    console.log('app local storage',localStorage.getItem('kb'))
    this.localServiceService.startApp();
    
    const source = interval(20000);
    this.subscription = source.subscribe(val => {
      this.send();
    });

    window.addEventListener('onunload', (e) => {
      this.send();
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

  changeLanguage(lang){
    this.router.navigate['']
  }
}
