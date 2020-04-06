import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { LessonText } from './lesson-text';
import { LessonItem } from 'src/app/pages/lessons/models/lesson-item.model';

@Injectable({
  providedIn: 'root'
})
export class LessonTextService {
  lessonApi = environment.apiBase + 'LessonText/';
  constructor(private http: HttpClient) { }

  getLessons(level: number, language: number): Observable<LessonItem[]> {
    const url = this.lessonApi + `GetLessonTexts?level=${level}&Language=${language}`;
    return this.http.get<LessonItem[]>(url);
  }

  createLesson(lessonText: LessonText): Observable<any>{
    return this.http.post(this.lessonApi + 'CreateLesson', lessonText);
  }

  delete(id: string){
    return this.http.delete(this.lessonApi + 'DeleteLessonText/' + id);
  }
}
