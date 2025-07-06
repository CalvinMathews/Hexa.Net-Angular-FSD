"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const emp_service_1 = require("./Services/emp.service");
const emp_dept_enums_1 = require("./Models/emp.dept.enums");
const svc = new emp_service_1.employeeService();
// Create employees 
const emp1 = svc.createEmployee("Ravi", 28, emp_dept_enums_1.empdept.IT, 60000);
const emp2 = svc.createEmployee("Rachel", 32, emp_dept_enums_1.empdept.HR, 48000);
const emp3 = svc.createEmployee("Arjun", 26, emp_dept_enums_1.empdept.Sales, 85000);
// Display details
svc.displayDetails(emp1);
svc.displayDetails(emp2);
svc.displayDetails(emp3);
