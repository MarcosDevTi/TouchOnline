import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/pages/auth/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

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
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
   this.isAdminRefresh();
    this.createLoginForm();
    this.nameDisplay = localStorage.getItem('name');
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
    this.user = Object.assign({}, this.loginForm.value);
    this.authService.login(this.user).subscribe(next => {
      // this.alertify.success('Logged in Successfully');
      console.log('Logged in Successfully');
    }, error => {
      // this.alertify.error(error);
    }, () => {
      this.router.navigate(['/lessons/beginner']);
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
  this.authService.decodedToken = null;
  this.authService.currentUser = null;

  this.router.navigate(['']);
  this.isAdminRefresh();
}
}
