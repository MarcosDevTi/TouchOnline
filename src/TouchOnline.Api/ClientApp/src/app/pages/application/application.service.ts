import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ResultDto } from '../lessons/lesson.service';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Keyboard } from './application/keyboard/leyboard';


@Injectable()
export class ApplicationService {
  baseUrl = environment.apiUrl;
  apiKeyboard = environment.apiKeyboard;
  constructor(private http: HttpClient) { }

  setResult(result: any): Observable<ResultDto> {
    return this.http.post(this.baseUrl + '/result', result).pipe(
      catchError(this.handleError),
      map(this.jsonDataToCategory)
    );
  }

  private jsonDataToCategory(jsonData: any): ResultDto {
    return jsonData as ResultDto;
  }

  private handleError(error: any): Observable<any> {
    console.log('Erro na reguisição => ', error);
    return throwError(error);
  }

  getKeyboardsDw(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiKeyboard}GetKeyboardsDw`);
  }

  getKeyboard(keyboardId): Observable<Keyboard> {
    const url = `${this.apiKeyboard}GetKeyboard?keyboardId=${keyboardId}`;
    console.log('url', url);
    return this.http.get<Keyboard>(url);
  }
}
