import { SeoListComponent } from './shared/seo-list/seo-list.component';
import { NgModule } from '@angular/core';
import { LessonsRoutingModule } from './lessons-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AdvancedListComponent } from './advanced-list/advanced-list.component';
import { BasicListComponent } from './basic-list/basic-list.component';
import { BeginnerListComponent } from './beginner-list/beginner-list.component';
import { IntermediateListComponent } from './intermediate-list/intermediate-list.component';
import { LeftMenuComponent } from './shared/left-menu/left-menu.component';
import { StarsItemComponent } from './shared/stars-item/stars-item.component';
import { CardResultComponent } from './shared/card-result/card-result.component';
import { CreateLessonComponent } from './create-lesson/create-lesson.component';
import { MyTextListComponent } from './my-text-list/my-text-list.component';


@NgModule({
  declarations: [
    AdvancedListComponent,
    BasicListComponent,
    BeginnerListComponent,
    IntermediateListComponent,
    LeftMenuComponent,
    StarsItemComponent,
    CardResultComponent,
    SeoListComponent,
    CreateLessonComponent,
    MyTextListComponent
  ],
  imports: [
    SharedModule,
    LessonsRoutingModule
  ],
  providers: [
  ]
})
export class LessonsModule { }
