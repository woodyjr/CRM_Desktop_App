using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace FinalProject.Data
{
    public class CustomerUtility : ICustomerUtility
    {
    public Customer AddCustomerUtility(Customer newCustomer)
        {
            throw new NotImplementedException();
        }
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
    public FullAddress GetFullAddress(int fullAddress)
    {
        //variables
        FullAddress fulladdress = new FullAddress();

        //connection
        SqlCommand cmd = GetDbCommand();

        //Setup Select Statement 
        cmd.CommandText = @"
                    SELECT *
                    FROM [AdventureWorksLT2012].[SalesLT].[Address] JOIN [AdventureWorksLT2012].[SalesLT].[CustomerAddress]
                    ON [Address].[AddressID] = [CustomerAddress].AddressID 
                    WHERE AddressID = @AddressID 
                    ";
        //query variables
        cmd.Parameters.AddWithValue("@AddressID", fullAddress);

        //DataReader 
        try
        {
            //open Database Connection
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            //loop through rows - create
            while (reader.Read())
            {
                FullAddress newAddress = new FullAddress();

                newAddress.AddressID = (int)reader["AddressID"];
                newAddress.AddressLine1 = (string)reader["AddressLine1"];
                if (!reader.IsDBNull(reader.GetOrdinal("AddressLine2")))
                    newAddress.AddressLine2 = (string)reader["AddressLine2"];
                newAddress.City = (string)reader["City"];
                newAddress.StateProvince = (string)reader["StateProvince"];
                newAddress.CountryRegion = (string)reader["CountryRegion"];
                newAddress.PostalCode = (string)reader["PostalCode"];
                newAddress.rowguid = (Guid)reader["rowguid"];
                newAddress.ModifiedDate = (DateTime)reader["ModifiedDate"];

                fulladdress = newAddress;
            }
            //close the data connection
            reader.Close();
        }
        catch (Exception ex)
        {
            throw;
        }
        //return collection of Addresses
        return fulladdress;
        }
    public List<CustomerAddress> GetCustomerAddress(int CustomerID)
        {
            //Variables
            List<CustomerAddress> customeraddresses = new List<CustomerAddress>();
            CustomerAddress custAddress;
            //connection
            SqlConnection conn = new SqlConnection();
            //Define connection string
            conn.ConnectionString = "Server=(local)\\sqlexpress;Database=AdventureWorksLT2012;Trusted_Connection=True;";

            //Command
            SqlCommand cmd = conn.CreateCommand();

            //Setup our SELECT statement. (SQL statement)
            cmd.CommandText = "SELECT * FROM SalesLT.CustomerAddress WHERE CustomerID = @Id ";
            cmd.Parameters.AddWithValue("@Id", CustomerID);
            //DataReader (also a DataAdapter)
            try
            {
                //open database connection
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //Loop through rows - create Customer address objects -- may be multiple customer addresses per customer ID 
                //so after each address model is created- add to the list to be returned
                while (reader.Read())
                {
                    custAddress = new CustomerAddress
                    {
                        AddressType = (string)reader["AddressType"],
                        CustomerID = (int)reader["CustomerID"],
                        AddressID = (int)reader["AddressID"]
                    };
                    customeraddresses.Add(custAddress);


                }
                //Closes the Database Connection
                reader.Close();

            }
            catch (Exception ex)
            {
                throw;
            }

            //Return collection of customer address objects
            return customeraddresses;

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