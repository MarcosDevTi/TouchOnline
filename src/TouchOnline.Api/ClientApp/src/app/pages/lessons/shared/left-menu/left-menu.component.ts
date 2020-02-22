import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/pages/auth/auth.service';

@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.css']
})
export class LeftMenuComponent implements OnInit {
  menuNiveis: { name: string; link: string; }[];
  constructor(public authService: AuthService) { }

  ngOnInit() {
    this.menuNiveis = [
      {name: 'Iniciante', link: '/lessons/beginner'},
      {name: 'Básico', link: '/lessons/basic'},
      {name: 'Intermediário', link: '/lessons/intermediate'},
      {name: 'Avançado', link: '/lessons/advanced'},
    ];

    if(this.authService.loggedIn()) {
      this.menuNiveis.push(
        {name: 'Meus Textos', link: '/lessons/my-text'}
      )
    }
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
