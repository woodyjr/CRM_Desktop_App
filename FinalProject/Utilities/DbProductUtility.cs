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
    public class DbProductUtility : IProductUtility
    {
        public List<ProductCategory> GetProductCategoryList()
        {
            //variables
            List<ProductCategory> prodCategoryList = new List<ProductCategory>();

            //DB Command
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
                SELECT * FROM SalesLT.ProductCategory
            ";
            //DataReader 
            try
            {
                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows - create
                while (reader.Read())
                {
                    //temporary ProductCategory
                    ProductCategory prodCat = new ProductCategory();
                    //data values for ProductCategory
                    prodCat.ProductCategoryID = (int)reader["ProductCategoryID"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ParentProductCategoryID")))
                        prodCat.ParentProductCategoryID = (int)reader["ParentProductCategoryID"];
                    prodCat.Name = (string)reader["Name"];
                    prodCat.rowguid = (Guid)reader["rowguid"];
                    prodCat.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    //add customer to list for viewing                 
                    prodCategoryList.Add(prodCat);
                }

                //close the data connection
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return ProductCategory List
            return prodCategoryList;
        }
        public List<Product> GetProductList()
        {
            //variables
            List<Product> prodList = new List<Product>();

            //DB Command
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
                SELECT * FROM SalesLT.Product
            ";
            //DataReader 
            try
            {
                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows - create
                while (reader.Read())
                {
                    //temporary Product
                    Product tempProduct = new Product();

                    //data values for Product
                    tempProduct.ProductID = (int)reader["ProductID"];
                    tempProduct.Name = (string)reader["Name"];
                    tempProduct.ProductNumber = (string)reader["ProductNumber"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Color")))
                        tempProduct.Color = (string)reader["Color"];
                    tempProduct.StandardCost = (decimal)reader["StandardCost"];
                    tempProduct.ListPrice = (decimal)reader["ListPrice"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Size")))
                        tempProduct.Size = (string)reader["Size"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Weight")))
                        tempProduct.Weight = (decimal)reader["Weight"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ProductCategoryID")))
                        tempProduct.ProductCategoryID = (int)reader["ProductCategoryID"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ProductModelID")))
                        tempProduct.ProductModelID = (int)reader["ProductModelID"];
                    tempProduct.SellStartDate = (DateTime)reader["SellStartDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("SellEndDate")))
                        tempProduct.SellEndDate = (DateTime)reader["SellEndDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("DiscontinuedDate")))
                        tempProduct.DiscontinuedDate = (DateTime)reader["DiscontinuedDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ThumbNailPhoto")))
                        tempProduct.ThumbNailPhoto = (byte[])reader["ThumbNailPhoto"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ThumbnailPhotoFileName")))
                        tempProduct.ThumbnailPhotoFileName = (string)reader["ThumbnailPhotoFileName"];
                    tempProduct.rowguid = (Guid)reader["rowguid"];
                    tempProduct.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    //add customer to list for viewing                 
                    prodList.Add(tempProduct);
                }

                //close the data connection
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return ProductCategory List
            return prodList;
        }
        public List<ProductDescription> GetProductDescriptionList()
        {
            //variables
            List<ProductDescription> prodDescriptionList = new List<ProductDescription>();

            //DB Command
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
                SELECT * FROM SalesLT.ProductDescription
            ";
            //DataReader 
            try
            {
                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows - create
                while (reader.Read())
                {
                    //temporary ProductDescription
                    ProductDescription prodDesc = new ProductDescription();
                    //data values for ProductCategory
                    prodDesc.ProductDescriptionID = (int)reader["ProductDescriptionID"];
                    prodDesc.Description = (string)reader["Description"];
                    prodDesc.rowguid = (Guid)reader["rowguid"];
                    prodDesc.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    //add to list for viewing                 
                    prodDescriptionList.Add(prodDesc);
                }

                //close the data connection
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return List
            return prodDescriptionList;
        }
        public List<ProductModelProductDescription> GetProductModelProductDescription()
        {
            //variables
            List<ProductModelProductDescription> prodModelProductDescriptionList = new List<ProductModelProductDescription>();

            //DB Command
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
                SELECT * FROM SalesLT.ProductModelProductDescription
            ";
            //DataReader 
            try
            {
                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows - create
                while (reader.Read())
                {
                    //temporary ProductCategory
                    ProductModelProductDescription prodMPD = new ProductModelProductDescription();
                    //data values for ProductCategory
                    prodMPD.ProductModelID = (int)reader["ProductModelID"];
                    prodMPD.ProductDescriptionID = (int)reader["ProductDescriptionID"];
                    prodMPD.Culture = (string)reader["Culture"];
                    prodMPD.rowguid = (Guid)reader["rowguid"];
                    prodMPD.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    //add customer to list for viewing                 
                    prodModelProductDescriptionList.Add(prodMPD);
                }

                //close the data connection
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return ProductCategory List
            return prodModelProductDescriptionList;
        }
        public List<Product> ProductSearch(string query)
        {
            //variables
            List<Product> prodList = new List<Product>();

            //DB Command
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
                SELECT * 
                FROM SalesLT.Product
                WHERE 
                    Name LIKE '%' + @query + '%' OR
                    ProductNumber  = @query OR 
                    Color LIKE '%' + @query + '%'
            ";
            //Command parameters
            cmd.Parameters.AddWithValue("@query", query);

            //DataReader 
            try
            {
                //open Database Connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                //loop through rows - create
                while (reader.Read())
                {
                    //temporary Product
                    Product tempProduct = new Product();

                    //data values for Product
                    tempProduct.ProductID = (int)reader["ProductID"];
                    tempProduct.Name = (string)reader["Name"];
                    tempProduct.ProductNumber = (string)reader["ProductNumber"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Color")))
                        tempProduct.Color = (string)reader["Color"];
                    tempProduct.StandardCost = (decimal)reader["StandardCost"];
                    tempProduct.ListPrice = (decimal)reader["ListPrice"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Size")))
                        tempProduct.Size = (string)reader["Size"];
                    if (!reader.IsDBNull(reader.GetOrdinal("Weight")))
                        tempProduct.Weight = (decimal)reader["Weight"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ProductCategoryID")))
                        tempProduct.ProductCategoryID = (int)reader["ProductCategoryID"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ProductModelID")))
                        tempProduct.ProductModelID = (int)reader["ProductModelID"];
                    tempProduct.SellStartDate = (DateTime)reader["SellStartDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("SellEndDate")))
                        tempProduct.SellEndDate = (DateTime)reader["SellEndDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("DiscontinuedDate")))
                        tempProduct.DiscontinuedDate = (DateTime)reader["DiscontinuedDate"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ThumbNailPhoto")))
                        tempProduct.ThumbNailPhoto = (byte[])reader["ThumbNailPhoto"];
                    if (!reader.IsDBNull(reader.GetOrdinal("ThumbnailPhotoFileName")))
                        tempProduct.ThumbnailPhotoFileName = (string)reader["ThumbnailPhotoFileName"];
                    tempProduct.rowguid = (Guid)reader["rowguid"];
                    tempProduct.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    //add customer to list for viewing                 
                    prodList.Add(tempProduct);
                }

                //close the data connection
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return ProductCategory List
            return prodList;
        }
        public List<ProductModel> GetProductModelList()
        {
            throw new NotImplementedException();
        }
        public Product AddProductUtility(Product newProduct)
        {
            //Variables
            Product productToReturn = null;

            //Command
            SqlCommand cmd = GetDbCommand();

            //Set up select statement
            cmd.CommandText = @"
                INSERT INTO SalesLT.Product
                (ProductNumber, Name, Color, ListPrice, Weight, Size, StandardCost, SellStartDate)
                VALUES
                (@ProductNumber, @Name, @Color, @ListPrice, @Weight, @Size, @StandardCost, @SellStartDate);

                SELECT * from SalesLT.Product WHERE ProductID = @@Identity;
             ";

            //set our database Query Parameters
            cmd.Parameters.AddWithValue("@ProductNumber", newProduct.ProductNumber);
            cmd.Parameters.AddWithValue("@Name", newProduct.Name);
            cmd.Parameters.AddWithValue("@Color", newProduct.Color);
            cmd.Parameters.AddWithValue("@ListPrice", newProduct.ListPrice);
            cmd.Parameters.AddWithValue("@Weight", newProduct.Weight);
            cmd.Parameters.AddWithValue("@Size", newProduct.Size);
            cmd.Parameters.AddWithValue("@StandardCost", newProduct.StandardCost);
            cmd.Parameters.AddWithValue("@SellStartDate", newProduct.SellStartDate);

            //Execute Query
            SqlDataReader reader;
            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                //Building a new Product Object
                if (reader.Read())
                {
                    productToReturn = BuildProduct(reader);
                }

                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }


            //Return new Object
            return productToReturn;
        }
        private static Product BuildProduct(SqlDataReader reader)
        {
            return new Product
            {
                ProductNumber = (string)reader["ProductNumber"],
                Name = (string)reader["Name"],
                Color = (string)reader["Color"],
                ListPrice = (decimal)reader["ListPrice"],
                Weight = (decimal)reader["deciaml"],
                Size = (string)reader["Size"],
                StandardCost = (decimal)reader["StandardCost"],
                SellStartDate = (DateTime)reader["SellStartDate"],
                ModifiedDate = (DateTime)reader["ModifiedDate"]
            };
        }
        //Connection string
        private SqlCommand GetDbCommand()
        {
            //Connection
            SqlConnection conn = new SqlConnection();
            //Define connection string
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DbProductUtility"].ConnectionString;

            //Command
            SqlCommand cmd = conn.CreateCommand();

            return cmd;
        }
    }
}
