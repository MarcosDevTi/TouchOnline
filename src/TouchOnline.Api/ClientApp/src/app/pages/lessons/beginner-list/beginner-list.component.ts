import { Component, Injector, OnInit } from '@angular/core';
import { ListComponent } from '../shared/list.component';
import { BeginnerLessonsService } from './shared/beginner-lessons.service';
import { CacheService } from 'src/app/shared/cache.service';
import { LessonService } from '../lesson.service';
import { LessonItem } from '../models/lesson-item.model';

@Component({
  selector: 'app-beginner-list',
  templateUrl: './beginner-list.component.html',
  styleUrls: ['./beginner-list.component.css', './../shared/list.component.css']
})
export class BeginnerListComponent implements OnInit {
  lessons: LessonItem[] = [];
  constructor(public cacheService: CacheService, private beginnerLessonsService: BeginnerLessonsService){
    
  }
  ngOnInit(){
    
    this.read()
  }

  read(): void {
    const localResult = localStorage.getItem('results');
    console.log('localResult', localResult)
    if(localResult){
      this.lessons = [];
      const results = JSON.parse(localResult) as LessonItem[];
      this.cacheService.beginers.forEach(cache => {
        const sameResult = results.filter(_ => _.idLesson === cache.idLesson);
        console.log('res_' + cache.idLesson, sameResult);
        if(sameResult.length > 0){
          cache.precision = sameResult[0].precision;
          cache.ppm = sameResult[0].ppm;
          cache.stars = sameResult[0].stars;
          cache.time = sameResult[0].time;
        }
        this.lessons.push(cache);
      }) 
    } 
    
    }
}
