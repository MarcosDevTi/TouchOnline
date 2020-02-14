import { Component, OnInit, Injector } from '@angular/core';
import { ListComponent } from '../shared/list.component';

@Component({
  selector: 'app-my-text-list',
  templateUrl: './my-text-list.component.html',
  styleUrls: ['./my-text-list.component.css', './../shared/list.component.css']
})
export class MyTextListComponent extends ListComponent {
  constructor(protected injector: Injector) { super(injector, 'myText'); }

  init(): void {
    this.lessonService
  }

}
