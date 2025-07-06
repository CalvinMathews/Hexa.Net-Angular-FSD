"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ECommerceService = void 0;
const category_enum_1 = require("../models/category.enum");
class ECommerceService {
    constructor() {
        this.products = [];
        this.cart = [];
        this.products = [
            { id: 1, name: "Laptop", category: category_enum_1.Category.Electronics, price: 45000, stock: 3 },
            { id: 2, name: "Jeans", category: category_enum_1.Category.Clothing, price: 1500, stock: 10 },
            { id: 3, name: "Rice Bag", category: category_enum_1.Category.Grocery, price: 700, stock: 5 }
        ];
    }
    viewProducts() {
        console.log("Available Products:");
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
        console.log();
    }
    addToCart(productId, quantity) {
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
        }
        else {
            this.cart.push({ product, quantity });
        }
        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.`);
    }
    removeFromCart(productId) {
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
    showCartSummary() {
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
    applyDiscount(total) {
        if (total >= 10000) {
            return total * 0.85;
        }
        else if (total >= 5000) {
            return total * 0.90;
        }
        return total;
    }
}
exports.ECommerceService = ECommerceService;
