import { CoreModule } from './core/core.module';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { MatButtonModule } from '@angular/material';
import {MatIconModule} from '@angular/material/icon';
import { TrackingService } from './pages/tracking/shared/tracking.service';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    CoreModule,
    AppRoutingModule,
    MatButtonModule,
    MatIconModule,
  ],
  providers: [TrackingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
