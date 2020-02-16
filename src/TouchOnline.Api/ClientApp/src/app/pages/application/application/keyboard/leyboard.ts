import { KeyModel } from './KeyModel';
import { KeyCode } from './key-code';

export class Keyboard {
    id: string;
    code: string;
    name: string;
    data: KeyModel[];
    type: number;
    codeKeys: KeyCode[];
    status: boolean;
}
