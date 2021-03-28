import { SalesItemPrice } from "./sales-item-price.model";
import { SalesOrder } from "./sales-order.model";

export class SalesOrderLine {
  salesOrderLineId: number = 0;
  quantity: number = 0;
  priceAmount: number = 0;

  salesOrder: SalesOrder;
  salesItemPrice: SalesItemPrice;
}
