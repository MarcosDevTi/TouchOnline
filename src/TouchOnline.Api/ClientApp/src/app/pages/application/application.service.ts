import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ResultDto } from '../lessons/lesson.service';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';


@Injectable()
export class ApplicationService {
    baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }

setResult(result: any): Observable<ResultDto> {
   return this.http.post(this.baseUrl + '/result', result).pipe(
        catchError(this.handleError),
      map(this.jsonDataToCategory)
    )
}

private jsonDataToCategory(jsonData:any): ResultDto{
    return jsonData as ResultDto
  }

  private handleError(error: any): Observable<any> {
    console.log('Erro na reguisição => ', error);
    return throwError(error)
  }
}
