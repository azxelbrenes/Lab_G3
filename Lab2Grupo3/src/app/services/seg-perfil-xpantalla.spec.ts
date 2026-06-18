import { TestBed } from '@angular/core/testing';

import { SegPerfilXpantalla } from './seg-perfil-xpantalla';

describe('SegPerfilXpantalla', () => {
  let service: SegPerfilXpantalla;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegPerfilXpantalla);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
