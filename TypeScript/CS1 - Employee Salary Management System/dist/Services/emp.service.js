"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.employeeService = void 0;
const emp_dept_enums_1 = require("../Models/emp.dept.enums");
class employeeService {
    //  net salary with bonus
    calculateNetSalary(base, dept) {
        let bonus = 0;
        switch (dept) {
            case emp_dept_enums_1.empdept.HR:
                bonus = 0.10;
                break;
            case emp_dept_enums_1.empdept.IT:
                bonus = 0.15;
                break;
            case emp_dept_enums_1.empdept.Sales:
                bonus = 0.12;
                break;
        }
        return base + base * bonus;
    }
    // category
    categorize(netSalary) {
        if (netSalary >= 80000)
            return emp_dept_enums_1.empcat.High;
        else if (netSalary >= 50000)
            return emp_dept_enums_1.empcat.Mid;
        else
            return emp_dept_enums_1.empcat.Low;
    }
    // employee object
    createEmployee(name, age, dept, base) {
        const net = this.calculateNetSalary(base, dept);
        const cat = this.categorize(net);
        return {
            name: name,
            age: age,
            dept: dept,
            basesalary: base,
            totsalary: net,
            category: cat
        };
    }
    displayDetails(emp) {
        console.log(`Employee Name: ${emp.name}`);
        console.log(`Age: ${emp.age}`);
        console.log(`Department: ${emp.dept}`);
        console.log(`Base Salary: Rs.${emp.basesalary}`);
        console.log(`Total Salary (with bonus): Rs.${emp.totsalary}`);
        console.log(`Category: ${emp.category}`);
        console.log('------------------------');
    }
}
exports.employeeService = employeeService;
