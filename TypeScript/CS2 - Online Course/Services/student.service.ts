import { IStudent } from "../Models/student.model";
import { CourseName, CourseCategory, EnrollmentStatus } from "../Models/course.enums";

export class StudentService {
  
  private getCourseCategory(course: CourseName): CourseCategory {
    switch(course) {
      case CourseName.Angular: return CourseCategory.FrontEnd;
      case CourseName.Nodejs: return CourseCategory.BackEnd;
      case CourseName.FullStack: return CourseCategory.FullStack;
    }
  }

  private validateEligibility(age: number, course: CourseName, knowsHTML: boolean): EnrollmentStatus {
    if (age < 18) return EnrollmentStatus.NotEligible;
    if (course === CourseName.Angular && !knowsHTML) return EnrollmentStatus.NotEligible;
    return EnrollmentStatus.Eligible;
  }

  public createStudent(name: string, age: number, courseName: CourseName, knowsHTML: boolean): IStudent {
    const courseCategory = this.getCourseCategory(courseName);
    const enrollmentStatus = this.validateEligibility(age, courseName, knowsHTML);

    return {
      name,
      age,
      courseName,
      knowsHTML,
      courseCategory,
      enrollmentStatus
    };
  }

  public displayDetails(student: IStudent): void {
    console.log(`Student Name: ${student.name}`);
    console.log(`Age: ${student.age}`);
    console.log(`Course: ${student.courseName}`);
    console.log(`Knows HTML: ${student.knowsHTML}`);
    console.log(`Course Category: ${student.courseCategory}`);
    console.log(`Enrollment Status: ${student.enrollmentStatus}`);
    console.log('------------------------');
  }
}
