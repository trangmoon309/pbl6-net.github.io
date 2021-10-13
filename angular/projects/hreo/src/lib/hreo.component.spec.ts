import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { HreoComponent } from './hreo.component';

describe('HreoComponent', () => {
  let component: HreoComponent;
  let fixture: ComponentFixture<HreoComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ HreoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HreoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
