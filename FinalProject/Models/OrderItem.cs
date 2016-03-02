using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Models
{
    public class OrderItem
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public int OrderQty { get; set; }
        public int ProductID { get; set; }
        public uint UnitPrice { get; set; }
        public int UnitPriceDiscount { get; set; }
        public int LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
     

    }
}
