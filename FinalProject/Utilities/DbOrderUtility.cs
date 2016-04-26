using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Utilities
{
    public class DbOrderUtility : IOrderUtility
    {
        public List<Order> GetSalesOrder()
        {
            //Lists For Housing Sales Order info
            List<Order> SOList = new List<Order>();

            //DB Connection 
            SqlCommand cmd = GetDbCommand();

            try
            {
                //Setup Select Statement (for SalesOrderHeader)
                cmd.CommandText = "SELECT * FROM SalesLT.SalesOrderHeader";

                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows create SODetail
                while (reader.Read())
                {
                    //temp SODetail
                    Order tempSOHeader = new Order();
                    //data values for SODetail
                    tempSOHeader.SalesOrderID = (int)reader["SalesOrderID"];
                    tempSOHeader.OrderDate = (DateTime)reader["OrderDate"];
                    tempSOHeader.DueDate = (DateTime)reader["DueDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ShipDate")))
                        tempSOHeader.ShipDate = (DateTime)reader["ShipDate"];
                    tempSOHeader.Status = (byte)reader["Status"];
                    tempSOHeader.OnlineOrderFlag = (bool)reader["OnlineOrderFlag"];
                    tempSOHeader.SalesOrderNumber = (string)reader["SalesOrderNumber"];
                    if (!reader.IsDBNull(reader.GetOrdinal("PurchaseOrderNumber")))
                        tempSOHeader.PurchaseOrderNumber = (string)reader["PurchaseOrderNumber"];
                    if (!reader.IsDBNull(reader.GetOrdinal("AccountNumber")))
                        tempSOHeader.AccountNumber = (string)reader["AccountNumber"];
                    tempSOHeader.CustomerID = (int)reader["CustomerID"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ShipToAddressID")))
                        tempSOHeader.ShipToAddressID = (int)reader["ShipToAddressID"];
                    if (!reader.IsDBNull(reader.GetOrdinal("BillToAddressID")))
                        tempSOHeader.BillToAddressID = (int)reader["BillToAddressID"];
                    tempSOHeader.ShipMethod = (string)reader["ShipMethod"];
                    if (!reader.IsDBNull(reader.GetOrdinal("CreditCardApprovalCode")))
                        tempSOHeader.CreditCardApprovalCode = (string)reader["CreditCardApprovalCode"];
                    tempSOHeader.SubTotal = (Decimal)reader["SubTotal"];
                    tempSOHeader.TaxAmt = (Decimal)reader["TaxAmt"];
                    tempSOHeader.Freight = (Decimal)reader["Freight"];
                    tempSOHeader.TotalDue = (Decimal)reader["TotalDue"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Comment")))
                        tempSOHeader.Comment = (string)reader["Comment"];
                    tempSOHeader.RowGuid = (Guid)reader["rowguid"];
                    tempSOHeader.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    //add SODetail to list
                    SOList.Add(tempSOHeader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SOList;
        }
        public List<Order> OrderSearch(int query)
        {
            //Lists For Housing Sales Order info
            List<Order> SOHeaderList = new List<Order>();

            //DB Connection 
            SqlCommand cmd = GetDbCommand();

            try
            {
                //Setup Select Statement (for SalesOrderHeader)
                cmd.CommandText = @"
                    SELECT * FROM SalesLT.SalesOrderHeader
                    WHERE 
                        CustomerID = @query
                ";
                //search query variables
                cmd.Parameters.AddWithValue("@query", query);

                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows create SODetail
                while (reader.Read())
                {
                    //temp SODetail
                        Order tempSOHeader = new Order();
                    //data values for SODetail
                        tempSOHeader.SalesOrderID = (int)reader["SalesOrderID"];
                        tempSOHeader.OrderDate = (DateTime)reader["OrderDate"];
                        tempSOHeader.DueDate = (DateTime)reader["DueDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ShipDate")))
                        tempSOHeader.ShipDate = (DateTime)reader["ShipDate"];
                        tempSOHeader.Status = (byte)reader["Status"];
                        tempSOHeader.OnlineOrderFlag = (bool)reader["OnlineOrderFlag"];
                        tempSOHeader.SalesOrderNumber = (string)reader["SalesOrderNumber"];
                    if (!reader.IsDBNull(reader.GetOrdinal("PurchaseOrderNumber")))
                        tempSOHeader.PurchaseOrderNumber = (string)reader["PurchaseOrderNumber"];
                    if (!reader.IsDBNull(reader.GetOrdinal("AccountNumber")))
                        tempSOHeader.AccountNumber = (string)reader["AccountNumber"];
                        tempSOHeader.CustomerID = (int)reader["CustomerID"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ShipToAddressID")))
                        tempSOHeader.ShipToAddressID = (int)reader["ShipToAddressID"];
                    if (!reader.IsDBNull(reader.GetOrdinal("BillToAddressID")))
                        tempSOHeader.BillToAddressID = (int)reader["BillToAddressID"];
                        tempSOHeader.ShipMethod = (string)reader["ShipMethod"];
                    if (!reader.IsDBNull(reader.GetOrdinal("CreditCardApprovalCode")))
                        tempSOHeader.CreditCardApprovalCode = (string)reader["CreditCardApprovalCode"];
                        tempSOHeader.SubTotal = (Decimal)reader["SubTotal"];
                        tempSOHeader.TaxAmt = (Decimal)reader["TaxAmt"];
                        tempSOHeader.Freight = (Decimal)reader["Freight"];
                        tempSOHeader.TotalDue = (Decimal)reader["TotalDue"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Comment")))
                        tempSOHeader.Comment = (string)reader["Comment"];
                        tempSOHeader.RowGuid = (Guid)reader["rowguid"];
                        tempSOHeader.ModifiedDate = (DateTime)reader["ModifiedDate"];
                    //add SODetail to list
                        SOHeaderList.Add(tempSOHeader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SOHeaderList;
        }
        public Order AddOrderUtility(Order newOrder)
        {
            //Variables
            Order orderToReturn = null;

            //Command
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"

                INSERT INTO SalesLT.SalesOrderHeader
                    (OrderDate, DueDate, CustomerID, ShipMethod, TaxAmt, Freight)
                VALUES
                    (@OrderDate, @DueDate, @CustomerID, @ShipMethod, @TaxAmt, @Freight)
                SELECT * from SalesLT.SalesOrderHeader WHERE CustomerID = @@Identity;
             ";

            //set our database Query Parameters
            cmd.Parameters.AddWithValue("@OrderDate", newOrder.OrderDate);
            cmd.Parameters.AddWithValue("@DueDate", newOrder.DueDate);
            cmd.Parameters.AddWithValue("@CustomerID", newOrder.CustomerID);
            cmd.Parameters.AddWithValue("@ShipMethod", newOrder.ShipMethod);
            cmd.Parameters.AddWithValue("@TaxAmt", newOrder.TaxAmt);
            cmd.Parameters.AddWithValue("@Freight", newOrder.Freight);

            //Execute Query
            SqlDataReader reader;
            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                //Building a new Product Object
                if (reader.Read())
                {
                    orderToReturn = BuildProduct(reader);
                }

                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }


            //Return new Object
            return orderToReturn;
        }
        public Order GetOrderList(int id)
        {
            Order orderToReturn = null;

            //DB Connection 
            SqlCommand cmd = GetDbCommand();

            try
            {
                //Setup Select Statement (for SalesOrderHeader)
                cmd.CommandText = @"
                            SELECT * FROM SalesLT.SalesOrderHeader
                            WHERE CustomerID = @Id
                        ";
                cmd.Parameters.AddWithValue("@Id", id);
                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows create SODetail
                while (reader.Read())
                {
                    //temp SODetail
                    orderToReturn = new Order();
                    //data values for SODetail
                    orderToReturn.OrderDate = (DateTime)reader["OrderDate"];
                    orderToReturn.DueDate = (DateTime)reader["DueDate"];
                    orderToReturn.CustomerID = (int)reader["CustomerID"];
                    orderToReturn.ShipMethod = (string)reader["ShipMethod"];
                    orderToReturn.TaxAmt = (Decimal)reader["TaxAmt"];
                    orderToReturn.Freight = (Decimal)reader["Freight"];


                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orderToReturn;
        }
        public void UpdateOrder(Order orderToUpdate)
        {
            //Command
            SqlCommand cmd = GetDbCommand();

            //Set up select statement
            cmd.CommandText = @"
            UPDATE SalesLT.SalesOrderHeader
            SET DueDate = @DueDate,
                OrderDate = @OrderDate,
                Freight = @Freight,
                ShipMethod = @ShipMethod,
                TaxAmt = @TaxAmt
            WHERE CustomerID = @CustomerID
        ";

            //set our database Query Parameters
            cmd.Parameters.AddWithValue("@DueDate", orderToUpdate.DueDate);
            cmd.Parameters.AddWithValue("@OrderDate", orderToUpdate.OrderDate);
            cmd.Parameters.AddWithValue("@Freight", orderToUpdate.Freight);
            cmd.Parameters.AddWithValue("@ShipMethod", orderToUpdate.ShipMethod);
            cmd.Parameters.AddWithValue("@TaxAmt", orderToUpdate.TaxAmt);
            cmd.Parameters.AddWithValue("@CustomerID", orderToUpdate.CustomerID);

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
        private static Order BuildProduct(SqlDataReader reader)
        {
            return new Order
            {
                OrderDate = (DateTime)reader["OrderDate"],
                DueDate = (DateTime)reader["DueDate"],
                CustomerID = (int)reader["CustomerID"],
                ShipMethod = (string)reader["ShipMethod"],
                TaxAmt = (decimal)reader["TaxAmt"],
                Freight = (decimal)reader["Freight"]
            };
        }
        private SqlCommand GetDbCommand()
        {
            //Connection
            SqlConnection conn = new SqlConnection();
            //Define connection string
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DbOrderUtility"].ConnectionString;

            //Command
            SqlCommand cmd = conn.CreateCommand();

            return cmd;
        }

    }
}
