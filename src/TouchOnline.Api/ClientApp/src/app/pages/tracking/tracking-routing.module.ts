import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TrackingsComponent } from './trackings/trackings.component';


const routes: Routes = [
  {path: '', component: TrackingsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrackingRoutingModule { }
