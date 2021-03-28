import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SalesOrder } from '../shared/models/sales-order.model';
import { SalesOrderService } from '../shared/services/sales-order.service';

@Component({
  selector: 'app-sales-order',
  templateUrl: './sales-order.component.html',
  styles: [
  ]
})
export class SalesOrderComponent implements OnInit {

  constructor(
    public service: SalesOrderService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: SalesOrder){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteSalesOrder(id)
      .subscribe(
        res =>{
          this.toastr.error("Deleted successfully", "Sales Order")
          this.service.refreshList();
        },
        err=>{ console.log(err); }
      );
    }
  }
}
