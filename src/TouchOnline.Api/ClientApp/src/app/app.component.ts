import { Component, OnInit, OnDestroy, HostListener } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { TrackingService } from './pages/tracking/shared/tracking.service';
import { ApplicationService } from './pages/application/application.service';
import { VisitorService } from './shared/visitor.service';
import { TranslateService } from '@ngx-translate/core';
import { KeyServiceService } from './pages/application/application/keyboard/key.service';
import { BeginnerLessonsService } from './pages/lessons/beginner-list/shared/beginner-lessons.service';
import { LocalServiceService } from './shared/local-service.service';


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
    private keyServiceService: KeyServiceService,
    private beginnerLessonsService: BeginnerLessonsService,
    private localServiceService: LocalServiceService
  ) {
    translate.addLangs(['en', 'fr', 'pt']);

    translate.setDefaultLang('en');
    translate.use('pt');
    // const browserLang = translate.getBrowserLang();
    // translate.use(browserLang.match(/en|fr|pt/) ? browserLang : 'en');
  }
  subscription: Subscription;

  ngOnInit(): void {
    this.localServiceService.startApp();
    this.setKeyboard();
    const source = interval(20000);
    this.subscription = source.subscribe(val => {
      this.send();
    });

    window.addEventListener('onunload', (e) => {
      this.send();
    });
  }

  setKeyboard() {
    var kbLocal = localStorage.getItem('kb');
    if (!kbLocal) {
      const idKeyboardEnUs = localStorage.getItem('bkId');
      this.keyServiceService.getKeyboard(idKeyboardEnUs).subscribe(_ => {
        localStorage.setItem('kb', JSON.stringify(_.data));
        localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
        localStorage.setItem('beginnersCodes', JSON.stringify(_.keycodesBeginners));
        this.beginnerLessonsService.buildLessonsBeginners(JSON.stringify(_.keycodesBeginners));
      });
    }
  }

  // startup() {
  //   this.getLocation();
  //   this.applicationService.getKeyboardDefault().subscribe(_ => {
  //     if (_) {
  //       if (!this.containsLocal('kb')) {
  //         localStorage.setItem('kb', JSON.stringify(_.data));
  //       }
  //       if (!this.containsLocal('bkId')) {
  //         localStorage.setItem('bkId', _.id)
  //       }
  //       if (!this.containsLocal('keyCodes')) {
  //         localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
  //       }
  //     }
  //   });
  // }

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
