import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Customer } from '../shared/models/customer.model';
import { CustomerService } from '../shared/services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styles: [
  ]
})
export class CustomerComponent implements OnInit {

  constructor(
    public service: CustomerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Customer){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteCustomer(id)
      .subscribe(
        res =>{
          this.toastr.error("Deleted successfully", "Customer")
          this.service.refreshList();
        },
        err=>{ console.log(err); }
      );
    }
  }
}
