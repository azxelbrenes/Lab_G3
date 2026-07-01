import { TestBed } from '@angular/core/testing';

import { CategoriumService } from './categorium';

describe('CategoriumService', () => {
  let service: CategoriumService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoriumService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});