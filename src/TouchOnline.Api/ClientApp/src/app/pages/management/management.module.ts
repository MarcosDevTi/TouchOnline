import { ManagementRoutingModule } from "./management-routing.module";
import { SharedModule } from "src/app/shared/shared.module";
import { NgModule } from "@angular/core";
import { EditKeyboardComponent } from "./keyboard-management/edit-keyboard/edit-keyboard.component";
import { KeyboardManagementComponent } from "./keyboard-management/keyboard-management.component";
import { RegisterLocalListComponent } from "./register-local-list/register-local-list.component";
import { TrackingsComponent } from './trackings/trackings.component';

@NgModule({
    declarations: [
     EditKeyboardComponent,
     KeyboardManagementComponent,
     RegisterLocalListComponent,
     TrackingsComponent
    ],
    imports: [
      SharedModule,
      ManagementRoutingModule,
      
    ],
    providers: [
    ]
  })
  export class ManagementModule {
      
  }