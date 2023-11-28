import { TestBed } from '@angular/core/testing';

import { PeriodoActualizacionService } from './periodo-actualizacion.service';

describe('PeriodoActualizacionService', () => {
  let service: PeriodoActualizacionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PeriodoActualizacionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
