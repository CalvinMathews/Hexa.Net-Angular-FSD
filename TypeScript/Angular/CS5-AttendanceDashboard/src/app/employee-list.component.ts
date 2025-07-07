import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Employee } from './employee.model';
import { Department } from './department.enum';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {
  Department = Department; // expose enum to template if needed

  employees: Employee[] = [
    { name: 'Alice', department: Department.IT, isPresent: true, workFromHome: false },
    { name: 'Bob', department: Department.HR, isPresent: false, workFromHome: true },
    { name: 'Charlie', department: Department.Sales, isPresent: false, workFromHome: false }
  ];
}
