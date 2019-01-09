import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThighListComponent } from './thigh-list.component';

describe('ThighListComponent', () => {
  let component: ThighListComponent;
  let fixture: ComponentFixture<ThighListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThighListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThighListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
