import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SalesItem } from '../shared/models/sales-item.model';
import { SalesItemService } from '../shared/services/sales-item.service';

@Component({
  selector: 'app-sales-item',
  templateUrl: './sales-item.component.html',
  styles: [
  ]
})
export class SalesItemComponent implements OnInit {

  constructor(
    public service: SalesItemService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: SalesItem){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteSalesItem(id)
      .subscribe(
        res =>{
          this.toastr.error("Deleted successfully", "Sales Item")
          this.service.refreshList();
        },
        err=>{ console.log(err); }
      );
    }
  }

}
