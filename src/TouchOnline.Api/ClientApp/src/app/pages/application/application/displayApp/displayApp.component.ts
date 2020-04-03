import { Component, OnInit, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ApplicationService } from '../../application.service';
import { KeyServiceService } from '../keyboard/key.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BeginnerLessonsService } from 'src/app/pages/lessons/beginner-list/shared/beginner-lessons.service';

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
    public translate: TranslateService,
    private beginnerLessonsService: BeginnerLessonsService) { }

  ngOnInit() {
    this.setKeyboard();
    const localBkId = localStorage.getItem('bkId')

    this.applicationService.getKeyboardsDw().subscribe(_ => {
      this.keyboardsDw = _;
      if (!localBkId)
     {
      localStorage.setItem('bkId', _[0].id)
      this.selected = _[0].id;
     } else {
      this.selected = localBkId;
     }
      
    });
  }

  selectKeyboard(id) {
   
    this.keyboardChange.emit(id);
  }

  setKeyboard() {
    var kbLocal = localStorage.getItem('kb');
    if (!kbLocal) {
      const idKeyboardEnUs = localStorage.getItem('bkId');
      this.keyServiceService.getKeyboard(idKeyboardEnUs).subscribe(_ => {
        localStorage.setItem('kb', JSON.stringify(_.data));
        localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
        localStorage.setItem('beginnersCodes', JSON.stringify(_.keycodesBeginners))
      });
    }
  }
}