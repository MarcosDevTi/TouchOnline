import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { MatMenuModule, MatButtonModule} from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,

    MatMenuModule,
    MatButtonModule,
  ],
  declarations: [NavbarComponent],
  exports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    NavbarComponent,
  ]
})
export class CoreModule { }
