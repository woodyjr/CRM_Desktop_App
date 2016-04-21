using System.Collections.Generic;
using FinalProject.Models;

namespace FinalProject.Data
{
    public interface ICustomerUtility
    {
        List<Customer> CustomerSearch(string query);
        List<CustomerAddress> GetCustomerAddress(int CustomerID);
        FullAddress GetFullAddress(int fullAddress);
        List<CustomerInformation> GetCustomerInformation(string query);
        Customer GetCustomers(int id);
        void UpdateCustomer(Customer custToUpdate);
        Customer AddCustomerUtility(Customer newCustomer);
    }
}