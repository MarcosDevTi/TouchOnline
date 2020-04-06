import { Component, Injector } from '@angular/core';
import { ListComponent } from '../shared/list.component';

@Component({
  selector: 'app-basic-list',
  templateUrl: './basic-list.component.html',
  styleUrls: ['./basic-list.component.css', './../shared/list.component.css']
})
export class BasicListComponent extends ListComponent {
  constructor(protected injector: Injector) { super(injector, 1); }

  init(): void {}
}
