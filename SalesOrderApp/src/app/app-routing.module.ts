import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { SalesItemPriceComponent } from './sales-item-price/sales-item-price.component';
import { SalesItemComponent } from './sales-item/sales-item.component';
import { SalesOrderLineComponent } from './sales-order-line/sales-order-line.component';
import { SalesOrderComponent } from './sales-order/sales-order.component';
import { UomComponent } from './uom/uom.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'uom', component: UomComponent},
  {path: 'customer', component: CustomerComponent},
  {path: 'sales-item', component: SalesItemComponent},
  {path: 'sales-item-price', component: SalesItemPriceComponent},
  {path: 'sales-order', component: SalesOrderComponent},
  // {path: 'sales-order-line', component: SalesOrderLineComponent},
  {path: 'sales-order/:id', component: SalesOrderLineComponent},
  {path: 'home', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
