import { Component, Injector } from '@angular/core';
import { VisitorService } from 'src/app/shared/visitor.service';
import { ListComponent } from '../shared/list.component';

@Component({
  selector: 'app-advanced-list',
  templateUrl: './advanced-list.component.html',
  styleUrls: ['./advanced-list.component.css', './../shared/list.component.css']
})
export class AdvancedListComponent extends ListComponent {
  constructor(
    protected injector: Injector) {
      super(injector, 3);
    }

    init() {
     
    }
}


