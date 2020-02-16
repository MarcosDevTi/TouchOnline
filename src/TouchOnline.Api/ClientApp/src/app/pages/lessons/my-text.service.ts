import { Injectable } from '@angular/core';
import { LessonForSave } from './shared/models/lesson-for-save';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MyTextService {
  apiMyText = environment.apiMyText;
  constructor(private http: HttpClient) { }

  save(lessonForSave: LessonForSave): Observable<any> {
    console.log('lessonForSave', lessonForSave)
    return this.http.post(this.apiMyText + 'Save', lessonForSave);
  }
}
