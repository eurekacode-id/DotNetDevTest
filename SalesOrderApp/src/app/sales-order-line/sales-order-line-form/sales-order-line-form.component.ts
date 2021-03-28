import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SalesOrderLine } from 'src/app/shared/models/sales-order-line.model';
import { SalesItemPriceService } from 'src/app/shared/services/sales-item-price.service';
import { SalesOrderLineService } from 'src/app/shared/services/sales-order-line.service';
import { ActivatedRoute } from '@angular/router';
import { SalesOrder } from 'src/app/shared/models/sales-order.model';
import { SalesOrderService } from 'src/app/shared/services/sales-order.service';

@Component({
  selector: 'app-sales-order-line-form',
  templateUrl: './sales-order-line-form.component.html',
  styles: [
  ]
})
export class SalesOrderLineFormComponent implements OnInit {

  constructor(
    public service: SalesOrderLineService,
    public salesOrderService: SalesOrderService,
    public salesItemPriceService: SalesItemPriceService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) { }

  salesOrderId:any;
  salesOrder: SalesOrder;


  ngOnInit(): void {
    this.getSalesOrder();
    this.populateDropDown();
  }

  getSalesOrder(){
    this.salesOrderId = this.service.salesOrderId;
    // this.salesOrder = this.salesOrderService.refreshListById(this.service.salesOrderId);
    this.salesOrder = this.service.salesOrder;
  }

  populateDropDown(){
    this.salesItemPriceService.populateDropdown();
  }

  onSubmit(form:NgForm){
    if(this.service.formData.salesOrderLineId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    console.log(form);
    this.service.postSalesOrderLine().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.populateDropDown();
        this.toastr.success('Submitted successfully','Sales Order Line');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putSalesOrderLine().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.populateDropDown();
        this.toastr.info('Updated successfully','Sales Order Line');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new SalesOrderLine();
    this.populateDropDown();
  }
}
