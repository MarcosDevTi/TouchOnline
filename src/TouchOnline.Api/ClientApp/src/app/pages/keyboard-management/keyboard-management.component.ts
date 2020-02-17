import { Component, OnInit } from '@angular/core';
import { KeyboardServiceService } from './shared/keyboard-service.service';
import { KeyboardForUpdate } from './shared/keyboard-for-update';

@Component({
  selector: 'app-keyboard-management',
  templateUrl: './keyboard-management.component.html',
  styleUrls: ['./keyboard-management.component.css']
})
export class KeyboardManagementComponent implements OnInit {
  displayedColumns: string[] = ['id', 'code', 'name', 'languageCode', 'status', 'actions'];
  keyboardsManagement: KeyboardForUpdate[] = [];
  constructor(private keyboardServiceService: KeyboardServiceService) { }

  ngOnInit() {
    this.keyboardServiceService.getKeyboardsManagement().subscribe(keyboard =>
      this.keyboardsManagement = keyboard
    )
  }

  editKeyboard(id) {
    alert(id);
  }
}
