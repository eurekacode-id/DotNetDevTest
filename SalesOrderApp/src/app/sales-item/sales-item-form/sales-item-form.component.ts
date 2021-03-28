import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SalesItem } from 'src/app/shared/models/sales-item.model';
import { SalesItemService } from 'src/app/shared/services/sales-item.service';

@Component({
  selector: 'app-sales-item-form',
  templateUrl: './sales-item-form.component.html',
  styles: [
  ]
})
export class SalesItemFormComponent implements OnInit {

  constructor(
    public service: SalesItemService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.salesItemId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postSalesItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted successfully','Sales Item');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putSalesItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated successfully','Sales Item');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new SalesItem();
  }
}
