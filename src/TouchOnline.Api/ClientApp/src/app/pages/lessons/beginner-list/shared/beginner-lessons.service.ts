import { Injectable } from '@angular/core';
import { stringify } from 'querystring';
import { ListBeginners } from './list-beginners';
import { IfStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class BeginnerLessonsService {

  buildLessonsBeginners(codesLocal = null) {
    let code: any[] = [];
    if (codesLocal == null) {
      codesLocal = localStorage.getItem('beginnersCodes');
    }
    
    let index = 100;
    code = ListBeginners.getLessons().map(_ => {
    const res = {
      idLesson: index,
      name: _.name,
      lessonText: this.getText(_.value, codesLocal),
    }
    index++;
    return res;
  });
    
  localStorage.setItem('beginners', JSON.stringify(code));
    
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
        lessonText: this.getText(_.value, codesLocal),
      }
      index++;
      return res;
    });
    return code.filter(_ => _.idLesson == id)[0];
  }
}
