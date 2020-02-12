import { Component, Injector } from '@angular/core';
import { VisitorService } from 'src/app/shared/visitor.service';
import { ListService } from '../shared/list.service';

@Component({
  selector: 'app-advanced-list',
  templateUrl: './advanced-list.component.html',
  styleUrls: ['./advanced-list.component.css', './../shared/list.component.css']
})
export class AdvancedListComponent extends ListService {

  level: string;

  constructor(
    protected injector: Injector,
    private visitorService: VisitorService) { 
      super(injector, 'advanceds') 
    }

    init() {
      this.visitorService.getLocation();
      this.visitorService.getIp();
    }
}


