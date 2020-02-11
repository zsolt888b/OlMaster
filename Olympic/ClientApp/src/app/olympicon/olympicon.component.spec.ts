import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OlympiconComponent } from './olympicon.component';

describe('OlympiconComponent', () => {
  let component: OlympiconComponent;
  let fixture: ComponentFixture<OlympiconComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OlympiconComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OlympiconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
