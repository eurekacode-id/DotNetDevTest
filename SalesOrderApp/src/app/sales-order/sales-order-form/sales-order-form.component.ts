import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SalesOrder } from 'src/app/shared/models/sales-order.model';
import { CustomerService } from 'src/app/shared/services/customer.service';
import { SalesOrderService } from 'src/app/shared/services/sales-order.service';

@Component({
  selector: 'app-sales-order-form',
  templateUrl: './sales-order-form.component.html',
  styles: [
  ]
})
export class SalesOrderFormComponent implements OnInit {

  constructor(
    public service: SalesOrderService,
    public customerService: CustomerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.populateDropDown();
  }

  populateDropDown(){
    this.customerService.populateDropdown();
  }

  onSubmit(form:NgForm){
    if(this.service.formData.salesOrderId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postSalesOrder().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.populateDropDown();
        this.toastr.success('Submitted successfully','Sales Order');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putSalesOrder().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.populateDropDown();
        this.toastr.info('Updated successfully','Sales Order');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new SalesOrder();
    this.populateDropDown();
  }
}
