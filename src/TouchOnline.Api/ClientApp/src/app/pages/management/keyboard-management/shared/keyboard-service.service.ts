import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { KeyboardForUpdate } from './keyboard-for-update';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class KeyboardServiceService {
  keyboardUrl = environment.apiKeyboard;
  constructor(private http: HttpClient) { }

  getKeyboardsManagement(): Observable<KeyboardForUpdate[]> {
    const url = this.keyboardUrl + 'GetKeyboardsManagement';
    return this.http.get<KeyboardForUpdate[]>(url);
  }

updateKeyboard(keyboard: KeyboardForUpdate): Observable<KeyboardForUpdate> {
    const url = this.keyboardUrl + 'UpdateKeyboard';
    return this.http.put<KeyboardForUpdate>(url, keyboard);
  }

  getKeyboardByIdForUpdate(id: string): Observable<KeyboardForUpdate> {
    const url = this.keyboardUrl + 'GetKeyboardByIdForUpdate/' + id;
    return this.http.get<KeyboardForUpdate>(url);
  }

  insertKeyboards() {
    return this.http.get(this.keyboardUrl + 'InsertKeyboardLayout');
  }

}
