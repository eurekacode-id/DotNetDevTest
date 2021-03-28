import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SalesOrderLine } from '../shared/models/sales-order-line.model';
import { SalesOrderLineService } from '../shared/services/sales-order-line.service';
import { SalesOrderService } from '../shared/services/sales-order.service';
import { ActivatedRoute } from '@angular/router';
import { SalesOrder } from '../shared/models/sales-order.model';

@Component({
  selector: 'app-sales-order-line',
  templateUrl: './sales-order-line.component.html',
  styles: [
  ]
})
export class SalesOrderLineComponent implements OnInit {

  constructor(
    public service: SalesOrderLineService,
    public salesOrderService: SalesOrderService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) { }

  salesOrderId:any;
  salesOrder: SalesOrder;

  ngOnInit(): void {
    this.getSalesOrder();
    this.service.refreshListById(this.salesOrderId);
  }

  getSalesOrder(){
    this.service.salesOrderId = this.route.snapshot.paramMap.get('id');
    this.service.salesOrder = this.salesOrderService.refreshListById(this.service.salesOrderId);
    this.salesOrderId = this.service.salesOrderId;
    this.salesOrder = this.service.salesOrder;
  }

  populateForm(selectedRecord: SalesOrderLine){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteSalesOrderLine(id)
      .subscribe(
        res =>{
          this.toastr.error("Deleted successfully", "Sales Order Line")
          this.service.refreshList();
        },
        err=>{ console.log(err); }
      );
    }
  }
}
