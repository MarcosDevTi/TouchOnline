import { Component, OnInit, AfterViewInit, AfterContentChecked, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/pages/auth/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute, RoutesRecognized, NavigationEnd, NavigationStart } from '@angular/router';
import { LessonService } from 'src/app/pages/lessons/lesson.service';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, AfterContentChecked {
  @Output() changeLanguage = new EventEmitter<string>();
  lang: string;
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
    private route: ActivatedRoute,
    public translate: TranslateService,
  ) { }
  ngAfterContentChecked(): void {
    this.selected = this.translate.currentLang;
    this.lang = this.translate.currentLang;
  }
  
  selected;
  ngOnInit() {
   this.isAdminRefresh();
    this.createLoginForm();
    this.nameDisplay = localStorage.getItem('name');
  }

  selectChange(e){
    localStorage.setItem('lang', e.value);
    this.translate.use(e.value);
    location.reload();
    //const url: string = this.route.root._routerState.snapshot.url;
    
    //e.value + url.substring(3, url.length)
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
    this.lessonService.getLessons(0, 0).subscribe(_ => _)
    this.user = Object.assign({}, this.loginForm.value);
    
    
    this.authService.login(this.user).subscribe(next => {
      // this.alertify.success('Logged in Successfully');
     
      console.log('Logged in Successfully');
    }, error => {
      // this.alertify.error(error);
    }, () => {
      ['basics', 'intermediates', 'advanceds', 'myText']
    .forEach(list => this.lessonService.getLessons(0, 0).subscribe(_ => _))
      this.router.navigate([''], {skipLocationChange: true}).then(
        () => this.router.navigate([this.lang + '/lessons/beginner'])
      );
    }
  );
  this.isAdminRefresh();
}

loggedIn() {
  return this.authService.loggedIn();
}

logout() {
  localStorage.clear();
  
  this.authService.decodedToken = null;
  this.authService.currentUser = null;

  // this.router.navigate([this.lang]);
  location.reload();
  this.isAdminRefresh();
}
}
