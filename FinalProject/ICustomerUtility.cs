using System.Collections.Generic;
using CRMSystem.Models;
using FinalProject.Models;

namespace FinalProject.Data
{
    public interface ICustomerUtility
    {
        List<Customer> CustomerSearch(string query);
        Address GetAddress(int addressID);
        List<CustomerAddress> GetCustomerAddress(int CustomerID);
        List<CustomerInformation> GetCustomerInformation(string query);
        Customer GetCustomers(int id);
        CustomerAddress GetOneCustomerAddress(int AddressID, int CustomerID);
        void UpdateCustomer(Customer custToUpdate);
        Customer AddCustomerUtility(Customer newCustomer);
    }
}