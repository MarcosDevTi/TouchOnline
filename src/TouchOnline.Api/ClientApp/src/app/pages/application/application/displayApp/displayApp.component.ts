import { Component, OnInit, Input } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material';
import { LessonService, ResultDto } from 'src/app/pages/lessons/lesson.service';
import { ApplicationService } from '../../application.service';

@Component({
  selector: 'app-displayApp',
  templateUrl: './displayApp.component.html',
  styleUrls: ['./displayApp.component.css']
})
export class DisplayAppComponent implements OnInit {
  keyboards = [{keyboardLabel: 'Português Brasil', key: 'pt-BR'}];
  selected = 'pt-BR';
  @Input() timeLeft
  @Input() ppm
  @Input() LineChart
  @Input() name
  @Input() category
  constructor(
    public dialog: MatDialog,
    private service: ApplicationService) {}

  ngOnInit() {
  }

  
}
