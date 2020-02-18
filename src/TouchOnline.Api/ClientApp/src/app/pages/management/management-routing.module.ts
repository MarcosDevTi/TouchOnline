import { EditKeyboardComponent } from "./keyboard-management/edit-keyboard/edit-keyboard.component";
import { KeyboardManagementComponent } from "./keyboard-management/keyboard-management.component";
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from "@angular/core";
import { RegisterLocalListComponent } from "./register-local-list/register-local-list.component";
import { TrackingsComponent } from "./trackings/trackings.component";

const routes: Routes = [
    { path: '', component: KeyboardManagementComponent },
    { path: ':id/edit', component: EditKeyboardComponent },
    { path: 'register-management-list', component: RegisterLocalListComponent},
    { path: 'tracking', component: TrackingsComponent}
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ManagementRoutingModule {

}