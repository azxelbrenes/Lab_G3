import { TestBed } from '@angular/core/testing';

import { SegUsuario } from './seg-usuario';

describe('SegUsuario', () => {
  let service: SegUsuario;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegUsuario);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
