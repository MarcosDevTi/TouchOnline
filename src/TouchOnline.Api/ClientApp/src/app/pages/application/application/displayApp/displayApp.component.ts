import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ApplicationService } from '../../application.service';

@Component({
  selector: 'app-displayApp',
  templateUrl: './displayApp.component.html',
  styleUrls: ['./displayApp.component.css']
})
export class DisplayAppComponent implements OnInit {
  keyboardsDw;

  @Input() timeLeft
  @Input() ppm
  @Input() LineChart
  @Input() name
  @Input() category

  constructor(
    public dialog: MatDialog,
    private applicationService: ApplicationService) { }

  ngOnInit() {
    this.applicationService.getKeyboardsDw().subscribe(_ => this.keyboardsDw = _);
  }

  selectKeyboard(id) {
    this.applicationService.getKeyboard(id).subscribe(_ => {
      if (_) {
        console.log('keyboard returned', _)
        localStorage.setItem('kb', JSON.stringify(_));
      }
    })
  }

}
