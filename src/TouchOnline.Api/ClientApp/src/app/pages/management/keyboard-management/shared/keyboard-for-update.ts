export class KeyboardForUpdate {
    constructor(
    id?: string,
    code?: string,
    name?: string,
    languageCode?: string,
    status?: string,
    keycodesBeginners?: string) {}

    static fromJson(jsonData: any): KeyboardForUpdate {
        return Object.assign(new KeyboardForUpdate(), jsonData);
    }
}