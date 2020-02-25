import { Component, OnInit } from '@angular/core';
import { SendMessageService } from '../../auth/send-message/shared/send-message.service';
import { MessageForSend } from '../../auth/send-message/shared/message-for-send';
import { Router } from '@angular/router';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  messages: MessageForSend[] = [];
  constructor(private sendMessageService: SendMessageService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getMessages();
  }

  getMessages() {
    return this.sendMessageService.getMessages().subscribe((_: MessageForSend[]) => {
      this.messages = _;
    },
      error => console.log(error)
    );

  }

}
