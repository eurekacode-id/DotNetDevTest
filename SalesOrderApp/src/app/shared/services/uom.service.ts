import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UoM } from '../models/uom.model';

@Injectable({
  providedIn: 'root'
})
export class UoMService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44359/api/UoM';

  formData:UoM = new UoM();
  list:UoM[];
  listUoM:UoM[];

  postUoM(){
    return this.http.post(this.baseURL, this.formData);
  }

  putUoM(){
    return this.http.put(`${this.baseURL}/${this.formData.uoMId}`, this.formData);
  }

  deleteUoM(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.list = res as UoM[]
    );
  }

  populateDropDown(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(
      res=>this.listUoM = res as UoM[]
    );
  }
}
