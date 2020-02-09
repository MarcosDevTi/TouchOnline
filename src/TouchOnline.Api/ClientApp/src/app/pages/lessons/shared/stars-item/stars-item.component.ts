import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-stars-item',
  templateUrl: './stars-item.component.html',
  styleUrls: ['./stars-item.component.css']
})
export class StarsItemComponent implements OnInit{
@Input() numStars;
stars: string[];
ok = 'star';
notOk = 'star_border';

  scores = [
    { num: 0, values: [this.notOk, this.notOk, this.notOk, this.notOk, this.notOk]},
    { num: 1, values: [this.ok, this.notOk, this.notOk, this.notOk, this.notOk]},
    { num: 2, values: [this.ok, this.ok, this.notOk, this.notOk, this.notOk]},
    { num: 3, values: [this.ok, this.ok, this.ok, this.notOk, this.notOk]},
    { num: 4, values: [this.ok, this.ok, this.ok, this.ok, this.notOk]},
    { num: 5, values: [this.ok, this.ok, this.ok, this.ok, this.ok]},
  ];

  ngOnInit() {
    this.stars = this.scores[this.numStars].values;
  }
}
