import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Course } from '../course.model';

@Component({
  selector: 'app-course-catlog',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-catlog.component.html',
  styleUrls: ['./course-catlog.component.css']
})
export class CourseCatalogComponent {
  courses: Course[] = [
    {
      id: 1,
      title: 'Angular Fundamentals',
      instructor: 'John Doe',
      startDate: new Date(2025, 6, 15),
      price: 299.99,
      description: 'Learn Angular basics including components, services, routing, and more.'
    },
    {
      id: 2,
      title: 'TypeScript Essentials',
      instructor: 'Jane Smith',
      startDate: new Date(2025, 7, 5),
      price: 199.5,
      description: 'Master TypeScript with practical hands-on projects.'
    }
  ];
}
