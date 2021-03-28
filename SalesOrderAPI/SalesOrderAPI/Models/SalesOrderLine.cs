using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderAPI.Models
{
    public class SalesOrderLine
    {
        public int SalesOrderLineId { get; set; }
        public int Quantity { get; set; }
        public double PriceAmount { get; set; }

        public SalesOrder SalesOrder { get; set; }
        public SalesItemPrice SalesItemPrice { get; set; }
    }
}
