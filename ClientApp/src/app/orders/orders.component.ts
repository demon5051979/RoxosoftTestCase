import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order';
import { Product } from 'src/app/models/Product';
import { HttpService } from '../services/http.service';
import { formatDate } from '@angular/common';
// import { ToastrService } from 'ngx-toastr'; , private notifier: ToastrService

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  constructor(private http: HttpService) { }

  public orders: Order[];
  public products: Product[];
  private selectedOrder: Order;
  public totalQuantity: number;
  public totalAmount: number;

  ngOnInit() {
    this.getOrders();
  }

  private getOrders(): void {
    this.http.getOrders().subscribe(
      orders => {
        this.orders = orders;
      },
      exception => {
        console.error(exception.error);
      }
    );
  }

  private getOrderProducts(orderId: number): void {
    this.http.getOrderProducts(orderId).subscribe(
      orderProducts => {
        this.products = orderProducts;
        this.calcTotals();
      },
      exception => {
        console.error(exception.error);
      }
    );
  }
  
  private calcTotals(): void {
    this.totalQuantity = 0;
    this.totalAmount = 0;
    this.products.forEach(x => {
      this.totalQuantity += x.quantity;
      this.totalAmount += x.amount;
    })
  }

  public select(orderId: number): void {
    if (!this.selectedOrder || orderId != this.selectedOrder.id) {
      this.getOrderProducts(orderId);
      this.selectedOrder = this.orders.find(x => x.id === orderId);
    }
  }

}
