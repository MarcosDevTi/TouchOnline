import { CoreModule } from './core/core.module';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { MatButtonModule, MatTableModule } from '@angular/material';
import {MatIconModule} from '@angular/material/icon';
import { TrackingService } from './pages/tracking/shared/tracking.service';
import { AppComponent } from './app.component';
import { VisitorService } from './shared/visitor.service';
import { ApplicationService } from './pages/application/application.service';
import { RegisterLocalListComponent } from './pages/management/register-local-list/register-local-list.component';

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
    MatTableModule,
  ],
  providers: [TrackingService, ApplicationService, VisitorService],
  bootstrap: [AppComponent]
})
export class AppModule {
  
 }
