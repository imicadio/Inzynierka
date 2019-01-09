import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HipAddComponent } from './hip-add.component';

describe('HipAddComponent', () => {
  let component: HipAddComponent;
  let fixture: ComponentFixture<HipAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HipAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HipAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
