import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingAddUserComponent } from './training-add-user.component';

describe('TrainingAddUserComponent', () => {
  let component: TrainingAddUserComponent;
  let fixture: ComponentFixture<TrainingAddUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainingAddUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainingAddUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
