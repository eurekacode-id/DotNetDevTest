import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SalesItemPrice } from '../shared/models/sales-item-price.model';
import { SalesItemPriceService } from '../shared/services/sales-item-price.service';

@Component({
  selector: 'app-sales-item-price',
  templateUrl: './sales-item-price.component.html',
  styles: [
  ]
})
export class SalesItemPriceComponent implements OnInit {

  constructor(
    public service: SalesItemPriceService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: SalesItemPrice){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteSalesItemPrice(id)
      .subscribe(
        res =>{
          this.toastr.error("Deleted successfully", "Sales Item Price")
          this.service.refreshList();
        },
        err=>{ console.log(err); }
      );
    }
  }
}
