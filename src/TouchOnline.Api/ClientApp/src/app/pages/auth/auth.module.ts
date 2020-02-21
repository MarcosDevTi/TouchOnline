import { NgModule } from '@angular/core';

import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RegisterComponent } from './register/register.component';
import { MatFormFieldModule } from '@angular/material';
import { HomeComponent } from '../home/home.component';
import { SendMessageComponent } from './send-message/send-message.component';

@NgModule({
  declarations: [
    RegisterComponent,
    SendMessageComponent
  ],
  imports: [
    SharedModule,
    AuthRoutingModule,
  ]
})
export class AuthModule { }
