import { Component, OnInit } from '@angular/core';
import { SafeHtml, DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-left-hand',
  templateUrl: './left-hand.component.html',
  styleUrls: ['./left-hand.component.css']
})
export class LeftHandComponent implements OnInit {
  radius = 54;
  circumference = 2 * Math.PI * this.radius;
  dashoffset: number;

  constructor() {
    this.progress(75);
  }

  ngOnInit() {}

  private progress(value: number) {
    const progress = value / 100;
    this.dashoffset = this.circumference * (1 - progress);
  }
}
