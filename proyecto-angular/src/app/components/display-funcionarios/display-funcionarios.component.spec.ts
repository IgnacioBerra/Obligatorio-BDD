import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayFuncionariosComponent } from './display-funcionarios.component';

describe('DisplayFuncionariosComponent', () => {
  let component: DisplayFuncionariosComponent;
  let fixture: ComponentFixture<DisplayFuncionariosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DisplayFuncionariosComponent]
    });
    fixture = TestBed.createComponent(DisplayFuncionariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
