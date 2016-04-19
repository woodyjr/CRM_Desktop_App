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
    
        public Address GetAddress(int addressID)
        {
            //variables
            Address address = new Address();

            //connection
            SqlCommand cmd = GetDbCommand();

            //Setup Select Statement 
            cmd.CommandText = @"
                SELECT * FROM SalesLT.Address
                WHERE AddressID = @AddressID    
            ";
            //query variables
            cmd.Parameters.AddWithValue("@AddressID", addressID);

            //DataReader 
            try
            {
                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows - create
                while (reader.Read())
                {
                    Address newAddress = new Address();

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

                    address = newAddress;
                }
                //close the data connection
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            //return collection of Addresses
            return address;
        }

        //public List<Address> GetAddressList(int addressID)
        //{
        //    //Variables
        //    List<Address> addressList = new List<Address>();
        //    //connection
        //    SqlConnection conn = new SqlConnection();
        //    //Define connection string
        //    conn.ConnectionString = "Server=(local)\\sqlexpress;Database=AdventureWorksLT2012;Trusted_Connection=True;";

        //    //Command
        //    SqlCommand cmd = conn.CreateCommand();

        //    //Setup our SELECT statement. (SQL statement)
        //    cmd.CommandText = "SELECT * FROM SalesLT.Address WHERE AddressID = @Id";

        //    //DataReader (also a DataAdapter)
        //    try
        //    {
        //        //open database connection
        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //        //Loop through rows - create Product objects
        //        while (reader.Read())
        //        {
        //            Address newA = new Address
        //            {
        //                AddressLine1 = (string)reader["AddressLine1"],
        //                AddressLine2 = (string)reader["AddressLine2"],
        //                City = (string)reader["City"],
        //                StateProvince = (string)reader["StateProvince"],
        //                CountryRegion = (string)reader["CountryRegion"],
        //                PostalCode = (string)reader["PostalCode"],
        //                AddressID = (int)reader["AddressID"]
        //            };


        //            addressList.Add(newA);

        //        }
        //        //Closes the Database Connection l
        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    //Return collection of products
        //    return addressList;
        //}
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
                //after each address model is created- add to the list to be returned
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

        public Customer GetCustomers(int customerId)
        {
            //variables
            Customer custToReturn = null;

            //Getting Command
            SqlCommand cmd = GetDbCommand();

            //Set up select statement
            cmd.CommandText = @"SELECT * FROM SalesLT.Customer 
                                WHERE CustomerID = @Id
                            ";
            cmd.Parameters.AddWithValue("@Id", customerId);

            //DataReader (also data adaptor)
            try
            {
                //open the connections
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //Loop through rows - create customer objects
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

            //return collection of customers
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

        public Customer AddCustomerUtility(Customer newCustomer)
        {
            //Variables
            Customer customerToReturn = null;

            //Command
            SqlCommand cmd = GetDbCommand();

            //Set up select statement
            cmd.CommandText = @"
                INSERT INTO SalesLT.Customer
                (FirstName, MiddleName, LastName, EmailAddress, CompanyName, SalesPerson, Phone, Suffix, PasswordHash, PasswordSalt)
                VALUES
                (@FirstName, @MiddleName, @LastName, @EmailAddress, @CompanyName, @SalesPerson, @Phone, @Suffix, @PasswordHash, @PasswordSalt);

                SELECT * from SalesLT.Customer WHERE CustomerID = @@Identity;
             ";

            //set our database Query Parameters
            cmd.Parameters.AddWithValue("@FirstName", newCustomer.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", newCustomer.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", newCustomer.LastName);
            cmd.Parameters.AddWithValue("@EmailAddress", newCustomer.EmailAddress);
            cmd.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
            cmd.Parameters.AddWithValue("@SalesPerson", newCustomer.SalesPerson);
            cmd.Parameters.AddWithValue("@Phone", newCustomer.Phone);
            cmd.Parameters.AddWithValue("@Suffix", newCustomer.Suffix);
            cmd.Parameters.AddWithValue("@PasswordHash", newCustomer.PasswordHash);
            cmd.Parameters.AddWithValue("@PasswordSalt", newCustomer.PasswordSalt);

            //Execute Query
            SqlDataReader reader;
            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                //Building a new Product Object
                if (reader.Read())
                {
                    customerToReturn = BuildProduct(reader);
                }

                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            

            //Return new Object
            return customerToReturn;
        }

        public CustomerAddress GetOneCustomerAddress(int AddressID, int CustomerID)
        {
            throw new NotImplementedException();
        }
    }
}
