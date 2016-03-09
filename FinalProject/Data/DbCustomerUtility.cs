using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class DbCustomerUtility : ICustomerUtility
    {
        public List<Customer> CustomerSearch(string query)
        {
            //variables
            List<Customer> colCustomers = new List<Customer>();

            //Getting Command
            SqlCommand cmd = GetDbCommand();

            //Set up select statement
            cmd.CommandText = @"SELECT * 
                    FROM 
                        SalesLT.Customer 
                    WHERE 
                        FirstName LIKE '%' + @query + '%' OR
                        CustomerID LIKE '%' + @query + '%' OR
                        LastName LIKE '%' + @query + '%'";
            cmd.Parameters.AddWithValue("@query", query);

            Customer customerObj;
            customerObj = null;
            //DataReader (also data adaptor)
            try
            {
                //open the connections
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //Loop through rows - create product objects
                while (reader.Read())
                {
                    customerObj = new Customer
                    {

                        CustomerID = (int)reader["CustomerID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        PasswordHash = (string)reader["PasswordHash"],
                        PasswordSalt = (string)reader["PasswordSalt"],
                        rowguid = (Guid)reader["rowguid"],
                        ModifiedDate = (DateTime)reader["ModifiedDate"]
                    };

                    if (!(reader["MiddleName"] is System.DBNull))
                    {
                        customerObj.MiddleName = (string)reader["MiddleName"];
                    }
                    if (!(reader["Title"] is System.DBNull))
                    {
                        customerObj.Title = (string)reader["Title"];
                    }
                    if (!(reader["Suffix"] is System.DBNull))
                    {
                        customerObj.Suffix = (string)reader["Suffix"];
                    }
                    if (!(reader["CompanyName"] is System.DBNull))
                    {
                        customerObj.CompanyName = (string)reader["CompanyName"];
                    }
                    if (!(reader["SalesPerson"] is System.DBNull))
                    {
                        customerObj.SalesPerson = (string)reader["SalesPerson"];
                    }
                    if (!(reader["EmailAddress"] is System.DBNull))
                    {
                        customerObj.EmailAddress = (string)reader["EmailAddress"];
                    }
                    if (!(reader["Phone"] is System.DBNull))
                    {
                        customerObj.Phone = (string)reader["Phone"];
                    }

                    colCustomers.Add(customerObj);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            //return collection of products
            return colCustomers;
        }

        public List<CustomerInformation> GetCustomerInformation(string query)
        {
            SqlCommand cmd = GetDbCommand();
            //set up select statement 
            cmd.CommandText = @"SELECT * 
                                FROM 
                                    SalesLT.Customer LEFT JOIN 
                                    SalesLT.CustomerAddress ON 
                                    SalesLT.CustomerAddress.CustomerID = Customer.CustomerID 
                                    LEFT JOIN SalesLT.Address ON 
                                    SalesLT.Address.AddressID = SalesLT.Address.AddressID
                                WHERE 
                                    FirstName LIKE '%' + @query + '%' OR
                                    CustomerID LIKE '%' + @query + '%' OR
                                    LastName LIKE '%' + @query + '%'
                            ";
            cmd.Parameters.AddWithValue("@query", query);

            //DataReader
            List<CustomerInformation> colCustomerInformation = new List<CustomerInformation>();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    CustomerInformation newCI = new CustomerInformation
                    {

                        CustomerID = (int)reader["CustomerID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        PasswordHash = (string)reader["PasswordHash"],
                        PasswordSalt = (string)reader["PasswordSalt"],
                        AddressID = (int)reader["AddressID"],
                        AddressType = (string)reader["AddressType"],
                        AddressLine1 = (string)reader["AddressLine1"],
                        City = (string)reader["City"],
                        StateProvince = (string)reader["StateProvince"],
                        CountryRegion = (string)reader["CountryRegion"],
                        PostalCode = (float)reader["PostalCode"],
                        rowguid = (Guid)reader["rowguid"],
                        ModifiedDate = (DateTime)reader["ModifiedDate"]
                    };

                    if (!(reader["MiddleName"] is System.DBNull))
                    {
                        newCI.MiddleName = (string)reader["MiddleName"];
                    }
                    if (!(reader["Title"] is System.DBNull))
                    {
                        newCI.Title = (string)reader["Title"];
                    }
                    if (!(reader["Suffix"] is System.DBNull))
                    {
                        newCI.Suffix = (string)reader["Suffix"];
                    }
                    if (!(reader["CompanyName"] is System.DBNull))
                    {
                        newCI.CompanyName = (string)reader["CompanyName"];
                    }
                    if (!(reader["SalesPerson"] is System.DBNull))
                    {
                        newCI.SalesPerson = (string)reader["SalesPerson"];
                    }
                    if (!(reader["EmailAddress"] is System.DBNull))
                    {
                        newCI.EmailAddress = (string)reader["EmailAddress"];
                    }
                    if (!(reader["Phone"] is System.DBNull))
                    {
                        newCI.Phone = (string)reader["Phone"];
                    }
                    if (!(reader["AddressLine2"] is System.DBNull))
                    {
                        newCI.AddressLine2 = (string)reader["AddressLine2"];
                    }

                    colCustomerInformation.Add(newCI);
                }
                //closes the database connection
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return colCustomerInformation;
            

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

        private SqlCommand GetDbCommand()
        {
            //Connection
            SqlConnection conn = new SqlConnection();
            //Define connection string
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DbCustomerUtility"].ConnectionString;

            //Command
            SqlCommand cmd = conn.CreateCommand();

            return cmd;
        }

        private static Customer BuildProduct(SqlDataReader reader)
        {
            return new Customer
            {
                //CustomerID = (int)reader["CustomerID"],
                //NameStyle = (Boolean)reader["NameStyle"],
                //Title = (string)reader["Title"],
                FirstName = (string)reader["FirstName"],
                //MiddleName = (string)reader["MiddleName"],
                LastName = (string)reader["LastName"],
                //Suffix = (string)reader["Suffix"],
                //CompanyName = (string)reader["CompanyName"],
                //SalesPerson = (string)reader["SalesPerson"],
                //EmailAddress = (string)reader["EmailAddress"],
                //Phone = (string)reader["Phone"],
                PasswordHash = (string)reader["PasswordHash"],
                PasswordSalt = (string)reader["PasswordSalt"]
                //rowguid = (Guid)reader["rowguid"],
                //ModifiedDate = (DateTime)reader["ModifiedDate"]

            };
        }

        public Customer GetCustomers(int id)
        {
            throw new NotImplementedException();
        }
    }
}
