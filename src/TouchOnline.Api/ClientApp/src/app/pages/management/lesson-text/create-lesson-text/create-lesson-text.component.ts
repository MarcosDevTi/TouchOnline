import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LessonTextService } from '../shared/lesson-text.service';
import { LessonText } from '../shared/lesson-text';

@Component({
  selector: 'app-create-lesson-text',
  templateUrl: './create-lesson-text.component.html',
  styleUrls: ['./create-lesson-text.component.css']
})
export class CreateLessonTextComponent implements OnInit {
  classTextInput = 'text-area-input';
  basicSize = true;
  editMode = false;
  createTextForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    protected route: ActivatedRoute,
    private lessonTextService: LessonTextService
    ) { }

  ngOnInit() {
    var idQueryString = this.route.snapshot.params.id;

    console.log('idQueryString', idQueryString)
    this.buildCreateTextForm();
    this.level.valueChanges.subscribe(_ => {
      if(_ === '1'){
        this.basicSize = true;
      } else {
        this.basicSize = false;
      }
    })

    if(idQueryString){
      this.editMode = true;
      this.lessonTextService.getLessonTextById(idQueryString).subscribe(_ => 
        this.createTextForm.patchValue(_));
    }
  }

  buildCreateTextForm() {
    this.createTextForm = this.fb.group({
      name: [null, Validators.required],
      text: [null, Validators.required],
      textLine2: [null],
      textLine3: [null],
      textLine4: [null],
      textLine5: [null],
      textLine6: [null],
      textLine7: [null],
      level: ['1'],
      language: ['0'],
      order: [null]
    });
  }

  get name() {return this.createTextForm.get('name')}
  get text() {return this.createTextForm.get('text')}
  get level() {return this.createTextForm.get('level')}
  get language() {return this.createTextForm.get('language')}
  get order() {return this.createTextForm.get('order')}


  save() {
    if(this.editMode){
      let lessonForUpdate = LessonText.fromJson(this.createTextForm.value);
      lessonForUpdate.id = this.route.snapshot.params.id;
      this.lessonTextService.updateLesson(lessonForUpdate).subscribe(
        s => this.actionForSuccess(JSON.stringify(s)),
        e => this.actionForError(e),
        () => this.router.navigate(['/management/lessons'])
      )
    } else {
       this.lessonTextService.createLesson(LessonText.fromJson(this.createTextForm.value)).subscribe(
        s => this.actionForSuccess(JSON.stringify(s)),
        e => this.actionForError(e),
        () => this.router.navigate(['/management/lessons'])
      )
    }
   
  }

  private actionForError(err) {
    console.log(err);
  }

  getObjLocal<T>(key: string): T {
    return JSON.parse(localStorage.getItem(key));
  }

  private actionForSuccess(s) {
    console.log('success remove items')
    localStorage.removeItem('level_4_language_0');
    localStorage.removeItem('level_4_language_pt');
    localStorage.removeItem('level_4_language_fr');
    localStorage.removeItem('level_4_language_en');
    
    console.log('Succesful');
  }
}
