import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThighListComponent1 } from './thigh-list.component1';

describe('ThighListComponent1', () => {
  let component: ThighListComponent1;
  let fixture: ComponentFixture<ThighListComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThighListComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThighListComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
