import { Customer } from "./customer.model";
import { SalesOrderLine } from "./sales-order-line.model";

export class SalesOrder {
  salesOrderId: number = 0;
  salesOrderDocumentNumber: string = '';

  customer: Customer;
  salesOrderLines: SalesOrderLine[];
}
