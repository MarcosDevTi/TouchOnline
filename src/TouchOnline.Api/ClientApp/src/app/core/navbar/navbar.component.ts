import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/pages/auth/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LessonService } from 'src/app/pages/lessons/lesson.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  user: any = {};
  loginForm: FormGroup;
  nameDisplay: string;
  userAuthenticated;
  isAdmin: boolean;
  constructor(
    public authService: AuthService,
    private lessonService: LessonService,
    private formBuilder: FormBuilder,
    private router: Router,
    public translate: TranslateService
  ) { }
  selected;
  ngOnInit() {
   this.isAdminRefresh();
    this.createLoginForm();
    this.nameDisplay = localStorage.getItem('name');
    this.selected = this.translate.currentLang;
  }

  selectChange(e){
    console.log(e)
     this.translate.use(e.value)
  }

  isAdminRefresh() {
    this.authService.isAdmin(localStorage.getItem('userId')).subscribe(_ => {
      this.isAdmin = _;
      this.authService.isAdminStatic = _;
    });
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
    });
  }

  login() {
    this.lessonService.getLessons('beginners').subscribe(_ => _)
    this.user = Object.assign({}, this.loginForm.value);
    
    
    this.authService.login(this.user).subscribe(next => {
      // this.alertify.success('Logged in Successfully');
     
      console.log('Logged in Successfully');
    }, error => {
      // this.alertify.error(error);
    }, () => {
      ['basics', 'intermediates', 'advanceds', 'myText']
    .forEach(list => this.lessonService.getLessons(list).subscribe(_ => _))
      this.router.navigate([''], {skipLocationChange: true}).then(
        () => this.router.navigate(['/lessons/beginner'])
      );
    }
  );
  this.isAdminRefresh();
}

loggedIn() {
  return this.authService.loggedIn();
}

logout() {
  localStorage.removeItem('token');
  localStorage.removeItem('user');
  localStorage.removeItem('userId');
  localStorage.removeItem('myText');
  this.authService.decodedToken = null;
  this.authService.currentUser = null;

  this.router.navigate(['']);
  this.isAdminRefresh();
}
}
