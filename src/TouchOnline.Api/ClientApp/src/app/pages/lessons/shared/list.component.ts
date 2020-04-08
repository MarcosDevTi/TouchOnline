import { LessonService } from '../lesson.service';
import { LessonItem } from '../models/lesson-item.model';
import { Injector, OnInit } from '@angular/core';
import { TrackingService } from '../../tracking/shared/tracking.service';
import { LessonTextService } from '../../management/lesson-text/shared/lesson-text.service';
import { interval, Subscription } from 'rxjs';

export abstract class ListComponent implements OnInit {
  lessons: LessonItem[];
  subscription: Subscription;

  protected lessonService: LessonService;
  protected lessonTextService: LessonTextService;
  protected trackingService: TrackingService;
  constructor(protected injector: Injector, protected level: number) {
    this.lessonService = injector.get(LessonService);
    this.trackingService = injector.get(TrackingService);
    this.lessonTextService = injector.get(LessonTextService);
  }

  ngOnInit(): void {
    this.init();

    this.trackingService.setvisitedPages('list-' + this.level);

    const source = interval(100);
    this.subscription = source.subscribe(val => {
      this.readBasics();

      if (this.lessons) {
        this.subscription.unsubscribe()
      }
    });
  }

  abstract init(): void;

  readBasics(): void {
    this.lessonService.getLessons(this.level, 0).subscribe((lessons: LessonItem[]) => {
      this.lessonService.getResults().subscribe(rs => {
        if (rs && lessons) {
          rs.forEach(r => {
            const index = lessons.findIndex(l => l.idLesson === r.idLesson);
            if (index !== -1) {
              lessons[index].precision = r.precision;
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
}
