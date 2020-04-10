import { Component, Injector, OnInit } from '@angular/core';
import { ListComponent } from '../shared/list.component';
import { BeginnerLessonsService } from './shared/beginner-lessons.service';
import { CacheService } from 'src/app/shared/cache.service';
import { LessonService } from '../lesson.service';
import { LessonItem } from '../models/lesson-item.model';
import { TrackingService } from '../../tracking/shared/tracking.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-beginner-list',
  templateUrl: './beginner-list.component.html',
  styleUrls: ['./beginner-list.component.css', './../shared/list.component.css']
})
export class BeginnerListComponent implements OnInit {
  lessons: LessonItem[] = [];
  linkApp: string;
  constructor(
    public cacheService: CacheService,
    protected lessonService: LessonService,
    private trackingService: TrackingService,
    private route: ActivatedRoute,
    public translate: TranslateService,
    private router: Router) {

  }
  ngOnInit() {
    this.initLanguage();
    this.trackingService.setvisitedPages('list-0');
    if (!localStorage.getItem('userId')) {
      this.read();
    } else {
      this.readLogged();
    }

  }

  initLanguage() {
    let lang = navigator.language.substring(0, 2);

    const langLocal = localStorage.getItem('lang');

    if (langLocal) {
      this.router.navigate(['/' + langLocal + '/lessons/beginner']);
      this.translate.use(langLocal)
      this.linkApp = '/' + langLocal + `/app`;
    } else {
      this.route.params.subscribe(value => {
        if (value['lang'] === undefined) {
          if (!this.translate.getLangs().includes(lang)) {
            lang = 'en';
          }
          this.router.navigate(['/' + lang + '/lessons/beginner']);
        } else {
          lang = value['lang'];
        }
        this.translate.use(lang)
        this.linkApp = '/' + lang + `/app`;
      });
      localStorage.setItem('lang', lang);
    }

  }

  readLogged() {

    this.lessons = this.cacheService.beginers;
    this.lessonService.getResults().subscribe((rs: LessonItem[]) => {
      if (rs) {
        rs.forEach(r => {
          const lessonIndex = this.lessons.findIndex(_ => _.idLesson == r.idLesson);
          if (this.lessons[lessonIndex]) {
            this.lessons[lessonIndex].precision = this.calcPercent(r.errors, this.lessons[lessonIndex].text);
            this.lessons[lessonIndex].ppm = r.ppm;
            this.lessons[lessonIndex].stars = r.stars;
            this.lessons[lessonIndex].time = r.time;
          }

        })
      }
    });
  }

  calcPercent(errors: number, text: string): number {
    if (!errors)
      return 100;
    return 100 - (errors * 100) / text.length;
  }

  read(): void {

    const localResult = localStorage.getItem('results');
    if (localResult) {
      this.lessons = [];
      const results = JSON.parse(localResult) as LessonItem[];

      this.cacheService.beginers.forEach(cache => {
        const sameResult = results.filter(_ => _.idLesson === cache.idLesson);
        
        if (sameResult.length > 0) {
          cache.precision = this.calcPercent(sameResult[0].errors, cache.text);
          cache.ppm = sameResult[0].ppm;
          cache.stars = sameResult[0].stars;
          cache.time = sameResult[0].time;
        }
        this.lessons.push(cache);
      })
    } else {
      this.cacheService.beginers
    }

  }
}
