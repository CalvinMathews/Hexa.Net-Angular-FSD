
import { employeeService } from './Services/emp.service';
import { empdept } from './Models/emp.dept.enums';
import { Iemp } from './Models/emp.model';


const svc = new employeeService();

// Create employees 
const emp1: Iemp = svc.createEmployee("Ravi", 28, empdept.IT, 60000);
const emp2: Iemp = svc.createEmployee("Rachel", 32, empdept.HR, 48000);
const emp3: Iemp = svc.createEmployee("Arjun", 26, empdept.Sales, 85000);

// Display details
svc.displayDetails(emp1);
svc.displayDetails(emp2);
svc.displayDetails(emp3);
