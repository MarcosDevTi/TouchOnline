import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserManagement } from './users-management';
import { environment } from 'src/environments/environment';
import { Counts } from 'src/app/core/navbar/counts';

@Injectable({
  providedIn: 'root'
})
export class ManagementService {
  baseUrl = environment.apiManagement;
  constructor(private http: HttpClient) { }

  getUsers(): Observable<UserManagement[]> {
    return this.http.get<UserManagement[]>(this.baseUrl + 'GetUsers');
  }

  GetCounts(): Observable<Counts> {
    return this.http.get<Counts>(this.baseUrl + 'GetCounts');
  }
}
