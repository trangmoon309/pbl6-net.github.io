import { TestBed } from '@angular/core/testing';

import { HreoService } from './hreo.service';

describe('HreoService', () => {
  let service: HreoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HreoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
