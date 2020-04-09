import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material';
import { LessonService } from '../../lessons/lesson.service';
import { ErroChart } from '../../lessons/models/erroChart';
import { Frase } from '../../lessons/models/frase';
import { Key } from '../../lessons/models/key';
import { environment } from 'src/environments/environment';
import { Chart } from 'chart.js';
import { Resultado } from '../../lessons/models/Resultado';
import { ResultComponent } from './result/result.component';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';
import { BeginnerLessonsService } from '../../lessons/beginner-list/shared/beginner-lessons.service';
import { ApplicationService } from '../application.service';
import { CacheService } from 'src/app/shared/cache.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.css']
})
export class ApplicationComponent implements OnInit {
  baseUrl = environment.apiUrl;
  fraseExibicao: Key[];
  teclaAtual: Key = new Key('a', 0);
  timeLeft = 0;
  interval;
  ppm = '0';
  idExerc: string;
  textDisplay: Frase[] = [];
  actualPage = 0;
  onlyTextLesson: string;
  iniciado: boolean;
  countAllKeys = 0;
  teclasComErros: ErroChart[] = [];
  LineChart = [];
  teclaEmErro = '';
  proximaTecla = '';
  name: string;
  category: string;
  kbId: string;
  f = false;
  lang: string;
  levelQueryString: string;
  langQueryString: string;

  constructor(
    private route: ActivatedRoute,
    private lessonService: LessonService,
    private router: Router,
    public dialog: MatDialog,
    private trackingService: TrackingService,
    private beginnerLessonsService: BeginnerLessonsService,
    private applicationService: ApplicationService,
    private cacheService: CacheService,
    public translate: TranslateService
  ) { }

  ngOnInit() {
    this.initLanguage();
    // this.route.params.subscribe(value => {
    //   this.translate.use(value['lang'])
    //   this.lang = value['lang'];
    // });
    this.f = true;
    this.trackingService.setvisitedPages('app');
    this.idExerc = this.route.snapshot.paramMap.get('id');
    this.levelQueryString = this.route.snapshot.paramMap.get('level');
    this.langQueryString = this.route.snapshot.paramMap.get('lang');

    const less = this.obtenirLessonLocal(this.idExerc)
    console.log('lesson app', less)

    this.onlyTextCompleteLesson(this.idExerc);
    this.createLesson(less.text);
    this.updateTextDisplay(this.actualPage, this.teclaAtual.index);
    this.name = less.name;

    this.category = this.getCategory();


  }

  initLanguage() {

    this.lang = this.translate.currentLang;
    this.route.params.subscribe(value => {
      console.log('lang', value['lang'])
      if (value['lang'] === undefined) {
        const langBrowser = navigator.language.substring(0, 2);
        this.router.navigate([langBrowser + '/app/' + value['id']]);
      }
      this.translate.use(value['lang'])
    });
  }

  getLessonLocal() {
    
  }

  getLang(lang: string) {
    switch (lang) {
      case 'pt':
        return 0;
      case 'en':
        return 1;
      case 'es':
        return 2;
      case 'fr':
        return 3;
      default:
        return 1
    }
  }

  obtenirLessonLocal(idLesson) {
    let lessonsLocal = localStorage.getItem(`level_${this.levelQueryString}_language_${this.langQueryString}`);
     if(this.levelQueryString != '0') {
      return JSON.parse(lessonsLocal).filter(_ => _.idLesson == idLesson)[0];
     } else {
      return this.cacheService.beginers.filter(_ => _.idLesson == +this.idExerc)[0];
     }   
  }

  getCategory(): string {
    switch (this.idExerc[0]) {
      case '1': {
        return 'Iniciante';
      }
      case '2': {
        return 'Básico';
      }
      case '3': {
        return 'Intermediário';
      }
      case '4': {
        return 'Avançado';
      }
    }
  }

  changeKeyboard(kbId) {
    console.log(kbId);
    this.applicationService.getKeyboard(kbId).subscribe(_ => {
      if (_) {
        localStorage.setItem('bkId', kbId);
        localStorage.setItem('kb', JSON.stringify(_.data));
        localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
        localStorage.setItem('beginnersCodes', JSON.stringify(_.keycodesBeginners))
      }
      this.beginnerLessonsService.buildLessonsBeginners(_.keycodesBeginners);

      this.kbId = kbId;
      const less = this.obtenirLessonLocal(this.idExerc)
      this.textDisplay = [];
      this.createLesson(less.text);

      this.fraseExibicao = this.textDisplay[0].keys;

      this.ngOnInit()
    });


  }

