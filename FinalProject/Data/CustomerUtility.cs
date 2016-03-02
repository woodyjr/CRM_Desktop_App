using CRMSystem.Models;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class CustomerUtility : ICustomerUtility
    {
​
	public List<Customer> GetCustomers()
        {
            List<Customer> CustomerUtil = new List<Customer>();
            CustomerUtil.Add(new Customer { FirstName = "Josh", LastName = "Woody" });
            return CustomerUtil;

        }


        public Customer GetCustomer(int CustomerID)
        {
            //Build Sql Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local)\\sqlexpress;Database=FinalProject;Trusted_Connection=True;";

            //Sql Commmand
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.Customer WHERE CustomerID = @CustomerID";
            cmd.Parameters.AddWithValue("@customerID", CustomerID);

            //Open Reader
            Customer customerObj;
            customerObj = null;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    customerObj = new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        NameStyle = (Boolean)reader["NameStyle"],
                        Title = (string)reader["Title"],
                        FirstName = (string)reader["CustomerID"],
                        MiddleName = (string)reader["CustomerID"],
                        LastName = (string)reader["CustomerID"],
                        Suffix = (string)reader["CustomerID"],
                        CompanyName = (string)reader["CustomerID"],
                        SalesPerson = (string)reader["CustomerID"],
                        EmailAddress = (string)reader["CustomerID"],
                        Phone = (string)reader["CustomerID"],
                        PasswordHash = (string)reader["CustomerID"],
                        PasswordSalt = (string)reader["CustomerID"],
                        rowguid = (Guid)reader["CustomerID"],
                        ModifiedDate = (DateTime)reader["CustomerID"]
                    };
                };
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            //return collection of customers
            return customerObj;
        }


        public List<Address> GetAddress(int AddressID)
        {
            //get Address Objects
            List<Address> colAddress = new List<Address>();

            //Build Sql Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local)\\sqlexpress;Database=FinalProject;Trusted_Connection=True;";

            //Sql Commmand
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.Address WHERE AddressID = @AddressID";
            cmd.Parameters.AddWithValue("@AddressID", AddressID);

            //Open Reader
            Address AddressObj;
            AddressObj = null;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    AddressObj = new Address
                    {
                        AddressID = (int)reader["AddressID"],
                        AddressLine1 = (string)reader["AddressLine1"],
                        AddressLine2 = (string)reader["AddressLine2"],
                        City = (string)reader["City"],
                        StateProvince = (string)reader["StateProvince"],
                        CountryRegion = (string)reader["CustomerID"],
                        PostalCode = (float)reader["CustomerID"],
                        rowguid = (Guid)reader["CustomerID"],
                        ModifiedDate = (DateTime)reader["CustomerID"]
                    };
                    colAddress.Add(AddressObj);
                };
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            //return Addresses object
            return colAddress;
        }


        public List<CustomerAddress> GetCustomerAddress(int CustomerID)
        {
            //get CustomerAddress Objects
            List<CustomerAddress> colCustomerAddress = new List<CustomerAddress>();

            //Build Sql Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local)\\sqlexpress;Database=FinalProject;Trusted_Connection=True;";

            //Sql Commmand
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.CustomerAddress WHERE CustomerID = @CustomerID";
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

            //Open Reader
            CustomerAddress CustomerAddressObj;
            CustomerAddressObj = null;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    CustomerAddressObj = new CustomerAddress
                    {
                        CustomerID = (int)reader["CustomerID"],
                        AddressID = (int)reader["AddressID"],
                        AddressType = (string)reader["AddressType"],
                        rowguid = (Guid)reader["CustomerID"],
                        ModifiedDate = (DateTime)reader["CustomerID"]
                    };
                    colCustomerAddress.Add(CustomerAddressObj);
                };
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            //return collection of Customer Addresses
            return colCustomerAddress;

        }
    }
}
