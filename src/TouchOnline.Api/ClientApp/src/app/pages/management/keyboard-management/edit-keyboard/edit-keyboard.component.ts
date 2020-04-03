import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { KeyboardServiceService } from '../shared/keyboard-service.service';
import { switchMap } from 'rxjs/operators';
import { FormGroup, FormBuilder } from '@angular/forms';
import { KeyboardForUpdate } from '../shared/keyboard-for-update';

@Component({
  selector: 'app-edit-keyboard',
  templateUrl: './edit-keyboard.component.html',
  styleUrls: ['./edit-keyboard.component.css']
})
export class EditKeyboardComponent implements OnInit {
  keyboardForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private keyboardServiceService: KeyboardServiceService,
    public fb: FormBuilder) { }

  ngOnInit() {
    this.buildKeyboardForm();
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.keyboardServiceService.getKeyboardByIdForUpdate(params.get('id')))
    ).subscribe(k => {
      console.log('k', k)
        this.keyboardForm.patchValue(k)

    })
  }

  buildKeyboardForm() {
    this.keyboardForm = this.fb.group({
      id: [null],
      code: [null],
      name: [null],
      languageCode: [null],
      status: [null],
      keycodesBeginners: [null]
    })
  }

  submitKeyboardForm() {
    this.keyboardServiceService.updateKeyboard(
      KeyboardForUpdate.fromJson(this.keyboardForm.value))
      .subscribe(
      _ => this.actionsForSuccess(_),
      error => this.actionsForError(error)
      );
  }

  protected actionsForSuccess(resource){
   console.log('ok');
   this.router.navigate(['/management'])
  }

  protected actionsForError(error){
    console.log('error', error)
  }

}
