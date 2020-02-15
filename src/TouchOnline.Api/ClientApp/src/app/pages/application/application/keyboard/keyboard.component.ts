import { Component, OnInit, Input, OnChanges, Output } from '@angular/core';
import { Finger } from './finger';
import { KeyModel } from './KeyModel';
import { KeyServiceService } from './key.service';
import { Subscribable } from 'rxjs';
import { Keyboard } from './leyboard';
import { KeyCode } from './key-code';

@Component({
  selector: 'app-keyboard',
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.css']
})
export class KeyboardComponent implements OnInit, OnChanges {

  @Input() proximaTecla: number;
  @Input() teclaEmErro: string;
  @Output() kbCodeSelected = '';

  keyboardLocal
  idNextKeyGreen1;
  idNextKeyGreen2;

  errorsClass: any[] = [];
  successClass: any[] = [];
  valTrue = true;

  cleanKeys: KeyModel[];
  keys: KeyModel[];
  codeKeys: KeyCode[];
  keyCode: KeyCode;
  codigosStr: string;
  constructor(private keyServiceService: KeyServiceService) { }
  dedoE: string;
  dedoD: string;

  ngOnChanges(changes): void {
    const kb = this.getObjLocal<KeyModel[]>('kb');
    console.log('changes', changes)
    this.keys = kb;
    this.getKeyCodes(this.proximaTecla)
  }

  getObjLocal<T>(key: string): T {
    return JSON.parse(localStorage.getItem(key));
  }

  ngOnInit() {
    this.getKeyCodes(this.proximaTecla)


    // if (k.data) {
    //   this.keys = k.data;
    //   this.cleanKeys = k.data;
    //   this.codeKeys = k.codeKeys;
    // }
    // //const cods = this.obterKbBrCodigos(this.proximaTecla, k.codeKeys);
    // const cods = ""
    // this.refreshFingers();

    // const erros = this.getKeyCodes(this.teclaEmErro.charCodeAt(0).toString(), k.codeKeys);
    // this.obterBrasileiro(erros, erros);
  }

  changes() {
    //const cods = this.getKeyCodes(this.proximaTecla);
    this.refreshFingers();
    // this.obterBrasileiro(
    //   this.getKeyCodes(this.proximaTecla),
    //   this.getKeyCodes(this.teclaEmErro.charCodeAt(0).toString())
    // );
  }

  getKeyCodes(cod: number) {
    if (cod) {
      this.keyCode = this.getObjLocal<KeyCode[]>('keyCodes')
        .find(_ => _.key == cod);
    }
  }

  getClassGreen(key): boolean {
    return this.keyCode.codes.map(function (_) {
      return 'key_' + _
    }).includes(key);
  }

  keyIsRed(key): boolean {
    console.log('key error dig', key)
    return (this.teclaEmErro.charCodeAt(0) == NaN ||
    this.teclaEmErro == '') && 
    'key_' + this.teclaEmErro.charCodeAt(0) == key;
  }

  obterBrasileiro(acerto: string[], erros: string[]) {
    const jsonRes = JSON.parse(localStorage.getItem('kb'));
    this.successClass = [];
    this.errorsClass = [];

    if (jsonRes) {
      this.keys = jsonRes.data;
    }
    acerto.forEach(ac => {
      const indx = this.keys.findIndex(x => x.id === 'key_' + ac);
      if (this.keys[indx] !== undefined) {
        this.keys[indx].key1 += ' teclaVerde';
        this.successClass.push({ key: 'key_' + ac, class: 'teclaVerde' })
      }
    });

    erros.forEach(ac => {
      const indx = this.keys.findIndex(x => x.id === 'key_' + ac);
      if (this.keys[indx] !== undefined) {
        this.keys[indx].key1 += ' teclaVermelha';
        this.errorsClass.push({ key: 'key_' + ac, class: 'teclaVermelha' })
      }
    });

    console.log('temp change', this.keys);
  }

  buscarDedos(fingerCodes: string[]): Finger[] {
    const fingersList = [
      new Finger([101, 102, 202, 302, 401, 402, 403], 'e5', 'e'),
      new Finger([103, 203, 303, 404], 'e4', 'e'),
      new Finger([104, 204, 304, 405], 'e3', 'e'),
      new Finger([105, 106, 205, 206, 305, 306, 406, 407], 'e5', 'e'),
      new Finger([504, 505], 'e1', 'e'),
      new Finger([107, 108, 207, 208, 307, 308, 408, 409], 'd2', 'd'),
      new Finger([109, 209, 309, 410], 'd3', 'd'),
      new Finger([110, 210, 310, 411], 'd4', 'd'),
    ];
    let result: Finger[] = [];

    fingerCodes.forEach(_ => {
      const index = fingersList.findIndex(_ => _.Codigos.includes(Number(_)))[0];
      result.push(fingersList[index])
    })

    return result;
  }

  refreshFingers() {
    // const codeKeys: string[] = JSON.parse(localStorage.getItem('kb')).codeKeys;
    // const cods = this.getKeyCodes(this.proximaTecla, this.codeKeys)
    // this.dedoE = this.buscarDedos(cods).filter(_ => _.HandCode === 'e')[0].NomeDedo
    // this.dedoD = this.buscarDedos(cods).filter(_ => _.HandCode === 'd')[0].NomeDedo
    // console.log('dedoE', this.dedoE);
    // console.log('dedoD', this.dedoD);
  }
}
