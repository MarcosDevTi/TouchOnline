import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LessonItem } from './models/lesson-item.model';
import { map, catchError } from 'rxjs/operators';
import { throwError, Observable, of } from 'rxjs';
import { Frase } from './models/frase';
import { environment } from 'src/environments/environment';
import { Key } from './models/key';
import { Resultado } from './models/Resultado';
import { LessonApp } from './models/lesson-app';

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
        return jsonData;
      }
    } else {
      // this.getResults().subscribe(_ => console.log(_))

      return jsonData;
      // let lessons: LessonItem[] = [];
      // jsonData.forEach(_ => lessons.push(_));
      // return lessons;
    }
  }

  private handleError(error: any): Observable<any> {
    console.log('Request Error => ', error);
    return throwError(error);
  }

  gravarResultado(resultado: any): Observable<ResultDto> {
    console.log('result for save', resultado);
    if (resultado.userId !== 'undefined' && resultado.userId !== null) {
      return this.http.post(this.baseUrl + '/SetResult', resultado).pipe(
        catchError(this.handleError),
        map(this.jsonDataToCategory)
      );
    } else {
      const result = this.saveResultOnLocalStorage(resultado);
      return of(result);
    }
  }

  saveResultOnLocalStorage(result: ResultDto): ResultDto {
    const resultsLocal = localStorage.getItem('results');
    const resultList: ResultDto[] = [];
    if (resultsLocal === null) {
      resultList.push(result);
      localStorage.setItem('results', JSON.stringify(resultList));
    } else {
      const listLocal: ResultDto[] = JSON.parse(resultsLocal);
      const index = listLocal.findIndex(l => l.idLesson === result.idLesson);
      if (index !== -1) {
        listLocal[index].ppm = result.ppm;
        listLocal[index].errors = result.errors;
        listLocal[index].stars = result.stars;
        listLocal[index].time = result.time;

      } else {
        listLocal.push(result);
      }
      localStorage.setItem('results', JSON.stringify(listLocal));
    }

    return result;
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
