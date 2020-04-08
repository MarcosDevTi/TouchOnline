import { Injectable } from '@angular/core';
import { stringify } from 'querystring';
import { ListBeginners } from './list-beginners';
import { IfStmt } from '@angular/compiler';
import { CacheService } from 'src/app/shared/cache.service';
import { LessonItem } from '../../models/lesson-item.model';

@Injectable({
  providedIn: 'root'
})
export class BeginnerLessonsService {
  constructor(private cacheService: CacheService) { }

  buildLessonsBeginners(codesLocal) {
    let code: LessonItem[] = [];

    let index = 101;
    code = ListBeginners.getLessons().map(_ => {
      let lesson = new LessonItem();
      lesson.idLesson = index;
      lesson.name = _.name;
      const text = this.getText(_.value, JSON.stringify(codesLocal));
      lesson.text = text + '¶' + text;
      index++;

      return lesson;
    });
    this.cacheService.addBeginners(code)
  }

  getLessons(codesLocal): LessonItem[] {
    let index = 100;
    return ListBeginners.getLessons().map(_ => {
      let lesson = new LessonItem();

      lesson.idLesson = index,
        lesson.name = _.name;
      lesson.text = this.getText(_.value, codesLocal)

      index++;
      return lesson;
    });
  }

  getText(indexes: number[], localCode: string): string {
    let result = '';
    indexes.forEach(_ => result += localCode[_ + 1])
    return result;
  }

  GetLessons() {
    const codesLocal = localStorage.getItem('beginnersCodes');
  }

  getLessonBeginners(id): any {
    let code: any[] = [];
    const codesLocal = localStorage.getItem('beginnersCodes');
    if (codesLocal) {
      console.log(codesLocal);
    }
    let index = 100;
    code = ListBeginners.getLessons().map(_ => {
      const res = {
        idLesson: index,
        name: _.name,
        text: this.getText(_.value, codesLocal),
      }
      index++;
      return res;
    });
    return code.filter(_ => _.idLesson == id)[0];
  }
}
