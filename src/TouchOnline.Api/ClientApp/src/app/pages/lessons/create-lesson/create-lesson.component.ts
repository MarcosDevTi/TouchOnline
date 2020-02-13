import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-lesson',
  templateUrl: './create-lesson.component.html',
  styleUrls: ['./create-lesson.component.css']
})
export class CreateLessonComponent implements OnInit {

  createTextForm: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.buildCreateTextForm();
  }

  buildCreateTextForm() {
    this.createTextForm = this.fb.group({
      name: [null, Validators.required],
      text: [null, Validators.required]
    });
  }

  saveLesson() {
    
  }
}
