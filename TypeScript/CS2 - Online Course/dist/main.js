"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const student_service_1 = require("./Services/student.service");
const course_enums_1 = require("./Models/course.enums");
const svc = new student_service_1.StudentService();
// Create students
const s1 = svc.createStudent("Sneha", 20, course_enums_1.CourseName.Angular, true);
const s2 = svc.createStudent("Karan", 17, course_enums_1.CourseName.Nodejs, false);
const s3 = svc.createStudent("Riya", 22, course_enums_1.CourseName.Angular, false);
const s4 = svc.createStudent("Aman", 25, course_enums_1.CourseName.FullStack, true);
// Display details
svc.displayDetails(s1);
svc.displayDetails(s2);
svc.displayDetails(s3);
svc.displayDetails(s4);
