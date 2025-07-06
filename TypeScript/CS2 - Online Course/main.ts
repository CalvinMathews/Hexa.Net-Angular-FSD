import { StudentService } from './Services/student.service';
import { CourseName } from './Models/course.enums';
import { IStudent } from './Models/student.model';

const svc = new StudentService();

// Create students
const s1: IStudent = svc.createStudent("Sneha", 20, CourseName.Angular, true);
const s2: IStudent = svc.createStudent("Karan", 17, CourseName.Nodejs, false);
const s3: IStudent = svc.createStudent("Riya", 22, CourseName.Angular, false);
const s4: IStudent = svc.createStudent("Aman", 25, CourseName.FullStack, true);

// Display details
svc.displayDetails(s1);
svc.displayDetails(s2);
svc.displayDetails(s3);
svc.displayDetails(s4);
