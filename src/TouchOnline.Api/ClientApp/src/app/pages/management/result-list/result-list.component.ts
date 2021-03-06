import { Component, OnInit } from '@angular/core';
import { ResultManagementService } from './shared/result-management.service';
import { ResultManagement } from './shared/result-management';

@Component({
  selector: 'app-result-list',
  templateUrl: './result-list.component.html',
  styleUrls: ['./result-list.component.css']
})
export class ResultListComponent implements OnInit {
  displayedColumns: string[] = ['idLesson', 'errors', 'ppm', 'stars', 'time', 'date', 'userId', 'id', 'actions'];
  constructor(private resultManagementService: ResultManagementService) { }
  results: ResultManagement[] = [];
  ngOnInit(): void {
    this.resultManagementService.getAllResults().subscribe(_ => this.results = _);
  }

}
