import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalfListComponent1 } from './calf-list.component1';

describe('CalfListComponent1', () => {
  let component: CalfListComponent1;
  let fixture: ComponentFixture<CalfListComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalfListComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalfListComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
