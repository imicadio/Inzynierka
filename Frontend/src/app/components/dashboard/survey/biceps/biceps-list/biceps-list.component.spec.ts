import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BicepsListComponent } from './biceps-list.component';

describe('BicepsListComponent', () => {
  let component: BicepsListComponent;
  let fixture: ComponentFixture<BicepsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BicepsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BicepsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
