-- add product with category (find the cateID from cateName to insert to product Table
CREATE OR ALTER PROCEDURE InsertProductWithCategory
    @productName NVARCHAR(100),
    @description NVARCHAR(255),
    @price DECIMAL(10, 2),
    @cateName NVARCHAR(50)
AS
BEGIN
    DECLARE @cateID VARCHAR(4) 

    -- Check if category exists
    IF NOT EXISTS (SELECT 1 FROM category WHERE cateName = @cateName)
    BEGIN
        -- Insert new category
        INSERT INTO category (cateName)
        VALUES (@cateName)

        -- Get the ID of the newly inserted category
        SET @cateID = (SELECT TOP 1 cateID FROM category WHERE cateName = @cateName ORDER BY cateID DESC)
    END
    ELSE
    BEGIN
        -- Get the ID of the existing category
        SELECT @cateID = cateID FROM category WHERE cateName = @cateName
    END

    -- Insert the product
    INSERT INTO product (ProductName, description, price, cateID)
    VALUES (@productName, @description, @price, @cateID)

END

-- create bill
CREATE TYPE BookedProductType AS TABLE
(
    productID VARCHAR(4),
    quantity INT
);
CREATE OR ALTER PROCEDURE CreateBill      
    @Date DATE,
    @Address VARCHAR(255),
    @CustomerName VARCHAR(255),
    @CustomerEmail VARCHAR(255),
    @CustomerPhone VARCHAR(20),
    @PaymentMethod VARCHAR(50),
    @Note TEXT,
    @Status VARCHAR(50),
    @TotalPrice DECIMAL(10, 2),
    @AccID VARCHAR(4),
    @VoucherID VARCHAR(10) = NULL,         
    @BillID VARCHAR(10) OUTPUT, -- Output parameter for BillID
	@BookedProducts BookedProductType READONLY -- Define a table type for BookedProduct
AS  
BEGIN      
    SET NOCOUNT ON;        

    -- Generate a unique BillID      
    SET @BillID = SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 10);        

    -- Insert bill information into Bill table      
    INSERT INTO bill (billID, date, Address, customerName, customerEmail, customerPhone, paymentMethods, Note, Status, total_price, accID, voucherID)
    VALUES (@BillID, @Date, @Address, @CustomerName, @CustomerEmail, @CustomerPhone, @PaymentMethod, @Note, @Status, @TotalPrice, @AccID, @VoucherID)

    -- Insert into AccOrderProduct table
    INSERT INTO AccOrderProduct (quantity, accID, billID, productID)
    SELECT bp.quantity, @AccID, @BillID, bp.productID
    FROM @BookedProducts bp;
END;

