import { Component, OnInit, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ApplicationService } from '../../application.service';
import { KeyServiceService } from '../keyboard/key.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-displayApp',
  templateUrl: './displayApp.component.html',
  styleUrls: ['./displayApp.component.css']
})
export class DisplayAppComponent implements OnInit {
  keyboardsDw: any[];
  selected;

  @Input() timeLeft;
  @Input() ppm;
  @Input() LineChart;
  @Input() name;
  @Input() category;
  @Output() keyboardChange = new EventEmitter();


  constructor(
    public dialog: MatDialog,
    private applicationService: ApplicationService,
    private keyServiceService: KeyServiceService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.setKeyboard();
    const localBkId = localStorage.getItem('bkId')

    this.applicationService.getKeyboardsDw().subscribe(_ => {
      this.keyboardsDw = _;
      if (!localBkId)
        this.selected = _[0].id;
      this.selected = localBkId;
    });
  }

  selectKeyboard(id) {
    this.applicationService.getKeyboard(id).subscribe(_ => {
      if (_) {
        localStorage.setItem('bkId', _.id);
        localStorage.setItem('kb', JSON.stringify(_.data));
        localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
      }
    });
    this.keyboardChange.emit(id);
  }

  setKeyboard() {
    var kbLocal = localStorage.getItem('kb');
    if (!kbLocal) {
      const idKeyboardEnUs = '98ae3257-79e0-4efa-836b-6c74ff18020f';
      this.keyServiceService.getKeyboard(idKeyboardEnUs).subscribe(_ => {
        localStorage.setItem('kb', JSON.stringify(_.data))
        localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys))
      });
    }
  }
}
