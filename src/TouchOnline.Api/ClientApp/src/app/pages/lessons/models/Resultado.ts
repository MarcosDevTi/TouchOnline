import { ErroChart } from './erroChart';

export class Resultado {
    idLesson: number;
    tempo: number;
    ppm: string;
    erros: ErroChart[];
    category: string;
    textLength: number;
    userId: string;
}
