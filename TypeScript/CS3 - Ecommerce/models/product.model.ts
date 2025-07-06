import { Category } from "./category.enum";


export interface Product {
  id: number;
  name: string;
  category: Category;
  price: number;
  stock: number;
}
