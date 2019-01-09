import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HipListComponent } from './hip-list.component';

describe('HipListComponent', () => {
  let component: HipListComponent;
  let fixture: ComponentFixture<HipListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HipListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HipListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
