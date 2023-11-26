import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayAllFuncionariosComponent } from './display-all-funcionarios.component';

describe('DisplayAllFuncionariosComponent', () => {
  let component: DisplayAllFuncionariosComponent;
  let fixture: ComponentFixture<DisplayAllFuncionariosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DisplayAllFuncionariosComponent]
    });
    fixture = TestBed.createComponent(DisplayAllFuncionariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
