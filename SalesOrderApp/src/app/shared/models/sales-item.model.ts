import { SalesItemPrice } from "./sales-item-price.model";

export class SalesItem {
  salesItemId: number = 0;
  code: string = '';
  labelName: string = '';

  salesItemPrices: SalesItemPrice[];
}
