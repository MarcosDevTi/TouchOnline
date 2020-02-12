import { Component, OnInit, Injector } from '@angular/core';
import { LessonItem } from '../models/lesson-item.model';
import { LessonService } from '../lesson.service';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';
import { ListService } from '../shared/list.service';
import { VisitorService } from 'src/app/shared/visitor.service';

@Component({
  selector: 'app-basic-list',
  templateUrl: './basic-list.component.html',
  styleUrls: ['./basic-list.component.css', './../shared/list.component.css']
})
export class BasicListComponent extends ListService {
  
  constructor(protected injector: Injector) { super(injector, 'basics') }

  init(): void {}
}
