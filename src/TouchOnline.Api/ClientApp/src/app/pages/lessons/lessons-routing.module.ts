import { BeginnerListComponent } from './beginner-list/beginner-list.component';
import { IntermediateListComponent } from './intermediate-list/intermediate-list.component';
import { BasicListComponent } from './basic-list/basic-list.component';
import { AdvancedListComponent } from './advanced-list/advanced-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateLessonComponent } from './create-lesson/create-lesson.component';

const routes: Routes = [
  {path: 'beginner', component: BeginnerListComponent},
  {path: 'basic', component: BasicListComponent},
  {path: 'intermediate', component: IntermediateListComponent},
  {path: 'advanced', component: AdvancedListComponent},
  {path: 'create-lesson', component: CreateLessonComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LessonsRoutingModule { }
