import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HipUpdateComponent } from './hip-update.component';

describe('HipUpdateComponent', () => {
  let component: HipUpdateComponent;
  let fixture: ComponentFixture<HipUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HipUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HipUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
