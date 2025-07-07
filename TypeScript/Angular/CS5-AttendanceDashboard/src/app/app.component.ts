import { Component } from '@angular/core';
import { EmployeeListComponent } from './employee-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EmployeeListComponent],
  template: `<h1>Employee Attendance Dashboard</h1>
             <app-employee-list></app-employee-list>`,
})
export class AppComponent {}
