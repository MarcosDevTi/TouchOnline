import { Component, OnInit } from '@angular/core';
import { ManagementService } from '../../shared/management.service';
import { UserManagement } from '../../shared/users-management';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: UserManagement[] = [];
  displayedColumns: string[] = ['id', 'name', 'email', 'inscriptionDate', 'resultsCount', 'myTextsCount'];

  constructor(private managementService: ManagementService) { }

  ngOnInit() {
    this.managementService.getUsers().subscribe(_ => this.users = _);
  }

}
