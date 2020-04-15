import { Component, Injector } from '@angular/core';
import { ListComponent } from '../../shared/list.component';

@Component({
  selector: 'app-my-text-list-management',
  templateUrl: './my-text-list-management.component.html',
  styleUrls: ['./my-text-list-management.component.css', './../../shared/list.component.css']
})
export class MyTextListManagementComponent extends ListComponent{
  constructor(protected injector: Injector) { super(injector, 4); }

  init(): void {}
}
