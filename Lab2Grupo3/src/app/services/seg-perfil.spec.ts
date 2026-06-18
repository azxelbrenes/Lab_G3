import { TestBed } from '@angular/core/testing';

import { SegPerfil } from './seg-perfil';

describe('SegPerfil', () => {
  let service: SegPerfil;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegPerfil);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
