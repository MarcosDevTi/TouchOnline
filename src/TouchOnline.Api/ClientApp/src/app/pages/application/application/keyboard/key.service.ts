import { KeyModel } from './KeyModel';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Keyboard } from './leyboard';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class KeyServiceService {
  private keyboard;
  constructor(private http: HttpClient) {
    
  }

  getKeyboard(): Observable<Keyboard> {
    
    return this.http.get<Keyboard>('http://localhost:5000/api/keyboard');
  }

  getKeyboardInMemory(): Keyboard {
    return this.keyboard;
  }

  setKeyboardInMemory(keyboard: Keyboard) {
    this.keyboard = keyboard;
  }
}