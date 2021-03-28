import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalesOrderLine } from '../models/sales-order-line.model';
import { SalesOrder } from '../models/sales-order.model';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderLineService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44359/api/SalesOrderLine';

  formData:SalesOrderLine = new SalesOrderLine();
  list:SalesOrderLine[];
  listSalesOrderLine:SalesOrderLine[];
  salesOrderId:any;
  salesOrder:SalesOrder;

  postSalesOrderLine(){
    return this.http.post(this.baseURL, this.formData);
  }

  putSalesOrderLine(){
    return this.http.put(`${this.baseURL}/${this.formData.salesOrderLineId}`, this.formData);
  }

  deleteSalesOrderLine(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.list = res as SalesOrderLine[]
    );
  }

  refreshListById(id:string){
    this.http.get(`${this.baseURL}/${id}`)
    .toPromise()
    .then(
      res=>this.list = res as SalesOrderLine[]
    );
  }

  populateDropdown(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.listSalesOrderLine = res as SalesOrderLine[]
    );
  }
}
