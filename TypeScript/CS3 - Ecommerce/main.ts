import { ECommerceService } from './services/ecommerce.service';

const service = new ECommerceService();

service.viewProducts();       // View

service.addToCart(1, 1);      // Add
service.addToCart(2, 2);      
service.addToCart(3, 1);      

service.removeFromCart(2);    // Remove

service.showCartSummary();    // Cart

service.viewProducts();     