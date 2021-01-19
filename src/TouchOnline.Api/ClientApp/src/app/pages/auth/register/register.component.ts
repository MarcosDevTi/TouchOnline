import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../user';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';
import { TextToolService } from 'src/app/shared/text-tool.service';
import { TranslateService } from '@ngx-translate/core';
import { LessonService } from '../../lessons/lesson.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  user: User;
  lang: string;

  registerForm: FormGroup;
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private trackingService: TrackingService,
    private textToolService: TextToolService,
    public translate: TranslateService,
    private lessonService: LessonService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.initLanguage();
    // tslint:disable-next-line:max-line-length
    const txtIn = 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It w as popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.';

    const txt = this.textToolService.wordWrap(txtIn, 40);
    this.trackingService.setvisitedPages('register');
    this.createRegisterForm();
  }

  initLanguage() {
    let lang = navigator.language.substring(0, 2);

    const langLocal = localStorage.getItem('lang');
    if (langLocal) {
      this.lang = langLocal;
      this.router.navigate(['/' + langLocal + '/auth/register']);
      this.translate.use(langLocal)
    } else {
      this.route.params.subscribe(value => {
        if (value['lang'] === undefined) {
          if (!this.translate.getLangs().includes(lang)) {
            lang = 'en';
          }
          this.router.navigate(['/' + lang + '/auth/register']);
        } else {
          lang = value['lang'];
        }
        this.translate.use(lang)
        this.lang = lang;
        localStorage.setItem('lang', lang);
      });

     
    }

  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
        email: ['', Validators.required],
        name: ['', Validators.required],
        password: ['', Validators.required],
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
        console.log('Registration Successful');
      }, error => {
        console.log(error);
      }, () => {
        this.authService.login(this.user).subscribe(() => {
          this.lessonService.setResults(this.user.email).subscribe(_ => console.log('result send results'))
           this.router.navigate(['/lessons/beginner']);
        });
      });
    }
  }
}
