using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Utilities
{
    public interface IOrderUtility
    {
        List<Order> OrderSearch(int query);
        List<Order> GetSalesOrder();
        Order GetOrderList(int Id);
        void UpdateOrder(Order orderToUpdate);
        Order AddOrderUtility(Order newOrder);
    }
}
