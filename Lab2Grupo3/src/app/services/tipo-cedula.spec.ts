import { TestBed } from '@angular/core/testing';

import { TipoCedulaService } from './tipo-cedula';

describe('TipoCedula', () => {
  let service: TipoCedulaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoCedulaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
