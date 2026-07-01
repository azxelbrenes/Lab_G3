import { TestBed } from '@angular/core/testing';

import { SegUsuarioService } from './seg-usuario';

describe('SegUsuario', () => {
  let service: SegUsuarioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegUsuarioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
