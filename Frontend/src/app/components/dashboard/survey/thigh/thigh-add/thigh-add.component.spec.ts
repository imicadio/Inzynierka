import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThighAddComponent } from './thigh-add.component';

describe('ThighAddComponent', () => {
  let component: ThighAddComponent;
  let fixture: ComponentFixture<ThighAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThighAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThighAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
