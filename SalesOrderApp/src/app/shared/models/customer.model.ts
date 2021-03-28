import { SalesOrder } from "./sales-order.model";

export class Customer {
  customerId: number = 0;
  code: string = '';
  completeName: string = '';

  salesOrders: SalesOrder[];
}
