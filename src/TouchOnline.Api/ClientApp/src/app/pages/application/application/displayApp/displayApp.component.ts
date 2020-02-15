import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ApplicationService } from '../../application.service';
import { KeyServiceService } from '../keyboard/key.service';

@Component({
  selector: 'app-displayApp',
  templateUrl: './displayApp.component.html',
  styleUrls: ['./displayApp.component.css']
})
export class DisplayAppComponent implements OnInit {
  keyboardsDw;

  @Input() timeLeft;
  @Input() ppm;
  @Input() LineChart;
  @Input() name;
  @Input() category;

  constructor(
    public dialog: MatDialog,
    private applicationService: ApplicationService,
    private keyServiceService: KeyServiceService) { }

  ngOnInit() {
    this.setKeyboard();
    this.applicationService.getKeyboardsDw().subscribe(_ => this.keyboardsDw = _);
  }

  selectKeyboard(id) {
    this.applicationService.getKeyboard(id).subscribe(_ => {
      if (_) {
        localStorage.setItem('kb', JSON.stringify(_.data));
        localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
      }
    });
  }

  setKeyboard() {
    var kbLocal = localStorage.getItem('kb');
    if(!kbLocal){
      const idKeyboardEnUs = '98ae3257-79e0-4efa-836b-6c74ff18020f';
      this.keyServiceService.getKeyboard(idKeyboardEnUs).subscribe(_ => {
        localStorage.setItem('kb', JSON.stringify(_.data))
        localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys))
      });
    }
  }
}
