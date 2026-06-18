import { TestBed } from '@angular/core/testing';

import { TipoCedula } from './tipo-cedula';

describe('TipoCedula', () => {
  let service: TipoCedula;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoCedula);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
