import { TestBed } from '@angular/core/testing';

import { SegPantalla } from './seg-pantalla';

describe('SegPantalla', () => {
  let service: SegPantalla;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegPantalla);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
