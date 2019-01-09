import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalfListComponent } from './calf-list.component';

describe('CalfListComponent', () => {
  let component: CalfListComponent;
  let fixture: ComponentFixture<CalfListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalfListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalfListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
