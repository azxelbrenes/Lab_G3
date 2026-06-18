import { TestBed } from '@angular/core/testing';

import { Categorium } from './categorium';

describe('Categorium', () => {
  let service: Categorium;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Categorium);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
