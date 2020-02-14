import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MyTextService } from '../my-text.service';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { TextToolService } from 'src/app/shared/text-tool.service';

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
    private textToolService: TextToolService
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
        text: this.textToolService.wordWrap(this.text.value, 160), 
        userId: localStorage.getItem('userId')
      }).subscribe(
        s => this.actionForSuccess(),
        e => this.actionForError(e)
      )
  }

  private actionForError(err) {
    console.log(err);
  }

  private actionForSuccess() {
    this.router.navigate(['lessons/my-text'])
    localStorage.removeItem('myText');
    console.log('Succesful');
  }
}
