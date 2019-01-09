import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BicepsUpdateComponent } from './biceps-update.component';

describe('BicepsUpdateComponent', () => {
  let component: BicepsUpdateComponent;
  let fixture: ComponentFixture<BicepsUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BicepsUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BicepsUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
