import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalfUpdateComponent } from './calf-update.component';

describe('CalfUpdateComponent', () => {
  let component: CalfUpdateComponent;
  let fixture: ComponentFixture<CalfUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalfUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalfUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
