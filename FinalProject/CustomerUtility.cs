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

    public List<Customer> CustomerSearch(string query)
        {
            
            //Build Sql Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local)\\sqlexpress;Database=AdventureWorksLT2012;Trusted_Connection=True;";

            //Sql Commmand
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"
                    SELECT *
                    FROM SalesLT.Customer
                    WHERE
            FirstName LIKE '%' + @query + '%' OR
            LastName LIKE '%' + @query + '%'
            ";

            cmd.Parameters.AddWithValue("@query", query);

            //Open Reader
            // Customer customerObj;
            // customerObj = null;
            List<Customer> customerObj = new List<Customer>();

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    customerObj.Add(new Customer
                    {

                        CustomerID = (int)reader["CustomerID"],
                        NameStyle = (Boolean)reader["NameStyle"],
                        Title = (string)reader["Title"],
                        FirstName = (string)reader["FirstName"],
                        MiddleName = (string)reader["MiddleName"],
                        LastName = (string)reader["LastName"],
                        Suffix = (string)reader["Suffix"],
                        CompanyName = (string)reader["CompanyName"],
                        SalesPerson = (string)reader["SalesPerson"],
                        EmailAddress = (string)reader["EmailAddress"],
                        Phone = (string)reader["Phone"],
                        PasswordHash = (string)reader["PasswordHash"],
                        PasswordSalt = (string)reader["PasswordSalt"],
                        rowguid = (Guid)reader["rowguid"],
                        ModifiedDate = (DateTime)reader["ModifiedDate"]
                    });
                }
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
            conn.ConnectionString = "Server=(local)\\sqlexpress;Database=AdventureWorksLT2012;Trusted_Connection=True;";

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
            conn.ConnectionString = "Server=(local)\\sqlexpress;Database=AdventureWorksLT2012;Trusted_Connection=True;";

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

        public List<CustomerInformation> GetCustomerInformation()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }
        
    }

}