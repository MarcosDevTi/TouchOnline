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

const routes: Routes = [
  {path: '', component: HomeComponent},
  // {path: 'app', loadChildren: './pages/application/application.module#ApplicationModule'},
  // {path: 'lessons', loadChildren: './pages/lessons/lessons.module#LessonsModule'},
  {path: 'app/:id', component: ApplicationComponent},
  {path: 'lessons/beginner', component: BeginnerListComponent},
  {path: 'lessons/basic', component: BasicListComponent},
  {path: 'lessons/intermediate', component: IntermediateListComponent},
  {path: 'lessons/advanced', component: AdvancedListComponent},
  {path: 'lessons/create-lesson', component: CreateLessonComponent},
  {path: 'lessons/my-text', component: MyTextListComponent},
  {path: 'auth', loadChildren: './pages/auth/auth.module#AuthModule'},
  {path: 'management', loadChildren: './pages/management/management.module#ManagementModule'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
