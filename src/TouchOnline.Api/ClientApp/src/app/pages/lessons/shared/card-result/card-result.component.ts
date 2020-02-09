import { Component, OnInit, Input } from '@angular/core';
import { LessonItem } from '../../models/lesson-item.model';

@Component({
  selector: 'app-card-result',
  templateUrl: './card-result.component.html',
  styleUrls: ['./card-result.component.css']
})
export class CardResultComponent implements OnInit {
@Input() lesson: LessonItem
  constructor() { }

  ngOnInit() {
  }

}
