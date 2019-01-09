import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyWeightUpdateComponent } from './body-weight-update.component';

describe('BodyWeightUpdateComponent', () => {
  let component: BodyWeightUpdateComponent;
  let fixture: ComponentFixture<BodyWeightUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyWeightUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyWeightUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
