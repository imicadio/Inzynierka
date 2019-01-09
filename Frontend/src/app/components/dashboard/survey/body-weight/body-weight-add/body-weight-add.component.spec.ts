import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyWeightAddComponent } from './body-weight-add.component';

describe('BodyWeightAddComponent', () => {
  let component: BodyWeightAddComponent;
  let fixture: ComponentFixture<BodyWeightAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyWeightAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyWeightAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
