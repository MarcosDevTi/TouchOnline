import { LessonService } from "../lesson.service";
import { LessonItem } from "../models/lesson-item.model";
import { Injector, OnInit } from "@angular/core";
import { TrackingService } from "../../tracking/shared/tracking.service";

export abstract class ListService implements OnInit {
    lessons: LessonItem[];
    protected lessonService: LessonService;
    protected trackingService: TrackingService;
    constructor(protected injector: Injector, protected level: string) {
        this.lessonService = injector.get(LessonService);
        this.trackingService = injector.get(TrackingService);
    }

    ngOnInit(): void {
        this.trackingService.setvisitedPages('list-'+ this.level);
        this.init();
        this.readBasics();
    }
    abstract init(): void;

    readBasics(): void {
        this.lessonService.getLessons(this.level).subscribe((lessons: LessonItem[]) => {
          this.lessonService.getResults().subscribe(rs => {
            rs.forEach(r => {
              var index = lessons.findIndex(l => l.idLesson === r.idLesson);
              if(index != -1){
                lessons[index].precision = r.precision;
                lessons[index].ppm = r.ppm;
                lessons[index].stars = r.stars;
                lessons[index].time = r.time;
              }
            })
          });
          this.lessons = lessons;
        },
          error => console.log(error));
      }
}