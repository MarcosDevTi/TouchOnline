import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { KeyboardServiceService } from '../shared/keyboard-service.service';
import { switchMap } from 'rxjs/operators';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-edit-keyboard',
  templateUrl: './edit-keyboard.component.html',
  styleUrls: ['./edit-keyboard.component.css']
})
export class EditKeyboardComponent implements OnInit {
  keyboardForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private keyboardServiceService: KeyboardServiceService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.buildKeyboardForm();
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.keyboardServiceService.getKeyboardByIdForUpdate(params.get('id')))
    ).subscribe(k => 
     this.keyboardForm.patchValue(k))
  }

  buildKeyboardForm() {
    this.fb.group({
      id: [null],
      code: [null],
      name: [null],
      languageCode: [null],
      status: [null],
    })
  }

  submitKeyboardForm() {
    
  }

}
