import { empdept, empcat } from './emp.dept.enums';

export interface Iemp {
  name: string;
  age: number;
  dept: empdept;
  basesalary: number;
  totsalary: number;
  category: empcat;
}
