import { TestBed } from '@angular/core/testing';

import { SegPerfilService } from './seg-perfil';

describe('SegPerfil', () => {
  let service: SegPerfilService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegPerfilService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
