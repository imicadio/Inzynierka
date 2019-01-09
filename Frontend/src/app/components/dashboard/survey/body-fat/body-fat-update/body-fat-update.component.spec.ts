import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyFatUpdateComponent } from './body-fat-update.component';

describe('BodyFatUpdateComponent', () => {
  let component: BodyFatUpdateComponent;
  let fixture: ComponentFixture<BodyFatUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyFatUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyFatUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
