import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import { MatDialogModule, MatMenuModule, MatDividerModule, MatCardModule, 
  MatListModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import {MatIconModule} from '@angular/material/icon';
import {MatChipsModule} from '@angular/material/chips';
import {MatGridListModule} from '@angular/material/grid-list';

import { TimerFormat } from '../pages/lessons/shared/timer-format.pipe';
import { RouterModule } from '@angular/router';
import { LessonService } from '../pages/lessons/lesson.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,

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
  ],
  declarations: [TimerFormat],
  exports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,

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

    TimerFormat,
  ],
  providers: [LessonService]
})
export class SharedModule { }
