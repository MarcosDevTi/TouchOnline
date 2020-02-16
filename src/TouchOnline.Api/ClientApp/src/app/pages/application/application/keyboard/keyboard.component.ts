import { Component, OnInit, Input, OnChanges, Output } from '@angular/core';
import { Finger } from './finger';
import { KeyModel } from './KeyModel';
import { KeyCode } from './key-code';
import { StatusKey } from './status-key';

@Component({
  selector: 'app-keyboard',
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.css']
})
export class KeyboardComponent implements OnInit, OnChanges {
  @Input() proximaTecla: number;
  @Input() teclaEmErro: string;
  @Output() kbCodeSelected = '';

  keysColorClasses: StatusKey[] = [];
  keys: KeyModel[];
  keyCode: KeyCode;
  dedoE: string = '';
  dedoD: string = '';

  ngOnChanges(changes): void {
    const kb = this.getObjLocal<KeyModel[]>('kb');
    this.keys = kb;
    this.getKeyCodes(this.proximaTecla)
  }

  getObjLocal<T>(key: string): T {
    return JSON.parse(localStorage.getItem(key));
  }

  ngOnInit() {
    this.getKeyCodes(this.proximaTecla)
  }

  getKeyCodes(cod: number) {
    if (cod) {
      const kc = this.getObjLocal<KeyCode[]>('keyCodes')
        .find(_ => _.key == cod);
      this.keyCode = kc;
      this.updateSuccessClass(kc)
      this.updateErrorClass();
    }
  }

  updateSuccessClass(kc: KeyCode) {
    if (!this.teclaEmErro) {
      this.cleanSuccessClass();
      kc.codes.forEach(_ => {
        const valueForInsert: StatusKey = { class: 'teclaVerde', key: 'key_' + _ };
        this.keysColorClasses.push(valueForInsert);
      })
    }
    this.buscarDedos();
  }

  updateErrorClass() {
    this.cleanErrorClass();
    this.addErrorClass();
  }

  addErrorClass() {
    this.getErrorCodesKey().forEach(code =>
      this.keysColorClasses.push({ class: 'teclaVermelha', key: 'key_' + code }));
  }

  getErrorCodesKey(): number[] {
    const ch = this.teclaEmErro.charCodeAt(0);
    const codesResult = this.getObjLocal<KeyCode[]>('keyCodes').find(_ => _.key == ch);
    if (codesResult == null) {
      return [];
    } else {
      return codesResult.codes;
    }
  }

  cleanErrorClass() {
    this.keysColorClasses.filter(_ => _.class == 'teclaVermelha').forEach(_ => {
      const index = this.keysColorClasses.findIndex(r => r.key == _.key);
      this.keysColorClasses.splice(index, 1)
    }
    )
  }

  cleanSuccessClass() {
    this.keysColorClasses.filter(_ => _.class == 'teclaVerde').forEach(_ => {
      const index = this.keysColorClasses.findIndex(r => r.key == _.key);
      this.keysColorClasses.splice(index, 1)
    }
    )
  }

  getClassKey(key): string {
    return this.keysColorClasses.find(_ => _.key == key).class;
  }

  containsClassKey(key): boolean {
    return this.keysColorClasses.findIndex(_ => _.key == key) != -1;
  }

  buscarDedos(): Finger[] {
    const fingersList = [
      new Finger([101, 102, 202, 302, 401, 402, 403], 'e5', 'e'),
      new Finger([103, 203, 303, 404], 'e4', 'e'),
      new Finger([104, 204, 304, 405], 'e3', 'e'),
      new Finger([105, 106, 205, 206, 305, 306, 406, 407], 'e2', 'e'),
      new Finger([504, 505], 'e1', 'e'),
      new Finger([107, 108, 207, 208, 307, 308, 408, 409], 'd2', 'd'),
      new Finger([109, 209, 309, 410], 'd3', 'd'),
      new Finger([110, 210, 310, 411], 'd4', 'd'),
    ];
    let result: Finger[] = [];
    const greens = this.keysColorClasses.filter(_ => _.class == 'teclaVerde');

    this.dedoE = '';
    this.dedoD = '';
    for(const item in greens) {
      const k = greens[item].key.substring(4, greens[item].key.length)
      const d = fingersList.find(_ => _.Codigos.includes(Number(k)))
      console.log('k', k);
      
      if (d) {
        if (d.HandCode == 'e') {
          this.dedoE = d.NomeDedo
        } else if (d.HandCode == 'd') {
          this.dedoD = d.NomeDedo
        } else {
          this.dedoD = 'd5';
        }
      } else {
        this.dedoD = 'd5';
      }
      
    }
    
    return result;
  }
}
