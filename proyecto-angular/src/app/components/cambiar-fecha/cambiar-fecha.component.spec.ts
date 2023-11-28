import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CambiarFechaComponent } from './cambiar-fecha.component';

describe('CambiarFechaComponent', () => {
  let component: CambiarFechaComponent;
  let fixture: ComponentFixture<CambiarFechaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CambiarFechaComponent]
    });
    fixture = TestBed.createComponent(CambiarFechaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
