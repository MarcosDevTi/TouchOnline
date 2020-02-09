import { Component, OnInit } from '@angular/core';
import { LessonItem } from '../models/lesson-item.model';
import { LessonService } from '../lesson.service';

@Component({
  selector: 'app-basic-list',
  templateUrl: './basic-list.component.html',
  styleUrls: ['./basic-list.component.css', './../shared/list.component.css']
})
export class BasicListComponent implements OnInit {
  basics: LessonItem[];
  constructor(private lessonService: LessonService) { }

  ngOnInit() {
    this.readBasics();
  }
  readBasics(): void {
    this.lessonService.getLessons('basics').subscribe((lessons: LessonItem[]) => {
      this.basics = lessons;
    },
    error => console.log(error));
  }
}
