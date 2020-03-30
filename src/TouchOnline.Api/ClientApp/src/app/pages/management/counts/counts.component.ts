import { Component, OnInit, OnDestroy } from '@angular/core';
import { ManagementService } from '../shared/management.service';
import { Counts } from 'src/app/core/navbar/counts';

import { interval } from 'rxjs';

@Component({
  selector: 'app-counts',
  templateUrl: './counts.component.html',
  styleUrls: ['./counts.component.css']
})
export class CountsComponent implements OnInit, OnDestroy {
  counts: Counts
  sub;
  constructor(private managementService: ManagementService) { }
  ngOnInit() {
    this.sub = interval(2000)
      .subscribe((val) =>
        this.managementService.GetCounts().subscribe(_ => this.counts = _)
      );

  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}