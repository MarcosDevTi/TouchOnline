import { Injectable } from '@angular/core';
import { LessonItem } from '../pages/lessons/models/lesson-item.model';

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
