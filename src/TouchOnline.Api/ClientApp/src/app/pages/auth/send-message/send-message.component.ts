import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-send-message',
  templateUrl: './send-message.component.html',
  styleUrls: ['./send-message.component.css']
})
export class SendMessageComponent implements OnInit {
  messageForm: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.send();
  }

  send() {
    this.messageForm = this.fb.group({
      //userId: null,
      name: [null, Validators.required],
      email: [null, Validators.required],
      text: [null, Validators.required],
    });
  }

}
