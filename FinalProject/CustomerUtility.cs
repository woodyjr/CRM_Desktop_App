using CRMSystem.Models;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                        CountryRegion = (string)reader["CountryRegion"],
                        PostalCode = (float)reader["PostalCode"],
                        rowguid = (Guid)reader["rowguid"],
                        ModifiedDate = (DateTime)reader["ModifiedDate"]
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

    public List<CustomerInformation> GetCustomerInformation(string query)
    {
        throw new NotImplementedException();
    }

    public Customer GetCustomers(int Id)
    {
        //variables
        Customer custToReturn = null;

        //Getting Command
        SqlCommand cmd = GetDbCommand();

        //Set up select statement
        cmd.CommandText = @"SELECT * FROM SalesLT.Customer 
                            WHERE CustomerID = @Id
                        ";
        cmd.Parameters.AddWithValue("@Id", Id);

        //DataReader (also data adaptor)
        try
        {
            //open the connections
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            //Loop through rows - create product objects
            if (reader.Read())
            {
                custToReturn = new Customer
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
                    custToReturn.MiddleName = (string)reader["MiddleName"];
                }
                if (!(reader["Title"] is System.DBNull))
                {
                    custToReturn.Title = (string)reader["Title"];
                }
                if (!(reader["Suffix"] is System.DBNull))
                {
                    custToReturn.Suffix = (string)reader["Suffix"];
                }
                if (!(reader["CompanyName"] is System.DBNull))
                {
                    custToReturn.CompanyName = (string)reader["CompanyName"];
                }
                if (!(reader["SalesPerson"] is System.DBNull))
                {
                    custToReturn.SalesPerson = (string)reader["SalesPerson"];
                }
                if (!(reader["EmailAddress"] is System.DBNull))
                {
                    custToReturn.EmailAddress = (string)reader["EmailAddress"];
                }
                if (!(reader["Phone"] is System.DBNull))
                {
                    custToReturn.Phone = (string)reader["Phone"];
                }
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            throw;
        }

        //return collection of products
        return custToReturn;
    }

    public void UpdateCustomer(Customer custToUpdate)
    {

        //Command
        SqlCommand cmd = GetDbCommand();

        //Set up select statement
        cmd.CommandText = @"
            UPDATE SalesLT.Customer
            SET FirstName = @FirstName,
                MiddleName = @MiddleName,
                LastName = @LastName,
                EmailAddress = @EmailAddress,
                CompanyName = @CompanyName,
                SalesPerson = @SalesPerson,
                Phone = @Phone,
                Suffix = @Suffix
            WHERE CustomerID = @CustomerID
        ";

        //set our database Query Parameters
        cmd.Parameters.AddWithValue("@FirstName", custToUpdate.FirstName);
        cmd.Parameters.AddWithValue("@MiddleName", custToUpdate.MiddleName);
        cmd.Parameters.AddWithValue("@LastName", custToUpdate.LastName);
        cmd.Parameters.AddWithValue("@EmailAddress", custToUpdate.EmailAddress);
        cmd.Parameters.AddWithValue("@CompanyName", custToUpdate.CompanyName);
        cmd.Parameters.AddWithValue("@SalesPerson", custToUpdate.SalesPerson);
        cmd.Parameters.AddWithValue("@Phone", custToUpdate.Phone);
        cmd.Parameters.AddWithValue("@Suffix", custToUpdate.Suffix);
        cmd.Parameters.AddWithValue("@CustomerID", custToUpdate.CustomerID);


            //Execute Query
            try
        {
            cmd.Connection.Open(); //Open DB Connection
            cmd.ExecuteNonQuery(); //Execute Query
            cmd.Connection.Close(); //Close DB Connection
        }
        catch (Exception ex)
        {
            throw;
        }
            
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
    }

}