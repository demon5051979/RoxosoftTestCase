import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { ApiUrls } from '../api-urls';
import { map } from 'rxjs/operators';
import { Product } from '../models/Product';


@Injectable({
  providedIn: 'root'
})
export class HttpService { 

constructor(private http: HttpClient) { }

  public getOrders(): Observable<Order[]> {
    return this.http
      .get<any>(ApiUrls.getOrders)
      .pipe(map(response => response.map(item => Order.mapFromServerObject(item))));
  }

  public getOrderProducts(orderId: number): Observable<Product[]> {
    return this.http
      .get<any>(ApiUrls.getOrderProducts(orderId))
      .pipe(map(response => response.map(item => Product.mapFromServerObject(item))));
  }

}
