using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderAPI.Models
{
    public class UoM
    {
        public int UoMId { get; set; }
        public string Code { get; set; }
        public string LabelName { get; set; }

        public List<SalesItemPrice> SalesItemPrices { get; set; }
    }
}
