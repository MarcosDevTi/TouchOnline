export class LessonItem {
    idLesson: number;
    name: string;
    lessonText: string;
    text: string;
    level: string;
    initialized: boolean;
    precision: number;
    errors: number;
    ppm: number;
    stars = 0;
    time = 0;
    precisionDanger = this.precision < 95 ? 'bad' : 'good';
}
