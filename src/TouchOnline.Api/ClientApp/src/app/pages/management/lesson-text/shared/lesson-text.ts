export class LessonText {
    constructor(
        id?:string,
        name?: string,
        text?: string,
        level?: number,
        language?: number,
        order?: number) {}
    
        static fromJson(jsonData: any): LessonText {
            jsonData.level = parseInt(jsonData.level);
            jsonData.language = parseInt(jsonData.language);
            return Object.assign(new LessonText(), jsonData);
        }
}