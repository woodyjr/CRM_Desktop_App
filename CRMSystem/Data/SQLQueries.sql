INSERT INTO SalesLT.Product
    (ProductNumber, Name, Color, ListPrice, Weight, Size, StandardCost, SellStartDate)
    VALUES
    (@ProductNumber, @Name, @Color, @ListPrice, @Weight, @Size, @StandardCost, @SellStartDate);

SELECT * from SalesLT.Product WHERE ProductID = @@Identity;





SELECT * FROM SalesLT.Product







SELECT * 
            FROM SalesLT.Product
            WHERE 
                Name LIKE '%' + @query + '%' OR
                ProductNumber  = @query OR 
                Color LIKE '%' + @query + '%'





SELECT * FROM SalesLT.Product 
        WHERE ProductID = @Id



