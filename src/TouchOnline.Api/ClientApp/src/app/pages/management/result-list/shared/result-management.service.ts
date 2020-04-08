import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResultManagement } from './result-management';

@Injectable({
  providedIn: 'root'
})
export class ResultManagementService {
  url = environment.apiUrl + '/GetAllResults'
  constructor(private http: HttpClient) { }

  getAllResults(): Observable<ResultManagement[]>{
    return this.http.get<ResultManagement[]>(this.url);
  }
}
