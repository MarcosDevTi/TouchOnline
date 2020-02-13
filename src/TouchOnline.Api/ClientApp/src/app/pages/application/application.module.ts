import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';

import { ApplicationRoutingModule } from './application-routing.module';
import { ApplicationComponent } from './application/application.component';
import { DisplayAppComponent } from './application/displayApp/displayApp.component';
import { LessonService } from '../lessons/lesson.service';
import { KeyboardComponent } from './application/keyboard/keyboard.component';
import { ResultComponent } from './application/result/result.component';
import { ApplicationService } from './application.service';
@NgModule({
  declarations: [
    ApplicationComponent,
    DisplayAppComponent,
    KeyboardComponent,
    ResultComponent
  ],
  imports: [
    SharedModule,
    ApplicationRoutingModule,
  ],
  providers: [
    LessonService,
    ApplicationService
  ],
  entryComponents: [
    ResultComponent
  ],
})
export class ApplicationModule { }
