import { Component, Injector } from '@angular/core';
import { ListComponent } from '../shared/list.component';
import { BeginnerLessonsService } from './shared/beginner-lessons.service';

@Component({
  selector: 'app-beginner-list',
  templateUrl: './beginner-list.component.html',
  styleUrls: ['./beginner-list.component.css', './../shared/list.component.css']
})
export class BeginnerListComponent extends ListComponent {
  constructor(
    protected injector: Injector) { super(injector, 'beginners'); }

  init(): void {
    

  }
}
