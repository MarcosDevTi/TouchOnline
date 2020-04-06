import { Component, OnInit } from '@angular/core';
import { LessonTextService } from '../shared/lesson-text.service';
import { LessonText } from '../shared/lesson-text';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LessonItem } from 'src/app/pages/lessons/models/lesson-item.model';

@Component({
  selector: 'app-lesson-list',
  templateUrl: './lesson-list.component.html',
  styleUrls: ['./lesson-list.component.css']
})
export class LessonListComponent implements OnInit {
  lessonTexts: LessonItem[] = [];
  displayedColumns: string[] = ['name', 'text', 'level', 'language', 'order', 'idLesson', 'actions'];
  createTextForm: FormGroup;
  
  constructor(private lessonTextService: LessonTextService, private fb: FormBuilder, private router: Router) { }

  buildCreateTextForm() {
    this.createTextForm = this.fb.group({
      level: ['1'],
      language: ['0'],
    });
    this.lessonTextService.getLessons(0, 0).subscribe(_ => this.lessonTexts = _);

    this.createTextForm.valueChanges.subscribe(_ => {
      if(_.level && _.language) {
        this.lessonTextService.getLessons(_.level, _.language).subscribe(_ => this.lessonTexts = _);
      }
    });
  }

  ngOnInit(): void {
    this.buildCreateTextForm();
    this.lessonTextService.getLessons(1, 0).subscribe(_ => this.lessonTexts = _);
  }
  edit(){

  }
  delete(id: string) {
    this.lessonTextService.delete(id).subscribe();
    window.location.reload();
  }
}
