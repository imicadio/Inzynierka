import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DietUserComponent } from './diet-user.component';

describe('DietUserComponent', () => {
  let component: DietUserComponent;
  let fixture: ComponentFixture<DietUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DietUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DietUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
