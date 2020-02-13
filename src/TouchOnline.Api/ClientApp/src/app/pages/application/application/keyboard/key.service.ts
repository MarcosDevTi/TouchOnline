import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Keyboard } from './leyboard';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class KeyServiceService {
  private keyboard;
  apiKeyboard = environment.apiKeyboard;

  constructor(private http: HttpClient) {
    
  }

  getKeyboard(): Observable<Keyboard> {
    const keyboardId = localStorage.getItem('keyboardId');
    return this.http.get<Keyboard>(`${this.apiKeyboard}GetKeyboard?keyboardId=${keyboardId}`);
  }

  getKeyboardInMemory(): Keyboard {
    return this.keyboard;
  }

  setKeyboardInMemory(keyboard: Keyboard) {
    this.keyboard = keyboard;
  }
}