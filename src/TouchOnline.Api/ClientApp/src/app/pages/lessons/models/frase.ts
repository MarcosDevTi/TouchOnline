import { Key } from './key';

export class Frase {
    constructor(keys: Key[], pageIndex: number) {
        this.keys = keys,
        this.pageIndex = pageIndex;
    }
    keys: Key[];
    pageIndex: number;
}