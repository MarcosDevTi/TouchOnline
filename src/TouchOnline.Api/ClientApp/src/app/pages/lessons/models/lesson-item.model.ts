export class LessonItem {
    idLesson: number;
    name: string;
    lessonTextShort: string;
    initialized: boolean;
    precision: number;
    ppm: number;
    stars = 0;
    time = 0;
    precisionDanger = this.precision < 95 ? 'bad' : 'good';
}
