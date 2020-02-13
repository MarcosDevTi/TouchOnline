import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { Finger } from './finger';
import { KeyModel } from './KeyModel';
import { KeyServiceService } from './key.service';
import { Keyboard } from './leyboard';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-keyboard',
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.css']
})
export class KeyboardComponent implements OnInit, OnChanges {
  @Input() proximaTecla: string;
  @Input() teclaEmErro: string;
  
  cleanKeys: KeyModel[]
  keys: KeyModel[];
  codeKeys: string;
  codigosStr: string;
  constructor(private keyServiceService: KeyServiceService) { }
  dedosE: string[];
  dedosD: string[];
  ngOnInit() {
   const keyboardLocal = localStorage.get('kb');
   if (keyboardLocal) {
    this.ngOnChanges();
   } else {
    this.keyServiceService.getKeyboard().subscribe(k => {
      if (k.data) {
        this.keys = k.data
        this.cleanKeys = k.data
        this.codeKeys = k.codeKeys
        //localStorage.setItem('kb', JSON.stringify(k));
      }
      const cods = this.obterKbBrCodigos(this.proximaTecla, k.codeKeys);
      this.refreshFingers(cods);

      const erros = this.obterKbBrCodigos(this.teclaEmErro.charCodeAt(0).toString(), k.codeKeys);
      this.obterBrasileiro(cods, erros);
    });
   }
   

  }

  ngOnChanges() {
    const cods = this.obterKbBrCodigos(this.proximaTecla, this.codeKeys);
    this.refreshFingers(cods);
    this.obterBrasileiro(
      this.obterKbBrCodigos(this.proximaTecla, this.codeKeys),
      this.obterKbBrCodigos(this.teclaEmErro.charCodeAt(0).toString(), this.codeKeys)
    );
  }

  obterKbBrCodigos(cod: string, codeKeys: string): string[] {
    let result: string[] = new Array();

    if (codeKeys) {
      const codesSplit = codeKeys.split('¶');
      for (const i of codesSplit) {
        if (i.split(':')[0] === cod) {
          result = i.split(':')[1].split(';');
        }
      }
    }

    return result;
  }

  obterBrasileiro(acerto: string[], erros: string[]) {
  
   const jsonRes = JSON.parse(localStorage.getItem('kb'));
   if(jsonRes){
    this.keys = jsonRes.data;
   }
    acerto.forEach(ac => {
      const indx = this.keys.findIndex(x => x.id === 'key_' + ac);
      if (this.keys[indx] !== undefined) {
        this.keys[indx].key1 += ' teclaVerde';
      }
    });

    erros.forEach(ac => {
      const indx = this.keys.findIndex(x => x.id === 'key_' + ac);
      if (this.keys[indx] !== undefined) {
        this.keys[indx].key1 += ' teclaVermelha';
      }
    });
    
    console.log('temp change', this.keyServiceService.getKeyboardInMemory())
  }

  buscarDedos(codDedo: string): string {
    const listaDedos = [
      new Finger([101, 102, 202, 302, 401, 402, 403], 'e5'),
      new Finger([103, 203, 303, 404], 'e4'),
      new Finger([104, 204, 304, 405], 'e3'),
      new Finger([105, 106, 205, 206, 305, 306, 406, 407], 'e5'),
      new Finger([504, 505], 'e1'),
      new Finger([107, 108, 207, 208, 307, 308, 408, 409], 'd2'),
      new Finger([109, 209, 309, 410], 'd3'),
      new Finger([110, 210, 310, 411], 'd4'),
    ];
    const result = listaDedos.filter(x => x.Codigos.map(c => c.toString()).includes(codDedo))[0];

    return result ? result.NomeDedo : 'd5';
  }

  refreshFingers(cods: string[]) {
    const listaDedos = cods.map(x => this.buscarDedos(x));
    this.dedosE = listaDedos.filter(d => d.includes('e'));
    this.dedosD = listaDedos.filter(d => d.includes('d'));
  }
}
