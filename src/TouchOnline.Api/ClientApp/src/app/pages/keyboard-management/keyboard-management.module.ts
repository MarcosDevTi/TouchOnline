import { KeyboardManagementRoutingModule } from "./keyboard-manager-routing.module";
import { SharedModule } from "src/app/shared/shared.module";
import { NgModule } from "@angular/core";
import { EditKeyboardComponent } from "./edit-keyboard/edit-keyboard.component";
import { KeyboardManagementComponent } from "./keyboard-management.component";

@NgModule({
    declarations: [
     EditKeyboardComponent,
     KeyboardManagementComponent
    ],
    imports: [
      SharedModule,
      KeyboardManagementRoutingModule
    ],
    providers: [
    ]
  })
  export class KeyboardManagerModule {
      
  }