import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChestAddComponent } from './chest-add.component';

describe('ChestAddComponent', () => {
  let component: ChestAddComponent;
  let fixture: ComponentFixture<ChestAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChestAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChestAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
