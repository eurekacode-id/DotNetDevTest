import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/shared/models/customer.model';
import { CustomerService } from 'src/app/shared/services/customer.service';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styles: [
  ]
})
export class CustomerFormComponent implements OnInit {

  constructor(
    public service: CustomerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.customerId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postCustomer().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted successfully','Customer');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putCustomer().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated successfully','Customer');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new Customer();
  }
}
