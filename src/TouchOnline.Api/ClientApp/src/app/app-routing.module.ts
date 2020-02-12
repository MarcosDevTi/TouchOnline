import { HomeComponent } from './pages/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'app', loadChildren: './pages/application/application.module#ApplicationModule'},
  {path: 'lessons', loadChildren: './pages/lessons/lessons.module#LessonsModule'},
  {path: 'auth', loadChildren: './pages/auth/auth.module#AuthModule'},
  {path: 'tracking', loadChildren: './pages/tracking/tracking.module#TrackingModule'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
