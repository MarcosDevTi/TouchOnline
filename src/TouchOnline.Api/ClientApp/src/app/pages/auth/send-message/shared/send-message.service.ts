import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MessageForSend } from './message-for-send';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SendMessageService {
  urlBase = environment.apiBase + "Support/"
  constructor(private http: HttpClient) { }

  sendMessage(message: MessageForSend): Observable<any> {
    console.log('message in service http', message);
    return this.http.post(this.urlBase + 'SendMessage', message);
  }

}