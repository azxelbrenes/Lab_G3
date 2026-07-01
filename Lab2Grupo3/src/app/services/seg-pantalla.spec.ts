import { TestBed } from '@angular/core/testing';

import { SegPantallaService } from './seg-pantalla';

describe('SegPantalla', () => {
  let service: SegPantallaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegPantallaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
