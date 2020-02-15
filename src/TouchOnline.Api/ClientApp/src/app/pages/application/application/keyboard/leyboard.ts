import { KeyModel } from './KeyModel';
import { KeyCode } from './key-code';

export class Keyboard {
    code: string;
    name: string;
    data: KeyModel[];
    type: number;
    codeKeys: KeyCode[];
    status: boolean;
}
