import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BicepsListComponent1 } from './biceps-list.component1';

describe('BicepsListComponent1', () => {
  let component: BicepsListComponent1;
  let fixture: ComponentFixture<BicepsListComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BicepsListComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BicepsListComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
