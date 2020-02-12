import { Component, OnInit } from '@angular/core';
import { LessonService } from '../lesson.service';
import { LessonItem } from '../models/lesson-item.model';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';

@Component({
  selector: 'app-intermediate-list',
  templateUrl: './intermediate-list.component.html',
  styleUrls: ['./intermediate-list.component.css', './../shared/list.component.css']
})
export class IntermediateListComponent implements OnInit {

  intermediates: LessonItem[];
  constructor(private lessonService: LessonService, private trackingService: TrackingService) { }

  ngOnInit() {
    this.trackingService.setvisitedPages('list-intermediates');
    this.readBasics();
  }
  readBasics(): void {
    this.lessonService.getLessons('intermediates').subscribe((lessons: LessonItem[]) => {
      this.intermediates = lessons;
    },
    error => console.log(error));
  }

}
