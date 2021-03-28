import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SalesItemPrice } from 'src/app/shared/models/sales-item-price.model';
import { SalesItemPriceService } from 'src/app/shared/services/sales-item-price.service';
import { SalesItemService } from 'src/app/shared/services/sales-item.service';
import { UoMService } from 'src/app/shared/services/uom.service';

@Component({
  selector: 'app-sales-item-price-form',
  templateUrl: './sales-item-price-form.component.html',
  styles: [
  ]
})
export class SalesItemPriceFormComponent implements OnInit {

  constructor(
    public service: SalesItemPriceService,
    public salesItemService: SalesItemService,
    public uomService: UoMService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.populateDropDown();
  }

  populateDropDown(){
    this.salesItemService.populateDropDown();
    this.uomService.populateDropDown();
  }

  onSubmit(form:NgForm){
    if(this.service.formData.salesItemPriceId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postSalesItemPrice().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.populateDropDown();
        this.toastr.success('Submitted successfully','Sales Item Price');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putSalesItemPrice().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.populateDropDown();
        this.toastr.info('Updated successfully','Sales Item Price');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new SalesItemPrice();
    this.populateDropDown();
  }
}
