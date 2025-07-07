import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseCatlogComponent } from './course-catlog.component';

describe('CourseCatlogComponent', () => {
  let component: CourseCatlogComponent;
  let fixture: ComponentFixture<CourseCatlogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseCatlogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseCatlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
