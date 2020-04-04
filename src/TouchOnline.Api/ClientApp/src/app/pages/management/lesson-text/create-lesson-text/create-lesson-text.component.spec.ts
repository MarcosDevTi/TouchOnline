import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLessonTextComponent } from './create-lesson-text.component';

describe('CreateLessonTextComponent', () => {
  let component: CreateLessonTextComponent;
  let fixture: ComponentFixture<CreateLessonTextComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateLessonTextComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateLessonTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
