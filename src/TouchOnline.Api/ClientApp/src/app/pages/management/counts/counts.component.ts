import { Component, OnInit } from '@angular/core';
import { ManagementService } from '../shared/management.service';
import { Counts } from 'src/app/core/navbar/counts';

@Component({
  selector: 'app-counts',
  templateUrl: './counts.component.html',
  styleUrls: ['./counts.component.css']
})
export class CountsComponent implements OnInit {
  counts: Counts
  constructor(private managementService: ManagementService) { }

  ngOnInit() {
    this.managementService.GetCounts().subscribe(_ => this.counts = _);
  }

}