  modificarTexto(txt) {
    if (!this.iniciado) {
      this.iniciado = true;
      this.startTimer();
    }


    const finalFrase = (this.teclaAtual.index + 1 === this.fraseExibicao.length);
    const digitado = txt[txt.length - 1];
    if (this.teclaAtual.letra === digitado && !finalFrase) {
      this.teclaAtual.proximo = false;
      this.teclaEmErro = '';
      this.updateTextDisplay(this.actualPage, this.teclaAtual.index + 1);

      if (digitado === ' ') {
        this.countAllKeys++;
      }
    } else if (finalFrase) {

      this.actualPage++;

      if (this.actualPage === this.textDisplay.length) {

        this.openDialog();
        this.pauseTimer();
      } else {
        this.fraseExibicao = this.textDisplay[this.actualPage].keys;
        this.teclaAtual = this.fraseExibicao[0];
        this.teclaAtual.proximo = true;
      }
    } else {
      this.fraseExibicao[this.teclaAtual.index].errou();
      this.atualizarErrosChart();
      this.teclaEmErro = digitado;
    }
  }

  updateTextDisplay(indFrase: number, indKey: number) {
    this.fraseExibicao = this.textDisplay[indFrase].keys;
    this.teclaAtual = this.fraseExibicao[indKey];
    this.teclaAtual.proximo = true;
    this.proximaTecla = this.teclaAtual.letra.charCodeAt(0).toString();
  }

  createLesson(text: string) {
    const frases = text.split('¶');
    for (let i = 0; i < frases.length; i++) {
      this.textDisplay.push(this.lessonService.createFrase(frases[i] + ' ', i));
    }
  }



  acertouLetra() {
    this.fraseExibicao = this.textDisplay[0].keys;
  }

  onlyTextCompleteLesson(text: string) {
    this.onlyTextLesson = text.replace('¶', ' ');
  }

  calcularLetrasPorMim(): void {
    const min = this.timeLeft / 60;
    this.ppm = (this.countAllKeys / min).toString().split('.')[0];
  }

  startTimer() {
    this.interval = setInterval(() => {
      this.timeLeft++;
      this.calcularLetrasPorMim();
    }, 1000);
  }

  pauseTimer() {
    clearInterval(this.interval);
  }

  textoMaior(): boolean {
    const any = this.idExerc != undefined && this.idExerc != null && this.idExerc.length > 0;
    if (any) {
      return this.idExerc[0] === '1' || this.idExerc[0] === '2';
    }
  }

  getAllText(): Key[] {
    const lista: Key[] = [];
    this.textDisplay.forEach(tx =>
      tx.keys.forEach(tcl => lista.push(tcl))
    );
    return lista;
  }

  atualizarErrosChart() {
    const letras = this.getAllText().filter(f => f.acertou !== undefined).map(x => x.letra);
    const dist = new Set(letras);
    this.teclasComErros = [];
    dist.forEach(d => this.teclasComErros.push(new ErroChart(d, letras.filter(x => x === d).length)));

    this.LineChart = new Chart('lineChart', {
      type: 'bar',
      data: {
        labels: this.teclasComErros.map(l => l.tecla),
        datasets: [{
          label: 'Erros',
          data: this.teclasComErros.map(e => e.numOcorrencias),
          backgroundColor: this.teclasComErros.map(x => {
            switch (x.numOcorrencias) {
              case (1):
                return '#ffcccc';
              case (2):
                return '#ffb3b3';
              case (3):
                return '#ff9999';
              case (4):
                return '#ff8080';
              default:
                return '#ff4d4d';
            }
          }),
          borderColor: this.teclasComErros.map(x => {
            switch (x.numOcorrencias) {
              case (1):
                return '#ff4d4d';
              case (2):
                return '#ff3333';
              case (2):
                return '#ff1a1a';
              case (2):
                return '#ff0000';
              default:
                return '#cc0000';
            }
          }),
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        },
        animation: {
          duration: 100
        },
        events: []
      }
    });
  }

  getIdUsuario(): string {
    return localStorage.getItem('userId');
  }

  openDialog(): void {
    const resultado: Resultado = {
      idLesson: +this.idExerc,
      tempo: this.timeLeft,
      ppm: this.ppm.toString(),
      erros: this.teclasComErros,
      category: this.idExerc[0],
      textLength: this.getAllText().length,
      userId: this.getIdUsuario()
    };

    const dialogRef = this.dialog.open(ResultComponent, {
      data: this.lessonService.generateResult(resultado)
    });


    dialogRef.afterClosed().subscribe(result => {
      this.router.navigate([this.getRouteRedirect(this.idExerc)]);
    });
  }

  getRouteRedirect(categ: string): string {
    const categEnter = categ[0];
    switch (categEnter) {
      case '1':
        return this.lang + '/lessons/beginner';
      case '2':
        return this.lang + '/lessons/basic';
      case '3':
        return this.lang + '/lessons/intermediate';
      case '4':
        return this.lang + '/lessons/advanced';
      default:
        return this.lang + '/lessons/my-text'
    }
  }

}
