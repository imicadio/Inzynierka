import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyFatListComponent1 } from './body-fat-list.component1';

describe('BodyFatListComponent', () => {
  let component: BodyFatListComponent1;
  let fixture: ComponentFixture<BodyFatListComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyFatListComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyFatListComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
