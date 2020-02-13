/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MyTextService } from './my-text.service';

describe('Service: MyText', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MyTextService]
    });
  });

  it('should ...', inject([MyTextService], (service: MyTextService) => {
    expect(service).toBeTruthy();
  }));
});
