import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalBicepsComponent } from './modal-biceps.component';

describe('ModalBicepsComponent', () => {
  let component: ModalBicepsComponent;
  let fixture: ComponentFixture<ModalBicepsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalBicepsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalBicepsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
