import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyWeightListComponent } from './body-weight-list.component';

describe('BodyWeightListComponent', () => {
  let component: BodyWeightListComponent;
  let fixture: ComponentFixture<BodyWeightListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyWeightListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyWeightListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
