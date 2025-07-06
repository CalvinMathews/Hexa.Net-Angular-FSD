import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Student } from './student.model';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {
  students: Student[] = [
    { name: 'Alice', marks: 85, status: 'Pass', active: true },
    { name: 'Bob', marks: 42, status: 'Fail', active: false },
    { name: 'Charlie', marks: 73, status: 'Pass', active: true }
  ];
}
