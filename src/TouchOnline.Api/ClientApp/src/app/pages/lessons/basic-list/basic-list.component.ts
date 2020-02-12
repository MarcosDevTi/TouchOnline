import { Component, OnInit } from '@angular/core';
import { LessonItem } from '../models/lesson-item.model';
import { LessonService } from '../lesson.service';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';

@Component({
  selector: 'app-basic-list',
  templateUrl: './basic-list.component.html',
  styleUrls: ['./basic-list.component.css', './../shared/list.component.css']
})
export class BasicListComponent implements OnInit {
  basics: LessonItem[];
  constructor(private lessonService: LessonService, private trackingService: TrackingService) { }

  ngOnInit() {
    this.trackingService.setvisitedPages('list-basic');
    this.readBasics();
  }
  readBasics(): void {
    this.lessonService.getLessons('basics').subscribe((lessons: LessonItem[]) => {
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
      console.log('full list basics', lessons);
      this.basics = lessons;
    },
    error => console.log(error));
  }
}
