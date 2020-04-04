import { TestBed } from '@angular/core/testing';

import { LessonTextService } from './lesson-text.service';

describe('LessonTextService', () => {
  let service: LessonTextService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LessonTextService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
