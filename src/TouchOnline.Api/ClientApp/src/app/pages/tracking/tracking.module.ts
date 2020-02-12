import { NgModule } from '@angular/core';

import { TrackingRoutingModule } from './tracking-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TrackingsComponent } from './trackings/trackings.component';


@NgModule({
  declarations: [TrackingsComponent],
  imports: [
    SharedModule,
    TrackingRoutingModule
  ]
})
export class TrackingModule { }
