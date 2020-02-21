import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { SendMessageComponent } from './send-message/send-message.component';

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path: 'send-message', component: SendMessageComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
