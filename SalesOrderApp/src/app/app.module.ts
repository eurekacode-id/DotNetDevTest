import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormControlDirective, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { UomComponent } from './uom/uom.component';
import { UomFormComponent } from './uom/uom-form/uom-form.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerFormComponent } from './customer/customer-form/customer-form.component';
import { SalesItemComponent } from './sales-item/sales-item.component';
import { SalesItemFormComponent } from './sales-item/sales-item-form/sales-item-form.component';
import { SalesItemPriceComponent } from './sales-item-price/sales-item-price.component';
import { SalesItemPriceFormComponent } from './sales-item-price/sales-item-price-form/sales-item-price-form.component';
import { SalesOrderComponent } from './sales-order/sales-order.component';
import { SalesOrderFormComponent } from './sales-order/sales-order-form/sales-order-form.component';
import { SalesOrderLineComponent } from './sales-order-line/sales-order-line.component';
import { SalesOrderLineFormComponent } from './sales-order-line/sales-order-line-form/sales-order-line-form.component';

@NgModule({
  declarations: [
    AppComponent,
    UomComponent,
    UomFormComponent,
    NavbarComponent,
    HomeComponent,
    CustomerComponent,
    CustomerFormComponent,
    SalesItemComponent,
    SalesItemFormComponent,
    SalesItemPriceComponent,
    SalesItemPriceFormComponent,
    SalesOrderComponent,
    SalesOrderFormComponent,
    SalesOrderLineComponent,
    SalesOrderLineFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
