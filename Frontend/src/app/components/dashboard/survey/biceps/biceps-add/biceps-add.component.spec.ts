import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BicepsAddComponent } from './biceps-add.component';

describe('BicepsAddComponent', () => {
  let component: BicepsAddComponent;
  let fixture: ComponentFixture<BicepsAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BicepsAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BicepsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
