import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { User } from '../user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  user: User;
  
  registerForm: FormGroup;
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.createRegisterForm();
    
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
        email: ['', Validators.required],
        name: ['', Validators.required],
        password: ['', [Validators.minLength(4), Validators.maxLength(8)]],
        confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
  }

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authService.register(this.user).subscribe(() => {
        console.log('Registration Successful')
      }, error => {
        console.log(error);
      }, () => {
        this.authService.login(this.user).subscribe(() => {
           this.router.navigate(['/lessons/beginner']);
        });
      });
    }
  }
}
