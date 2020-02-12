import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { LessonItem } from './models/lesson-item.model';
import { map, catchError } from 'rxjs/operators';
import { throwError, Observable, of } from 'rxjs';
import { Frase } from './models/frase';
import { environment } from 'src/environments/environment';
import { Key } from './models/key';
import { Resultado } from './models/Resultado';
import { LessonApp } from './models/lesson-app';
import { NgxIndexedDBService } from 'ngx-indexed-db';
import { stringify } from 'querystring';

@Injectable()
export class LessonService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  getLessons(level: string): Observable<LessonItem[]> {
    const lessonsPres = localStorage.getItem(level);
    if (lessonsPres) {
      return of(JSON.parse(lessonsPres));
    }

    return this.http.get(this.baseUrl + `/GetLessonPresentations?level=${level}`).pipe(
      catchError(this.handleError),
      map(response => {
        this.setLessonsLocalStorage(level, response);
        return this.jsonDataToLessons(response);
      })
    );
  }

  getResults(): Observable<LessonItem[]> {
    if (this.getUserId()) {
      //authenticated
      const url = this.baseUrl + '/GetResults?userId=' + this.getUserId();
      return this.http.get(url).pipe(
        catchError(this.handleError),
      );
    } else {
      const results = localStorage.getItem('results');
      return of(JSON.parse(results));
    }

  }

  convertLocalLessons(jsonData): Observable<LessonItem[]> {
    console.log(jsonData)
    return of(this.jsonDataToLessons(jsonData));
  }

  setLessonsLocalStorage(level: string, json) {
    localStorage.setItem(level, JSON.stringify(json));
  }

  getUserId(): string {
    return localStorage.getItem('userId');
  }

  getLesson(idLesson: string) {
    return this.http.get<LessonApp>(this.baseUrl + '/GetLessonPresentation?idLesson=' + idLesson);
  }

  private jsonDataToLessons(jsonData: LessonItem[]): LessonItem[] {
    if (this.getUserId() !== null) {
      const resultsLocal = JSON.parse(localStorage.getItem('results'));
      if (resultsLocal) {
        console.log('have results')
        return jsonData;
      }
    } else {
      // this.getResults().subscribe(_ => console.log(_))

      return jsonData;
      // let lessons: LessonItem[] = [];
      // jsonData.forEach(_ => lessons.push(_));
      // return lessons;
    }
  };





  private handleError(error: any): Observable<any> {
    console.log('Request Error => ', error);
    return throwError(error);
  }

  gravarResultado(resultado: any): Observable<ResultDto> {
    if (resultado.userId != 'undefined') {
      return this.http.post(this.baseUrl + '/SetResult', resultado).pipe(
        catchError(this.handleError),
        map(this.jsonDataToCategory)
      );
    } else {
      const listResult = localStorage.getItem('results');
      if (listResult === null) {

      }
      if (listResult === null) return of(null);
      var listResultDto = Array<ResultDto>(JSON.parse(listResult));
      var index = listResultDto.findIndex(_ =>
        _.idLesson === resultado.idLesson)
      if (index === -1) {

        localStorage.setItem('results-init', '1');
        listResultDto.push(resultado)
      } else {
        listResultDto[index].errors = resultado.errors;
        listResultDto[index].ppm = resultado.ppm;
        listResultDto[index].stars = resultado.stars;
        listResultDto[index].time = resultado.time;

      }
      localStorage.setItem('results', JSON.stringify(listResultDto));
      return of(resultado)
    }

  }

  private jsonDataToCategory(jsonData: any): ResultDto {
    return jsonData as ResultDto;
  }


  createFrase(textFrase: string, ind: number): Frase {
    const fraseReturn: Key[] = [];
    for (let i = 0; i < textFrase.length; i++) {
      fraseReturn.push(new Key(textFrase[i], i));
    }
    return new Frase(fraseReturn, ind);
  }

  generateResult(resultado: Resultado): ResultDto {
    let fatorErro: number;
    let numErros: number =
      resultado.erros.length > 0 ?
        resultado.erros.map(x => x.numOcorrencias).reduce((sum, current) => sum + current) : 0;
    const numRealErrors = numErros;

    let numEstrelas: number;

    if (resultado.category === '1' || resultado.category === '2') {
      numEstrelas = this.calcEstrelas(numErros, resultado.tempo, 5, resultado.textLength);
      fatorErro = resultado.textLength / 20;
    } else {
      numEstrelas = this.calcEstrelas(numErros, resultado.tempo, 3, resultado.textLength);
      fatorErro = resultado.textLength / 40;
    }

    numErros = numErros / Math.round(fatorErro);
    console.log('numErros', numErros);
    console.log('tempo', resultado.tempo);
    console.log('resultado.textLength', resultado.textLength);
    console.log('estrelas', numEstrelas);
    const result: ResultDto = {
      stars: numEstrelas,
      errors: numRealErrors,
      time: resultado.tempo,
      ppm: +resultado.ppm,
      idLesson: resultado.idLesson,
      userId: resultado.userId
    };

    this.gravarResultado(result).subscribe(
      () => console.log('deu certo'),
      error => console.log('deu merda')
    );
    return result;
  }

  calcEstrelas(errors: number, time: number, tempMax: number, textLength: number): number {
    const letrasPorSec = textLength / time;
    if (errors >= 5) {
      return 0;
    } else if (errors < 5 && errors >= 4) {
      if (letrasPorSec > tempMax) {
        return 1;
      } else {
        return 0;
      }
    } else if (errors < 4 && errors >= 3) {
      if (letrasPorSec > tempMax) {
        return 2;
      } else {
        return 0;
      }
    } else if (errors < 3 && errors >= 2) {
      if (letrasPorSec > tempMax) {
        return 3;
      } else {
        return 0;
      }
    } else if (errors < 2 && errors >= 1) {
      if (letrasPorSec > tempMax) {
        return 4;
      } else {
        return 0;
      }
    } else if (errors === 0) {
      if (letrasPorSec > tempMax) {
        return 5;
      } else {
        return 0;
      }
    } else {
      return 0;
    }
  }

}


export class ResultDto {
  idLesson: number;
  stars: number;
  errors: number;
  time: number;
  ppm: number;
  userId: string;
}
