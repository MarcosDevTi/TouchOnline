import { Component, OnInit } from '@angular/core';
import { SendMessageService } from '../../auth/send-message/shared/send-message.service';
import { MessageForSend } from '../../auth/send-message/shared/message-for-send';
import { Router } from '@angular/router';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class MessageListComponent implements OnInit {
  columnsToDisplay = ['name', 'email'];
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
