import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from './user';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { NavbarComponent } from 'src/app/core/navbar/navbar.component';
import { LessonService } from '../lessons/lesson.service';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAdminStatic;
  apiAuth = environment.apiAuth;
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;
  constructor(private http: HttpClient, private lessonService: LessonService) { }


  login(model: any) {
    return this.http.post(this.apiAuth + 'login', model)
      .pipe(map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', user.userfromDisplay.name);
          localStorage.setItem('userId', user.userfromDisplay.id);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.currentUser = user.user;
        }
      })
      );
  }

  register(user: User) {
    return this.http.post(this.apiAuth + 'register', user);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  isAdmin(userId): Observable<boolean> {
    return this.http.get<boolean>(this.apiAuth + 'IsAdmin?userId=' + userId );
  }
}
