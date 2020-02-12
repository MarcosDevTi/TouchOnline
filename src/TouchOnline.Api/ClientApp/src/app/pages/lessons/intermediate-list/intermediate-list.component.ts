import { Component, Injector } from '@angular/core';
import { ListService } from '../shared/list.service';

@Component({
  selector: 'app-intermediate-list',
  templateUrl: './intermediate-list.component.html',
  styleUrls: ['./intermediate-list.component.css', './../shared/list.component.css']
})
export class IntermediateListComponent extends ListService {

  constructor(protected injector: Injector) { super(injector, 'intermediates') }

  init(): void {}
}
