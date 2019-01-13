import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveyUserComponent } from './survey-user.component';

describe('SurveyUserComponent', () => {
  let component: SurveyUserComponent;
  let fixture: ComponentFixture<SurveyUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SurveyUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveyUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
