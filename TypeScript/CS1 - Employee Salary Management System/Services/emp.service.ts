import { empdept , empcat } from "../Models/emp.dept.enums";
import { Iemp } from "../Models/emp.model";

export class employeeService {
  
  //  net salary with bonus
  private calculateNetSalary(base: number, dept: empdept): number {
    let bonus = 0;
    switch (dept) {
      case empdept.HR: bonus = 0.10; break;
      case empdept.IT: bonus = 0.15; break;
      case empdept.Sales: bonus = 0.12; break;
    }
    return base + base * bonus;
  }

  // category
  private categorize(netSalary: number): empcat {
    if (netSalary >= 80000) return empcat.High;
    else if (netSalary >= 50000) return empcat.Mid;
    else return empcat.Low;
  }

  // employee object
  public createEmployee(name: string, age: number, dept: empdept, base: number): Iemp {
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

  public displayDetails(emp: Iemp): void {
    console.log(`Employee Name: ${emp.name}`);
    console.log(`Age: ${emp.age}`);
    console.log(`Department: ${emp.dept}`);
    console.log(`Base Salary: Rs.${emp.basesalary}`);
    console.log(`Total Salary (with bonus): Rs.${emp.totsalary}`);
    console.log(`Category: ${emp.category}`);
    console.log('------------------------');
  }
}
