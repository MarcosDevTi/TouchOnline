import { Component, OnInit, Input } from '@angular/core';
import { LessonItem } from '../../models/lesson-item.model';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-card-result',
  templateUrl: './card-result.component.html',
  styleUrls: ['./card-result.component.css']
})
export class CardResultComponent implements OnInit {
@Input() lesson: LessonItem;
  constructor(public translate: TranslateService) { }

  ngOnInit() {
    
  }

}
