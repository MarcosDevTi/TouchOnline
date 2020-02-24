export class MessageForSend {
    name: string;
    email: string;
    text: string;
    userId: string;

    static fromJson(jsonData: any): MessageForSend {
        return Object.assign(new MessageForSend(), jsonData);
    } 
}