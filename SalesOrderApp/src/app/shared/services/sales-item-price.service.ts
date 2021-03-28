import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalesItemPrice } from '../models/sales-item-price.model';

@Injectable({
  providedIn: 'root'
})
export class SalesItemPriceService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44359/api/SalesItemPrice';

  formData:SalesItemPrice = new SalesItemPrice();
  list:SalesItemPrice[];
  listSalesItemPrice:SalesItemPrice[];

  postSalesItemPrice(){
    return this.http.post(this.baseURL, this.formData);
  }

  putSalesItemPrice(){
    return this.http.put(`${this.baseURL}/${this.formData.salesItemPriceId}`, this.formData);
  }

  deleteSalesItemPrice(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.list = res as SalesItemPrice[]
    );
  }

  populateDropdown(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.listSalesItemPrice = res as SalesItemPrice[]
    );
  }
}
