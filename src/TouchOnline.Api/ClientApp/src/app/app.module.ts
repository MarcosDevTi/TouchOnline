import { CoreModule } from './core/core.module';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { MatButtonModule, MatTableModule, MatSelectModule, MatDialogModule, MatMenuModule, MatDividerModule, MatListModule, MatCardModule, MatChipsModule, MatGridListModule, MatInputModule, MatFormFieldModule, MatSlideToggleModule } from '@angular/material';
import {MatIconModule} from '@angular/material/icon';
import { TrackingService } from './pages/tracking/shared/tracking.service';
import { AppComponent } from './app.component';
import { VisitorService } from './shared/visitor.service';
import { ApplicationService } from './pages/application/application.service';
import { AdvancedListComponent } from './pages/lessons/advanced-list/advanced-list.component';
import { BasicListComponent } from './pages/lessons/basic-list/basic-list.component';
import { BeginnerListComponent } from './pages/lessons/beginner-list/beginner-list.component';
import { IntermediateListComponent } from './pages/lessons/intermediate-list/intermediate-list.component';
import { LeftMenuComponent } from './pages/lessons/shared/left-menu/left-menu.component';
import { StarsItemComponent } from './pages/lessons/shared/stars-item/stars-item.component';
import { CardResultComponent } from './pages/lessons/shared/card-result/card-result.component';
import { SeoListComponent } from './pages/lessons/shared/seo-list/seo-list.component';
import { CreateLessonComponent } from './pages/lessons/create-lesson/create-lesson.component';
import { MyTextListComponent } from './pages/lessons/my-text-list/my-text-list.component';
import { MyTextsComponent } from './pages/lessons/my-texts/my-texts.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { LessonService } from './pages/lessons/lesson.service';
import { ApplicationComponent } from './pages/application/application/application.component';
import { DisplayAppComponent } from './pages/application/application/displayApp/displayApp.component';
import { KeyboardComponent } from './pages/application/application/keyboard/keyboard.component';
import { ResultComponent } from './pages/application/application/result/result.component';
import { LeftHandComponent } from './pages/application/application/keyboard/left-hand/left-hand.component';
import { RightHandComponent } from './pages/application/application/keyboard/right-hand/right-hand.component';
import { TimerFormat } from './pages/lessons/shared/timer-format.pipe';
import { SendMessageComponent } from './pages/auth/send-message/send-message.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { TrackingsComponent } from './pages/management/trackings/trackings.component';
import { RegisterLocalListComponent } from './pages/management/register-local-list/register-local-list.component';
import { KeyboardManagementComponent } from './pages/management/keyboard-management/keyboard-management.component';
import { EditKeyboardComponent } from './pages/management/keyboard-management/edit-keyboard/edit-keyboard.component';
import { UserListComponent } from './pages/management/user/user-list/user-list.component';
import { TrackingDetailsComponent } from './pages/management/trackings/tracking-details/tracking-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdvancedListComponent,
    BasicListComponent,
    BeginnerListComponent,
    IntermediateListComponent,
    LeftMenuComponent,
    StarsItemComponent,
    CardResultComponent,
    SeoListComponent,
    CreateLessonComponent,
    MyTextListComponent,
    MyTextsComponent,
    ApplicationComponent,
    DisplayAppComponent,
    KeyboardComponent,
    ResultComponent,
    LeftHandComponent,
    RightHandComponent,
    RegisterComponent,
    SendMessageComponent,
    EditKeyboardComponent,
     KeyboardManagementComponent,
     RegisterLocalListComponent,
     TrackingsComponent,
    TimerFormat,
    UserListComponent,
    TrackingDetailsComponent
  ],
  imports: [
    CoreModule,
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogModule,
    MatMenuModule,
    MatDividerModule,
    MatListModule,
    MatCardModule,
    MatIconModule,
    MatChipsModule,
    MatGridListModule,
    MatInputModule,
    MatFormFieldModule,
    MatTableModule,
    MatSlideToggleModule,
  ],
  providers: [TrackingService, ApplicationService, VisitorService, LessonService],
  bootstrap: [AppComponent],
  entryComponents: [
    ResultComponent,
    TrackingDetailsComponent
  ],
})
export class AppModule {
  
 }
