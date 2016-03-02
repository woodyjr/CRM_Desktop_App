using System.Collections.Generic;
using CRMSystem.Models;

namespace FinalProject.Data
{
    public interface ICustomerUtility
    {
        Customer GetCustomer(int customerId);
        List<Customer> GetCustomers();
    }
}