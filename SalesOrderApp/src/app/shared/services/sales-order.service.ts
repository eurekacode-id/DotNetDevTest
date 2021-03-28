import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalesOrder } from '../models/sales-order.model';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44359/api/SalesOrder';

  formData:SalesOrder = new SalesOrder();
  list:SalesOrder[];
  listSalesOrder:SalesOrder[];
  salesOrder:SalesOrder;

  postSalesOrder(){
    return this.http.post(this.baseURL, this.formData);
  }

  putSalesOrder(){
    return this.http.put(`${this.baseURL}/${this.formData.salesOrderId}`, this.formData);
  }

  deleteSalesOrder(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.list = res as SalesOrder[]
    );
  }

  refreshListById(id:string){
    this.http.get(`${this.baseURL}/${id}`)
    .toPromise()
    .then(
      res=>this.salesOrder = res as SalesOrder
    );

    return this.salesOrder;
  }

  populateDropdown(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.listSalesOrder = res as SalesOrder[]
    );
  }
}
