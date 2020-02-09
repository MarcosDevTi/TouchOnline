import { KeyModel } from './KeyModel';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
  export class KeyServiceService {
  teclado: KeyModel[] = new Array();
  constructor() { }

    obterTecladoBrasileiro(acerto: string[], erros: string[]): KeyModel[] {
      const result =  [
        new KeyModel('key_101', 'key key_two key_tilde', 'key_top', '"', 'key_bottom', '\''),
        new KeyModel('key_102', 'key key_two key_1', 'key_top', '!', 'key_bottom', '1'),
        new KeyModel('key_103', 'key key_two key_2', 'key_top', '@', 'key_bottom', '2'),
        new KeyModel('key_104', 'key key_two key_3', 'key_top', '#', 'key_bottom', '3'),
        new KeyModel('key_105', 'key key_two key_4', 'key_top', '$', 'key_bottom', '4'),
        new KeyModel('key_106', 'key key_two key_5', 'key_top', '%', 'key_bottom', '5'),
        new KeyModel('key_107', 'key key_two key_6', 'key_top', '¨', 'key_bottom', '6'),
        new KeyModel('key_108', 'key key_two key_7', 'key_top', '&', 'key_bottom', '7'),
        new KeyModel('key_109', 'key key_two key_8', 'key_top', '*', 'key_bottom', '8'),
        new KeyModel('key_110', 'key key_two key_9', 'key_top', '(', 'key_bottom', '9'),
        new KeyModel('key_111', 'key key_two key_0', 'key_top', ')', 'key_bottom', '0'),
        new KeyModel('key_112', 'key key_two key_-', 'key_top', '_', 'key_bottom', '-'),
        new KeyModel('key_113', 'key key_two key_=', 'key_top', '+', 'key_bottom', '='),
        new KeyModel('key_114', 'key key_back', null, 'Back', null, null),
        new KeyModel('key_201', 'key key_tab', null, 'Tab', null, null),
        new KeyModel('key_202', 'key key_q', null, 'q', null, null),
        new KeyModel('key_203', 'key key_w', null, 'w', null, null),
        new KeyModel('key_204', 'key key_e', null, 'e', null, null),
        new KeyModel('key_205', 'key key_r', null, 'r', null, null),
        new KeyModel('key_206', 'key key_t', null, 't', null, null),
        new KeyModel('key_207', 'key key_y', null, 'y', null, null),
        new KeyModel('key_208', 'key key_u', null, 'u', null, null),
        new KeyModel('key_209', 'key key_i', null, 'i', null, null),
        new KeyModel('key_210', 'key key_o', null, 'o', null, null),
        new KeyModel('key_211', 'key key_p', null, 'p', null, null),
        new KeyModel('key_212', 'key key_two key_bracket_lft', 'key_top', '`', 'key_bottom', '´'),
        new KeyModel('key_213', 'key key_two key_bracket_rgt', 'key_top', '{', 'key_bottom', '['),
        new KeyModel('key_214', 'key key_two key_backslash_rgt', 'key_top', '}', 'key_bottom', ']'),
        new KeyModel('key_301', 'key key_caps', null, 'Caps', null, null),
        new KeyModel('key_302', 'key key_a', null, 'a', null, null),
        new KeyModel('key_303', 'key key_s', null, 's', null, null),
        new KeyModel('key_304', 'key key_d', null, 'd', null, null),
        new KeyModel('key_305', 'key key_f', null, 'f', null, null),
        new KeyModel('key_306', 'key key_g', null, 'g', null, null),
        new KeyModel('key_307', 'key key_h', null, 'h', null, null),
        new KeyModel('key_308', 'key key_j', null, 'j', null, null),
        new KeyModel('key_309', 'key key_k', null, 'k', null, null),
        new KeyModel('key_310', 'key key_l', null, 'l', null, null),
        new KeyModel('key_311', 'key key_semicolon', null, 'ç', null, null),
        new KeyModel('key_312', 'key key_two key_apostrophe', 'key_top', '^', 'key_bottom', '~'),
        new KeyModel('key_313', 'key key_enter', null, 'Enter', null, null),
        new KeyModel('key_401', 'key key_shift_lft_long', null, 'Shift', null, null),
        new KeyModel('key_403', 'key key_z', null, 'z', null, null),
        new KeyModel('key_404', 'key key_x', null, 'x', null, null),
        new KeyModel('key_405', 'key key_c', null, 'c', null, null),
        new KeyModel('key_406', 'key key_v', null, 'v', null, null),
        new KeyModel('key_407', 'key key_b', null, 'b', null, null),
        new KeyModel('key_408', 'key key_n', null, 'n', null, null),
        new KeyModel('key_409', 'key key_m', null, 'm', null, null),
        new KeyModel('key_410', 'key key_two key_comma', 'key_top', '<', 'key_bottom', ','),
        new KeyModel('key_411', 'key key_two key_period', 'key_top', '>', 'key_bottom', '.'),
        new KeyModel('key_412', 'key key_two key_slash', 'key_top', ':', 'key_bottom', ';'),
        new KeyModel('key_413', 'key key_shift_rgt', null, 'Shift', null, null),
        new KeyModel('key_501', 'key key_ctrl_lft', null, 'Ctrl', null, null),
        new KeyModel('key_503', 'key key_alt_lft', null, 'Alt', null, null),
        new KeyModel('key_504', 'key key_space', null, '', null, null),
        new KeyModel('key_505', 'key key_alt_rgt', null, 'AltGr', null, null),
        new KeyModel('key_508', 'key key_ctrl_rgt', null, 'Ctrl', null, null),
      ];

      acerto.forEach(ac => {
    const indx = result.findIndex(x => x.id === 'key_' + ac);
    if (result[indx] !== undefined) {
        result[indx].key1 += ' teclaVerde';
      }
    });

      erros.forEach(ac => {
      const indx = result.findIndex(x => x.id === 'key_' + ac);
      if (result[indx] !== undefined) {
          result[indx].key1 += ' teclaVermelha';
        }
      });
      return result;
    }

    obterKbBrCodigos(cod: string): string[] {
   // tslint:disable-next-line:max-line-length
        const codigosStr = `39:101¶34:101;413¶49:102¶33:102;413¶185:102;505¶50:103¶64:103;413¶178:103;505¶51:104¶35:104;413¶179:104;505¶52:105¶36:105;413¶163:105;505¶53:106¶37:106;413¶162:106;505¶54:107¶168:107;401¶172:107;505¶55:108¶38:108;401¶56:109¶42:109;401¶57:110¶40:110;401¶48:111¶41:111;401¶45:112¶95:112;401¶61:113¶43:113;401¶167:113;505¶113:202¶81:202;413¶47:202;505¶119:203¶87:203;413¶63:203;505¶101:204¶69:204;413¶233:204;212¶201:204;413;212¶234:204;413;312¶202:204;413;312¶114:205¶82:205;413¶116:206¶84:206;413¶121:207¶89:207;401¶117:208¶85:208;401¶250:208;212¶218:208;401;212¶105:209¶73:209;401¶237:209;212¶205:209;401;212¶111:210¶79:210;401¶243:210;212¶211:210;401;212¶245:210;312¶213:210;401;312¶244:210;401;312¶212:210;401;312¶112:211¶80:211;401¶180:212;504¶96:212;401;504¶91:213¶123:213;401¶170:213;505¶93:214¶125:214;401¶186:214;505¶97:302¶65:302;413¶225:302;212¶193:302;413;212¶224:302;413;212¶192:302;413;212¶227:302;312¶195:302;413;312¶226:302;413;312¶194:302;413;312¶115:303¶83:303;413¶100:304¶68:304;413¶102:305¶70:305;413¶103:306¶71:306;413¶104:307¶72:307;401¶106:308¶74:308;401¶107:309¶75:309;401¶108:310¶76:310;401¶231:311¶199:311;401¶126:312;504¶94:312;401;504¶122:403¶90:403;413¶120:404¶88:404;413¶99:405¶67:405;413¶118:406¶86:406;413¶98:407¶66:407;413¶110:408¶78:408;401¶109:409¶77:409;401¶44:410¶60:410;401¶46:411¶62:411;401¶59:412¶58:412;401¶32:504`;
        const codesSplit = codigosStr.split('¶');
        let result: string[] = new Array();

        for (const i of codesSplit) {
          if (i.split(':')[0] === cod) {
            result =  i.split(':')[1].split(';');
          }
        }

        return result;
    }
  }