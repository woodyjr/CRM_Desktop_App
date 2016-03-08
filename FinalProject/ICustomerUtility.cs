using System.Collections.Generic;
using CRMSystem.Models;
using FinalProject.Models;

namespace FinalProject.Data
{
    public interface ICustomerUtility
    {
     //   Customer GetCustomer(int query);
        List<Customer> CustomerSearch(string query);
        List<Address> GetAddress(int AddressID);
        List<CustomerAddress> GetCustomerAddress(int CustomerID);
        List<Customer> GetCustomers();
        List<CustomerInformation> GetCustomerInformation();

    }
}