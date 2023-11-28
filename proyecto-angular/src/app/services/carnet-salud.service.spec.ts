import { TestBed } from '@angular/core/testing';

import { CarnetSaludService } from './carnet-salud.service';

describe('CarnetSaludService', () => {
  let service: CarnetSaludService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarnetSaludService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
