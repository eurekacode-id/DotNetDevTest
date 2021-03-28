import { SalesItem } from "./sales-item.model";
import { SalesOrderLine } from "./sales-order-line.model";
import { UoM } from "./uom.model";

export class SalesItemPrice {
  salesItemPriceId: number = 0;
  price: number = 0;

  salesItem: SalesItem;
  uoM: UoM;
  salesOrderLines: SalesOrderLine[];
}
