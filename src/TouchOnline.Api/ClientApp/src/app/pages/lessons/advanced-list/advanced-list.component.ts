import { LessonService, ResultDto } from './../lesson.service';
import { Component, OnInit } from '@angular/core';
import { LessonItem } from '../models/lesson-item.model';
import { VisitorService } from 'src/app/shared/visitor.service';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';

@Component({
  selector: 'app-advanced-list',
  templateUrl: './advanced-list.component.html',
  styleUrls: ['./advanced-list.component.css', './../shared/list.component.css']
})
export class AdvancedListComponent implements OnInit {

  advanceds: LessonItem[];

  constructor(
    private lessonService: LessonService,
    private visitorService: VisitorService,
    private trackingService: TrackingService) { }

  ngOnInit() {
    this.trackingService.setvisitedPages('list-advanced');
    this.visitorService.getLocation();
    this.visitorService.getIp();
    this.readBasics();
  }
  readBasics(): void {
    this.lessonService.getLessons('advanceds').subscribe((lessons: LessonItem[]) => {
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
      this.advanceds = lessons;
    },
      error => console.log(error));
  }

  

}


