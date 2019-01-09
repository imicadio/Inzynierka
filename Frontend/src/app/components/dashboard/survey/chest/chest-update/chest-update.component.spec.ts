import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChestUpdateComponent } from './chest-update.component';

describe('ChestUpdateComponent', () => {
  let component: ChestUpdateComponent;
  let fixture: ComponentFixture<ChestUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChestUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChestUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
