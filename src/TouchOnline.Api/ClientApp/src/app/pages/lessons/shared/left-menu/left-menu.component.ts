import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/pages/auth/auth.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.css']
})
export class LeftMenuComponent implements OnInit {
  lang: string;
  menuNiveis: { name: string; link: string; }[];
  constructor(
    public authService: AuthService,
    public translate: TranslateService) { }

  ngOnInit() {
    const lang = this.translate.currentLang;
    this.menuNiveis = [
      {name: 'Beginner', link: `/${lang}/lessons/beginner`},
      {name: 'Basic', link: `/${lang}/lessons/basic`},
      {name: 'Intermediate', link: `/${lang}/lessons/intermediate`},
      {name: 'Advanced', link: `/${lang}/lessons/advanced`},
    ];

    if(this.authService.loggedIn()) {
      this.menuNiveis.push(
        {name: 'MyTexts', link: `/${lang}/lessons/my-text`}
      )
    }
  }
  
   ngAfterViewInit() {
    (window['adsbygoogle'] = window['adsbygoogle'] || []).push({
                    overlays: {bottom: true}
                });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
