using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderAPI.Models
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }
        public string SalesOrderDocumentNumber { get; set; }

        public Customer Customer { get; set; }
        public List<SalesOrderLine> SalesOrderLines { get; set; }
    }
}
