import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyFatListComponent } from './body-fat-list.component';

describe('BodyFatListComponent', () => {
  let component: BodyFatListComponent;
  let fixture: ComponentFixture<BodyFatListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BodyFatListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyFatListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
