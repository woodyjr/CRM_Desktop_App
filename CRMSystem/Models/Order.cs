using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Models
{
    public class Order
    {
        public int SalesOrderID { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }
        public string OnlineOrderFlag { get; set; }
        public int SalesOrderNumber { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public int AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int ShipToAddressID { get; set; }
        public int BillToAddressID { get; set; }
        public string ShipMethod { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public int SubTotal { get; set; }
        public int TaxAmt { get; set; }
        public int Freight { get; set; }
        public int TotalDue { get; set; }
        public string Comment { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }



    }
}
