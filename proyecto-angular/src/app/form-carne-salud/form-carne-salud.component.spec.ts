import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormCarneSaludComponent } from './form-carne-salud.component';

describe('FormCarneSaludComponent', () => {
  let component: FormCarneSaludComponent;
  let fixture: ComponentFixture<FormCarneSaludComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormCarneSaludComponent]
    });
    fixture = TestBed.createComponent(FormCarneSaludComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
