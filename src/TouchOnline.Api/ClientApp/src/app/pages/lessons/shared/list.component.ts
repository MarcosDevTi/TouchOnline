import { LessonService } from '../lesson.service';
import { LessonItem } from '../models/lesson-item.model';
import { Injector, OnInit } from '@angular/core';
import { TrackingService } from '../../tracking/shared/tracking.service';
import { LessonTextService } from '../../management/lesson-text/shared/lesson-text.service';
import { interval, Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

export abstract class ListComponent implements OnInit {
  lang: string;
  linkApp: string;
  lessons: LessonItem[];
  subscription: Subscription;

  protected lessonService: LessonService;
  protected lessonTextService: LessonTextService;
  protected trackingService: TrackingService;
  protected route: ActivatedRoute;
  public translate: TranslateService;
  protected router: Router

  constructor(protected injector: Injector, protected level: number) {
    this.lessonService = injector.get(LessonService);
    this.trackingService = injector.get(TrackingService);
    this.lessonTextService = injector.get(LessonTextService);
    this.route = injector.get(ActivatedRoute);
    this.translate = injector.get(TranslateService);
    this.router = injector.get(Router);
  }

  ngOnInit(): void {
    this.init();
    this.initLanguage();
    this.trackingService.setvisitedPages('list-' + this.level);

    const source = interval(100);
    this.subscription = source.subscribe(val => {
      this.readBasics();

      if (this.lessons) {
        this.subscription.unsubscribe()
      }
    });
  }

  initLanguage() {
    let lang = navigator.language.substring(0, 2);

    const langLocal = localStorage.getItem('lang');
    if (langLocal) {
      this.lang = langLocal;
      this.router.navigate(['/' + langLocal + '/lessons/' + this.getlevel()]);
      this.translate.use(langLocal)
      this.linkApp = '/' + langLocal + `/app`;
    } else {
      this.route.params.subscribe(value => {
        if (value['lang'] === undefined) {
          if (!this.translate.getLangs().includes(lang)) {
            lang = 'en';
          }
          this.router.navigate(['/' + lang + '/lessons/' + this.getlevel()]);
        } else {
          lang = value['lang'];
        }
        this.translate.use(lang)
        this.linkApp = '/' + lang + `/app`;
        this.lang = lang;
        localStorage.setItem('lang', lang);
      });
    }

  }

  getlevel() {
    switch (this.level) {
      case 0:
        return "beginner";
      case 1:
        return 'basic';
      case 2:
        return 'intermediate';
      case 3:
        return 'advanced';
      case 4:
        return 'my-text'
      default:
        return 0;
    }
  }

  abstract init(): void;

  getLangEnumCode(): number {
    switch (this.lang) {
      case 'pt':
        return 0;
      case 'en':
        return 1;
      case 'es':
        return 2;
      case 'fr':
        return 3
      default:
        return 1;
    }
  }

  readBasics(): void {
    this.lessonService.getLessons(this.level, this.lang).subscribe((lessons: LessonItem[]) => {
      
      this.lessonService.getResults().subscribe(rs => {
        if (rs && lessons) {
          rs.forEach(r => {
            const index = lessons.findIndex(l => l.idLesson === r.idLesson);
            if (index !== -1) {
              lessons[index].precision = this.calcPercent(r.errors, lessons[index].text);
              lessons[index].ppm = r.ppm;
              lessons[index].stars = r.stars;
              lessons[index].time = r.time;
            }
          });
        }
      });
      this.lessons = lessons;
    },
      error => console.log(error));
  }

  calcPercent(errors: number, text: string): number {
    return 100 - (errors * 100) / text.length;
  }
}
