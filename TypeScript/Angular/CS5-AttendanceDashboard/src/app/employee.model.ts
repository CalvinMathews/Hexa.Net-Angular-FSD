import { Department } from './department.enum';

export interface Employee {
  name: string;
  department: Department;
  isPresent: boolean;
  workFromHome: boolean;
}