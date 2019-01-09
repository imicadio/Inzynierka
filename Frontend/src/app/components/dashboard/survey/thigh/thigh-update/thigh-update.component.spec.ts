import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThighUpdateComponent } from './thigh-update.component';

describe('ThighUpdateComponent', () => {
  let component: ThighUpdateComponent;
  let fixture: ComponentFixture<ThighUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThighUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThighUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
