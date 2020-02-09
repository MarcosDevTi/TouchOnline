import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { Finger } from './finger';
import { KeyModel } from './KeyModel';
import { KeyServiceService } from './key.service';

@Component({
  selector: 'app-keyboard',
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.css'],
  providers: [KeyServiceService]
})
export class KeyboardComponent implements OnInit, OnChanges {

  @Input() proximaTecla: string;
  @Input() teclaEmErro: string;

  constructor(private keyServiceService: KeyServiceService) { }
  teclado: KeyModel[];
  dedosE: string[];
  dedosD: string[];
  ngOnInit() {
    const cods = this.keyServiceService.obterKbBrCodigos(this.proximaTecla);
    const erros = this.keyServiceService.obterKbBrCodigos(this.teclaEmErro.charCodeAt(0).toString());
    this.teclado = this.keyServiceService.obterTecladoBrasileiro(cods, erros);
  }

  ngOnChanges() {
    const aa = this.keyServiceService.obterKbBrCodigos(this.proximaTecla);
    const listaDedos = aa.map(x => this.buscarDedos(x));

    this.dedosE = listaDedos.filter(d => d.includes('e'));
    this.dedosD = listaDedos.filter(d => d.includes('d'));


    this.teclado = this.keyServiceService.obterTecladoBrasileiro(
      this.keyServiceService.obterKbBrCodigos(this.proximaTecla),
      this.keyServiceService.obterKbBrCodigos(this.teclaEmErro.charCodeAt(0).toString())
      );
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
}
