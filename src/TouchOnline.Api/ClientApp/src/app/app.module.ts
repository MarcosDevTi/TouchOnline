import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { MatButtonModule, MatTableModule, MatSelectModule, MatDialogModule, MatMenuModule, MatDividerModule, MatListModule, 
  MatCardModule, MatChipsModule, MatGridListModule, MatInputModule, MatFormFieldModule, MatSlideToggleModule, 
  MatDatepickerModule, MatNativeDateModule, MatProgressBarModule
} from '@angular/material';
import { MatIconModule } from '@angular/material/icon';
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
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
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
import { AutoFocusDirective } from './shared/auto-focus.directive';
import { MessageListComponent } from './pages/management/message-list/message-list.component';
import { SendMessageSuccessComponent } from './pages/auth/send-message/send-message-success/send-message-success.component';
import { MyTextListManagementComponent } from './pages/lessons/my-text-list/my-text-list-management/my-text-list-management.component';
import { EditLessonComponent } from './pages/lessons/my-text-list/my-text-list-management/edit-lesson/edit-lesson.component';
import { CountsComponent } from './pages/management/counts/counts.component';
import {TranslateModule, TranslateLoader} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './core/navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { LessonListComponent } from './pages/management/lesson-text/lesson-list/lesson-list.component';
import { CreateLessonTextComponent } from './pages/management/lesson-text/create-lesson-text/create-lesson-text.component';
import { ResultListComponent } from './pages/management/result-list/result-list.component';
import { EditResultManagementComponent } from './pages/management/result-list/edit-result-management/edit-result-management.component';
import { VisitorsPerDayComponent } from './pages/management/trackings/visitors-per-day/visitors-per-day.component';
import { TesterComponent } from './pages/management/trackings/tester/tester.component';
import { AdsComponent } from './ads/ads.component';

export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}

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
    TrackingDetailsComponent,
    AutoFocusDirective,
    MessageListComponent,
    SendMessageSuccessComponent,
    MyTextListManagementComponent,
    EditLessonComponent,
    CountsComponent,
    LessonListComponent,
    CreateLessonTextComponent,
    ResultListComponent,
    EditResultManagementComponent,
    NavbarComponent,
    VisitorsPerDayComponent,
    TesterComponent,
    AdsComponent,
  ],
  imports: [
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
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
    MatDatepickerModule,
    MatNativeDateModule,
    MatProgressBarModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [TrackingService, ApplicationService, VisitorService, LessonService],
  bootstrap: [AppComponent],
  entryComponents: [
    ResultComponent,
    TrackingDetailsComponent,
    AdsComponent
  ],
})
export class AppModule {

}
