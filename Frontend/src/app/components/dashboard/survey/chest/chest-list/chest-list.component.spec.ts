import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChestListComponent } from './chest-list.component';

describe('ChestListComponent', () => {
  let component: ChestListComponent;
  let fixture: ComponentFixture<ChestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
