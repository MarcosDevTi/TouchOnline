import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'timerFormat'})
export class TimerFormat implements PipeTransform {
  transform(value: number): string {
        const min = this.zeroPad(this.calcularMinHora(value, 60), 2);
        const sec = this.zeroPad((value % 60), 2);
        const hour = this.zeroPad(this.calcularMinHora(value, 1800), 2);

    return `${min}:${sec}`;
  }

  calcularSegundos(value: number) {

  }

  calcularMinHora(value: number, indice: number): number {
    const min = value / indice;
    const num = min.toString().split('.')[0];
        return Number(num);
    }

  zeroPad(num, places) {
        const zero = places - num.toString().length + 1;
        return Array(+(zero > 0 && zero)).join('0') + num;
      }
}
