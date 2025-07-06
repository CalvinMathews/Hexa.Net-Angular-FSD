import { CourseName, CourseCategory, EnrollmentStatus } from './course.enums';

export interface IStudent {
  name: string;
  age: number;
  courseName: CourseName;
  knowsHTML: boolean;
  courseCategory: CourseCategory;
  enrollmentStatus: EnrollmentStatus;
}
