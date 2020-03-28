import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/pages/auth/auth.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.css']
})
export class LeftMenuComponent implements OnInit {
  menuNiveis: { name: string; link: string; }[];
  constructor(
    public authService: AuthService,
    public translate: TranslateService) { }

  ngOnInit() {
    this.menuNiveis = [
      {name: 'Beginner', link: '/lessons/beginner'},
      {name: 'Basic', link: '/lessons/basic'},
      {name: 'Intermediate', link: '/lessons/intermediate'},
      {name: 'Advanced', link: '/lessons/advanced'},
    ];

    if(this.authService.loggedIn()) {
      this.menuNiveis.push(
        {name: 'MyTexts', link: '/lessons/my-text'}
      )
    }
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
