export class LessonText {
    id:string;
    name: string;
    text: string;
    level: number;
    language: number;
    order: number;
    idLesson: number;
    
    static fromJson(jsonData: any): LessonText {
        let text = jsonData.text;
        let lesson = new LessonText();
        lesson.name = jsonData.name;
        lesson.level = parseInt(jsonData.level);
        lesson.language = parseInt(jsonData.language);
        text += this.getValue(jsonData.textLine2);
        text += this.getValue(jsonData.textLine3);
        text += this.getValue(jsonData.textLine4);
        text += this.getValue(jsonData.textLine5);
        text += this.getValue(jsonData.textLine6);
        text += this.getValue(jsonData.textLine7);
        lesson.text = text;
        lesson.order = jsonData.order;

        return lesson;
    }


    static getValue(value): string{
        if (value){
            return '¶' + value;
        } else {
            return '';
        }
    }
}