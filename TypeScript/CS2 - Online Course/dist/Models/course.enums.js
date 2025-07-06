"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EnrollmentStatus = exports.CourseCategory = exports.CourseName = void 0;
var CourseName;
(function (CourseName) {
    CourseName["Angular"] = "Angular";
    CourseName["Nodejs"] = "Node.js";
    CourseName["FullStack"] = "FullStack";
})(CourseName || (exports.CourseName = CourseName = {}));
var CourseCategory;
(function (CourseCategory) {
    CourseCategory["FrontEnd"] = "Front-End";
    CourseCategory["BackEnd"] = "Back-End";
    CourseCategory["FullStack"] = "Full-Stack";
})(CourseCategory || (exports.CourseCategory = CourseCategory = {}));
var EnrollmentStatus;
(function (EnrollmentStatus) {
    EnrollmentStatus["Eligible"] = "Eligible";
    EnrollmentStatus["NotEligible"] = "Not Eligible";
})(EnrollmentStatus || (exports.EnrollmentStatus = EnrollmentStatus = {}));
