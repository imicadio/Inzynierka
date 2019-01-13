import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingUserComponent } from './training-user.component';

describe('TrainingUserComponent', () => {
  let component: TrainingUserComponent;
  let fixture: ComponentFixture<TrainingUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainingUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainingUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
