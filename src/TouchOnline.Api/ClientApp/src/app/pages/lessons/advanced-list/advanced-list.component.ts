import { LessonService } from './../lesson.service';
import { Component, OnInit } from '@angular/core';
import { LessonItem } from '../models/lesson-item.model';

@Component({
  selector: 'app-advanced-list',
  templateUrl: './advanced-list.component.html',
  styleUrls: ['./advanced-list.component.css', './../shared/list.component.css']
})
export class AdvancedListComponent implements OnInit {

  advanceds: LessonItem[];
  constructor(private lessonService: LessonService) { }

  ngOnInit() {
    this.readBasics();
  }
  readBasics(): void {
    this.lessonService.getLessons('advanceds').subscribe((lessons: LessonItem[]) => {
      this.advanceds = lessons;
    },
    error => console.log(error));
  }

}


