using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderAPI.Models
{
    public class SalesItemPrice
    {
        public int SalesItemPriceId { get; set; }
        public double Price { get; set; }


        public SalesItem SalesItem { get; set; }
        public UoM UoM { get; set; }
        public List<SalesOrderLine> SalesOrderLines { get; set; }
    }
}
