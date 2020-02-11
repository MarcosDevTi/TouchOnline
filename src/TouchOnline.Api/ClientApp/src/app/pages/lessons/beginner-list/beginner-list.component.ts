import { Component, OnInit } from '@angular/core';
import { LessonItem } from '../models/lesson-item.model';
import { LessonService } from '../lesson.service';
import { TrackingService } from 'src/app/shared/tracking/tracking.service';

@Component({
  selector: 'app-beginner-list',
  templateUrl: './beginner-list.component.html',
  styleUrls: ['./beginner-list.component.css', './../shared/list.component.css']
})
export class BeginnerListComponent implements OnInit {
  beginners: LessonItem[];
  constructor(private lessonService: LessonService, private trackingService: TrackingService) { }

  ngOnInit() {
    this.trackingService.setvisitedPages('list-beginners');
    this.readBeginners();
  }

  readBeginners(): void {
    this.lessonService.getLessons('beginners').subscribe((lessons: LessonItem[]) => {
      this.beginners = lessons;
    },
    error => console.log(error));
  }

}
