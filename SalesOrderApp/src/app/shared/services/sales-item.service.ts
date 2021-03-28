import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalesItem } from '../models/sales-item.model';

@Injectable({
  providedIn: 'root'
})
export class SalesItemService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44359/api/SalesItem';

  formData:SalesItem = new SalesItem();
  list:SalesItem[];
  listSalesItem:SalesItem[];

  postSalesItem(){
    return this.http.post(this.baseURL, this.formData);
  }

  putSalesItem(){
    return this.http.put(`${this.baseURL}/${this.formData.salesItemId}`, this.formData);
  }

  deleteSalesItem(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.list = res as SalesItem[]
    );
  }

  populateDropDown(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.listSalesItem = res as SalesItem[]
    );
  }
}
