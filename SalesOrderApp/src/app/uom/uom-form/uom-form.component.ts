import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UoM } from 'src/app/shared/models/uom.model';
import { UoMService } from 'src/app/shared/services/uom.service';

@Component({
  selector: 'app-uom-form',
  templateUrl: './uom-form.component.html',
  styles: [
  ]
})
export class UomFormComponent implements OnInit {

  constructor(
    public service: UoMService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.uoMId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postUoM().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted successfully','Unit of Measurements');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putUoM().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated successfully','Unit of Measurements');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new UoM();
  }

}
