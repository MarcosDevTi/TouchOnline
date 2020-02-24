import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SendMessageService } from './shared/send-message.service';
import { MessageForSend } from './shared/message-for-send';

@Component({
  selector: 'app-send-message',
  templateUrl: './send-message.component.html',
  styleUrls: ['./send-message.component.css']
})
export class SendMessageComponent implements OnInit {
  messageForm: FormGroup;
  constructor(private fb: FormBuilder, private sendMessageService: SendMessageService) { }

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.messageForm = this.fb.group({
      userId: [localStorage.getItem('userId')],
      name: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      text: [null, Validators.required],
    });
  }

  sendMessage() {
    this.sendMessageService.sendMessage(MessageForSend.fromJson(this.messageForm.value))
      .subscribe(_ => console.log('message sended', _));
  }

}
