import { Component, Injector } from '@angular/core';
import { ListComponent } from '../shared/list.component';


@Component({
  selector: 'app-intermediate-list',
  templateUrl: './intermediate-list.component.html',
  styleUrls: ['./intermediate-list.component.css', './../shared/list.component.css']
})
export class IntermediateListComponent extends ListComponent {

  constructor(protected injector: Injector) { super(injector, 2); }

  init(): void { }
}
