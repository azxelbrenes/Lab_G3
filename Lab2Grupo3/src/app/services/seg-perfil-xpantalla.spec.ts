import { TestBed } from '@angular/core/testing';

import { SegPerfilXpantallaService } from './seg-perfil-xpantalla';

describe('SegPerfilXpantalla', () => {
  let service: SegPerfilXpantallaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SegPerfilXpantallaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
