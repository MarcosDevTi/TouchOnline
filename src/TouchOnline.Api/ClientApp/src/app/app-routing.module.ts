import { HomeComponent } from './pages/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateLessonComponent } from './pages/lessons/create-lesson/create-lesson.component';
import { BeginnerListComponent } from './pages/lessons/beginner-list/beginner-list.component';
import { BasicListComponent } from './pages/lessons/basic-list/basic-list.component';
import { IntermediateListComponent } from './pages/lessons/intermediate-list/intermediate-list.component';
import { AdvancedListComponent } from './pages/lessons/advanced-list/advanced-list.component';
import { MyTextListComponent } from './pages/lessons/my-text-list/my-text-list.component';
import { ApplicationComponent } from './pages/application/application/application.component';
import { SendMessageComponent } from './pages/auth/send-message/send-message.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { KeyboardManagementComponent } from './pages/management/keyboard-management/keyboard-management.component';
import { EditKeyboardComponent } from './pages/management/keyboard-management/edit-keyboard/edit-keyboard.component';
import { RegisterLocalListComponent } from './pages/management/register-local-list/register-local-list.component';
import { TrackingsComponent } from './pages/management/trackings/trackings.component';
import { UserListComponent } from './pages/management/user/user-list/user-list.component';
import { MessageListComponent } from './pages/management/message-list/message-list.component';
import { SendMessageSuccessComponent } from './pages/auth/send-message/send-message-success/send-message-success.component';
import { MyTextListManagementComponent } from './pages/lessons/my-text-list/my-text-list-management/my-text-list-management.component';
import { EditLessonComponent } from './pages/lessons/my-text-list/my-text-list-management/edit-lesson/edit-lesson.component';
import { CountsComponent } from './pages/management/counts/counts.component';
import { LessonListComponent } from './pages/management/lesson-text/lesson-list/lesson-list.component';
import { CreateLessonTextComponent } from './pages/management/lesson-text/create-lesson-text/create-lesson-text.component';
import { ResultListComponent } from './pages/management/result-list/result-list.component';
import { TesterComponent } from './pages/management/trackings/tester/tester.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'app/:id', component: ApplicationComponent },
  { path: 'lessons/beginner', component: BeginnerListComponent },
  { path: ':lang/lessons/beginner', component: BeginnerListComponent },
  { path: 'lessons/basic', component: BasicListComponent },
  { path: 'lessons/intermediate', component: IntermediateListComponent },
  { path: 'lessons/advanced', component: AdvancedListComponent },
  { path: 'lessons/create-lesson', component: CreateLessonComponent },
  { path: 'lessons/my-text', component: MyTextListComponent },
  { path: 'lessons/my-text-management', component: MyTextListManagementComponent },
  { path: 'lessons/my-text-management/:id/edit', component: EditLessonComponent },
  { path: 'auth/register', component: RegisterComponent },
  { path: 'auth/send-message', component: SendMessageComponent },
  { path: 'auth/send-message-success', component: SendMessageSuccessComponent },

  { path: ':lang', component: HomeComponent },
  { path: ':lang/app/:id', component: ApplicationComponent },
  { path: ':lang/app/:id/:level', component: ApplicationComponent },
  { path: ':lang/lessons/beginner', component: BeginnerListComponent },
  { path: ':lang/:lang/lessons/beginner', component: BeginnerListComponent },
  { path: ':lang/lessons/basic', component: BasicListComponent },
  { path: ':lang/lessons/intermediate', component: IntermediateListComponent },
  { path: ':lang/lessons/advanced', component: AdvancedListComponent },
  { path: ':lang/lessons/create-lesson', component: CreateLessonComponent },
  { path: ':lang/lessons/my-text', component: MyTextListComponent },
  { path: ':lang/lessons/my-text-management', component: MyTextListManagementComponent },
  { path: ':lang/lessons/my-text-management/:id/edit', component: EditLessonComponent },
  { path: ':lang/auth/register', component: RegisterComponent },
  { path: ':lang/auth/send-message', component: SendMessageComponent },
  { path: ':lang/auth/send-message-success', component: SendMessageSuccessComponent },

  { path: 'management/keyboard', component: KeyboardManagementComponent },
  { path: 'management/keyboard/:id/edit', component: EditKeyboardComponent },
  { path: 'management/register-management-list', component: RegisterLocalListComponent },
  { path: 'management/tracking', component: TrackingsComponent },
  { path: 'management/users', component: UserListComponent },
  { path: 'management/message-list', component: MessageListComponent },
  { path: 'management/counts', component: CountsComponent },
  { path: 'management/lessons', component: LessonListComponent },
  { path: 'management/lessons/create', component: CreateLessonTextComponent },
  { path: 'management/lessons/:id/edit', component: CreateLessonTextComponent },
  { path: 'management/result-management', component: ResultListComponent },
  { path: 'management/tester', component: TesterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
