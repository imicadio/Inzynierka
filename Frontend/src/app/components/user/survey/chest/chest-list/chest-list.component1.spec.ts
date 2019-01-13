import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChestListComponent1 } from './chest-list.component1';

describe('ChestListComponent1', () => {
  let component: ChestListComponent1;
  let fixture: ComponentFixture<ChestListComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChestListComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChestListComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
