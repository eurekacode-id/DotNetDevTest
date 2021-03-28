using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public string CompleteName { get; set; }

        public List<SalesOrder> SalesOrders { get; set; }
    }
}
