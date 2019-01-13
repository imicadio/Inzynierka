import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HipListComponent1 } from './hip-list.component1';

describe('HipListComponent1', () => {
  let component: HipListComponent1;
  let fixture: ComponentFixture<HipListComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HipListComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HipListComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
