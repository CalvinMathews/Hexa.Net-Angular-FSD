import { Product } from "../models/product.model";
import { Category } from "../models/category.enum";
import { CartItem } from "../models/cart-item.model";

export class ECommerceService {
  private products: Product[] = [];
  private cart: CartItem[] = [];

  constructor() {
    this.products = [
      { id: 1, name: "Laptop", category: Category.Electronics, price: 45000, stock: 3 },
      { id: 2, name: "Jeans", category: Category.Clothing, price: 1500, stock: 10 },
      { id: 3, name: "Rice Bag", category: Category.Grocery, price: 700, stock: 5 }
    ];
  }

  public viewProducts(): void {
    console.log("Available Products:");
    for (const p of this.products) {
      console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
    }
    console.log();
  }

  public addToCart(productId: number, quantity: number): void {
    const product = this.products.find(p => p.id === productId);
    if (!product) {
      console.log("Product not found.");
      return;
    }

    if (product.stock < quantity) {
      console.log(`Not enough stock for ${product.name}. Available: ${product.stock}`);
      return;
    }

    const cartItem = this.cart.find(ci => ci.product.id === productId);
    if (cartItem) {
      cartItem.quantity += quantity;
    } else {
      this.cart.push({ product, quantity });
    }

    product.stock -= quantity;
    console.log(`${quantity} x ${product.name} added to cart.`);
  }

  public removeFromCart(productId: number): void {
    const index = this.cart.findIndex(ci => ci.product.id === productId);
    if (index === -1) {
      console.log("Product not in cart.");
      return;
    }

    const cartItem = this.cart[index];
    cartItem.product.stock += cartItem.quantity;
    this.cart.splice(index, 1);
    console.log(`${cartItem.product.name} removed from cart.`);
  }

  public showCartSummary(): void {
    console.log("Cart Summary:");
    let total = 0;

    for (const item of this.cart) {
      const itemTotal = item.product.price * item.quantity;
      console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
      total += itemTotal;
    }

    console.log(`Total: ₹${total}`);

    const discountedTotal = this.applyDiscount(total);
    console.log(`Discounted Total: ₹${discountedTotal}`);
    console.log();
  }

  private applyDiscount(total: number): number {
    if (total >= 10000) {
      return total * 0.85;
    } else if (total >= 5000) {
      return total * 0.90;
    }
    return total;
  }
}
