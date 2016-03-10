using System.Collections.Generic;
using CRMSystem.Models;
using FinalProject.Models;

namespace FinalProject.Data
{
    public interface ICustomerUtility
    {
        List<Customer> CustomerSearch(string query);
        List<Address> GetAddress(int AddressID);
        List<CustomerAddress> GetCustomerAddress(int CustomerID);
        List<CustomerInformation> GetCustomerInformation(string query);
        Customer GetCustomers(int id);
        void UpdateCustomer(Customer custToUpdate);
    }
}