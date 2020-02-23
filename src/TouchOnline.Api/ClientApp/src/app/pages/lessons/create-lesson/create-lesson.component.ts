import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MyTextService } from '../my-text.service';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { TextToolService } from 'src/app/shared/text-tool.service';
import { LessonService } from '../lesson.service';

@Component({
  selector: 'app-create-lesson',
  templateUrl: './create-lesson.component.html',
  styleUrls: ['./create-lesson.component.css']
})
export class CreateLessonComponent implements OnInit {

  createTextForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private myTextService: MyTextService,
    private router: Router,
    protected route: ActivatedRoute,
    private textToolService: TextToolService,
    private lessonService: LessonService
    ) { }

  ngOnInit() {
    this.buildCreateTextForm();
  }

  buildCreateTextForm() {
    this.createTextForm = this.fb.group({
      name: [null, Validators.required],
      text: [null, Validators.required]
    });
  }

  get name() {return this.createTextForm.get('name')}
  get text() {return this.createTextForm.get('text')}

  saveMyText() {
    this.myTextService.save({
        name: this.name.value,
        text: this.textToolService.wordWrap(this.text.value, 150), 
        userId: localStorage.getItem('userId')
      }).subscribe(
        s => this.actionForSuccess(JSON.stringify(s)),
        e => this.actionForError(e),
        () => this.router.navigate(['lessons/my-text'])
      )
  }

  private actionForError(err) {
    console.log(err);
  }

  getObjLocal<T>(key: string): T {
    return JSON.parse(localStorage.getItem(key));
  }

  private actionForSuccess(s) {
    localStorage.setItem('myText', s);
    console.log('Succesful');
  }
}
