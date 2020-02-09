import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.css']
})
export class LeftMenuComponent implements OnInit {
  menuNiveis: { name: string; link: string; }[];
  constructor() { }

  ngOnInit() {
    this.menuNiveis = [
      {name: 'Iniciante', link: '/lessons/beginner'},
      {name: 'Basico', link: '/lessons/basic'},
      {name: 'Intermediario', link: '/lessons/intermediate'},
      {name: 'Avançado', link: '/lessons/advanced'}
    ];
  }
}