using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Order_Forms.View_Model
{
    class OrderSearchViewModel
    {
        public OrderSearchViewModel(Order order)
        {
            SalesOrderID = order.SalesOrderID;
            RevisionNumber = order.RevisionNumber;
            OrderDate = order.OrderDate;
            DueDate = order.DueDate;
            ShipDate = order.ShipDate;
            Status = order.Status;
            OnlineOrderFlag = order.OnlineOrderFlag;
            SalesOrderNumber = order.SalesOrderNumber;
            PurchaseOrderNumber = order.PurchaseOrderNumber;
            AccountNumber = order.AccountNumber;
            CustomerID = order.CustomerID;
            ShipToAddressID = order.ShipToAddressID;
            ShipMethod = order.ShipMethod;
            CreditCardApprovalCode = order.CreditCardApprovalCode;
            SubTotal = order.SubTotal;
            Freight = order.Freight;
            TotalDue = order.TotalDue;
            Comment = order.Comment;
            RowGuid = order.RowGuid;
            ModifiedDate = order.ModifiedDate;

        }
        public int SalesOrderID { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int ShipToAddressID { get; set; }
        public int BillToAddressID { get; set; }
        public string ShipMethod { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal TaxAmt { get; set; }
        public Decimal Freight { get; set; }
        public Decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
