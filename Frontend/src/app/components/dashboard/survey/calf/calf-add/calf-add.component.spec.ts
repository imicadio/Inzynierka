import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalfAddComponent } from './calf-add.component';

describe('CalfAddComponent', () => {
  let component: CalfAddComponent;
  let fixture: ComponentFixture<CalfAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalfAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalfAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
