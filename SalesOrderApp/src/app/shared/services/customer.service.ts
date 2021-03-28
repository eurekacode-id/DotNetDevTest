import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44359/api/Customer';

  formData:Customer = new Customer();
  list:Customer[];
  listCustomer:Customer[];

  postCustomer(){
    return this.http.post(this.baseURL, this.formData);
  }

  putCustomer(){
    return this.http.put(`${this.baseURL}/${this.formData.customerId}`, this.formData);
  }

  deleteCustomer(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.list = res as Customer[]
    );
  }

  populateDropdown(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.listCustomer = res as Customer[]
    );
  }
}
