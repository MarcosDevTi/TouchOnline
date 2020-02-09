export class Key {
    constructor(letra: string, index: number) {
        this.letra = letra;
        this.index = index;
        this.tocada = false;
    }

    acertou: boolean;
    letra: string;
    index: number;
    tocada: boolean;
    numErros: number;
    proximo: boolean;

    errou(): void {
        this.acertou = false;
    }
}
