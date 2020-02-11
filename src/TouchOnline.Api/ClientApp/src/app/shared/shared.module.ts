import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import {
  MatDialogModule, MatMenuModule, MatDividerModule, MatCardModule,
  MatListModule, MatFormFieldModule, MatInputModule
} from '@angular/material';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatGridListModule } from '@angular/material/grid-list';

import { TimerFormat } from '../pages/lessons/shared/timer-format.pipe';
import { RouterModule } from '@angular/router';
import { LessonService } from '../pages/lessons/lesson.service';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxIndexedDBModule, DBConfig } from 'ngx-indexed-db';

const dbConfig: DBConfig = {
  name: 'TouchOnline2',
  version: 1,
  objectStoresMeta: [
    {
      store: 'lecon',
      storeConfig: { keyPath: 'id', autoIncrement: true },
      storeSchema: [
        { name: 'idLesson', keypath: 'idLesson', options: { unique: true } },
        { name: 'name', keypath: 'name', options: { unique: false } },
        { name: 'lessonText', keypath: 'lessonText', options: { unique: false } },
        { name: 'level', keypath: 'level', options: { unique: false } },
      ]
    },
    {
      store: 'result',
      storeConfig: { keyPath: 'id', autoIncrement: true },
      storeSchema: [
        { name: 'idLesson', keypath: 'idLesson', options: { unique: true } },
        { name: 'precision', keypath: 'precision', options: { unique: false } },
        { name: 'ppm', keypath: 'ppm', options: { unique: false } },
        { name: 'stars', keypath: 'stars', options: { unique: false } },
        { name: 'time', keypath: 'time', options: { unique: false } },
      ]
    }
  ]
};

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    NgxIndexedDBModule.forRoot(dbConfig),
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
