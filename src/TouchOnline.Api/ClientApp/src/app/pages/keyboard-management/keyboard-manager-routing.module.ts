import { EditKeyboardComponent } from "./edit-keyboard/edit-keyboard.component";
import { KeyboardManagementComponent } from "./keyboard-management.component";
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from "@angular/core";

const routes: Routes = [
    { path: '', component: KeyboardManagementComponent },
    { path: ':id/edit', component: EditKeyboardComponent }
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class KeyboardManagementRoutingModule {

}