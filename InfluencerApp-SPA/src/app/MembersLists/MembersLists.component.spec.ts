/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MembersListsComponent } from './MembersLists.component';

describe('MembersListsComponent', () => {
  let component: MembersListsComponent;
  let fixture: ComponentFixture<MembersListsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MembersListsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MembersListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
