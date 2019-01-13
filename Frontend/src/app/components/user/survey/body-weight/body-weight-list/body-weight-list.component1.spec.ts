import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyWeightListComponent1 } from './body-weight-list.component1';

describe('BodyWeightListComponent1', () => {
  let component: BodyWeightListComponent1;
  let fixture: ComponentFixture<BodyWeightListComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyWeightListComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyWeightListComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
