"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.StudentService = void 0;
const course_enums_1 = require("../Models/course.enums");
class StudentService {
    getCourseCategory(course) {
        switch (course) {
            case course_enums_1.CourseName.Angular: return course_enums_1.CourseCategory.FrontEnd;
            case course_enums_1.CourseName.Nodejs: return course_enums_1.CourseCategory.BackEnd;
            case course_enums_1.CourseName.FullStack: return course_enums_1.CourseCategory.FullStack;
        }
    }
    validateEligibility(age, course, knowsHTML) {
        if (age < 18)
            return course_enums_1.EnrollmentStatus.NotEligible;
        if (course === course_enums_1.CourseName.Angular && !knowsHTML)
            return course_enums_1.EnrollmentStatus.NotEligible;
        return course_enums_1.EnrollmentStatus.Eligible;
    }
    createStudent(name, age, courseName, knowsHTML) {
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
    displayDetails(student) {
        console.log(`Student Name: ${student.name}`);
        console.log(`Age: ${student.age}`);
        console.log(`Course: ${student.courseName}`);
        console.log(`Knows HTML: ${student.knowsHTML}`);
        console.log(`Course Category: ${student.courseCategory}`);
        console.log(`Enrollment Status: ${student.enrollmentStatus}`);
        console.log('------------------------');
    }
}
exports.StudentService = StudentService;
