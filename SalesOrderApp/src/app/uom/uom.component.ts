import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UoM } from '../shared/models/uom.model';
import { UoMService } from '../shared/services/uom.service';

@Component({
  selector: 'app-uom',
  templateUrl: './uom.component.html',
  styles: [
  ]
})
export class UomComponent implements OnInit {

  constructor(
    public service: UoMService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: UoM){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteUoM(id)
      .subscribe(
        res =>{
          this.toastr.error("Deleted successfully", "Unit of Measurements")
          this.service.refreshList();
        },
        err=>{ console.log(err); }
      );
    }
  }
}
