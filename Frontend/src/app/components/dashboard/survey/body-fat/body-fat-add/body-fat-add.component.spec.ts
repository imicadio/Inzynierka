import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyFatAddComponent } from './body-fat-add.component';

describe('BodyFatAddComponent', () => {
  let component: BodyFatAddComponent;
  let fixture: ComponentFixture<BodyFatAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyFatAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyFatAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
