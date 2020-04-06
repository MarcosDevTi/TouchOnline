import { Injectable } from '@angular/core';
import { LessonItem } from '../pages/lessons/models/lesson-item.model';
import { BeginnerLessonsService } from '../pages/lessons/beginner-list/shared/beginner-lessons.service';
import { KeyServiceService } from '../pages/application/application/keyboard/key.service';

@Injectable({
  providedIn: 'root'
})
export class CacheService {
  constructor() { }
  beginers: LessonItem[] = [];

  addBeginners(beginers: LessonItem[]) {
    this.beginers = [];
    this.beginers = beginers as LessonItem[];
  }
}
