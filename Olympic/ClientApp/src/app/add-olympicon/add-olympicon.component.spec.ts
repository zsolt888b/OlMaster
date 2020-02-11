import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOlympiconComponent } from './add-olympicon.component';

describe('AddOlympiconComponent', () => {
  let component: AddOlympiconComponent;
  let fixture: ComponentFixture<AddOlympiconComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOlympiconComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOlympiconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
