import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DateAdminComponent } from './date-admin.component';

describe('DateAdminComponent', () => {
  let component: DateAdminComponent;
  let fixture: ComponentFixture<DateAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DateAdminComponent]
    });
    fixture = TestBed.createComponent(DateAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
