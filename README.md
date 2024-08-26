
--Users table
 
create table Users (
 
UserId int primary key identity(1,1),
 
UName nvarchar(100) not null,
 
Email nvarchar(255) not null unique, 	
 
Password nvarchar(15),
 
PhoneNumber nvarchar(15),
 
Adress nvarchar(255), 	
 
Pincode nvarchar(15)
 
);
 

--Cart table
 
create table Cart (
 
CartId int primary key identity(1,1),
 
UserId int not null,
 
PId int not null,
 
UName nvarchar(100) not null,
 
PhoneNumber nvarchar(15),
 
Adress nvarchar(255), 	
 
Pincode nvarchar(15),
 
Price DECIMAL(10, 2),
 
BrandName VARCHAR(255),
 
Model_Year INT,
 
Quantity int not null,
 
foreign key (UserId) references Users(UserId),
 
foreign key (PId) references Product_New(PId), );

-- Inserting data into Users table
 
INSERT INTO Users (UName, Email, Password, PhoneNumber, Adress, Pincode) VALUES
 
('Aman Ullah', 'theamaan13@gmail.com', 'abc', '8960444795', '123 Elm Street, Springfield', '62704'),
 
('Jane Smith', 'jane.smith@example.com', 'password456', '0987654321', '456 Oak Avenue, Springfield', '62705'),
 
('Alice Johnson', 'alice.johnson@example.com', 'password789', '5678901234', '789 Pine Road, Springfield', '62706');
select * from cart


-------------------------------------------------------------------------
CREATE or alter PROCEDURE AddToCart
 
    @UserId INT,
 
    @PId INT
 
AS
 
BEGIN
 
    -- Declare variables to hold the data
 
    DECLARE @UName NVARCHAR(100),
 
            @PhoneNumber NVARCHAR(15),
 
            @Address NVARCHAR(255),
 
            @Pincode NVARCHAR(15),
 
            @Price DECIMAL(10, 2),
 
            @BrandName VARCHAR(255),
 
            @Model_Year INT;
    -- Retrieve user details
 
    SELECT @UName = UName,
 
           @PhoneNumber = PhoneNumber,
 
           @Address = Adress,
 
           @Pincode = Pincode
 
    FROM Users
 
    WHERE UserId = @UserId;
    -- Retrieve product details
 
    SELECT @Price = Price,
 
           @BrandName = BrandName,
 
           @Model_Year = Model_Year
 
    FROM Product_New
 
    WHERE PID = @PId;
    -- Insert data into Cart table
 
    INSERT INTO Cart (UserId, PId, UName, PhoneNumber, Adress, Pincode, Price, BrandName, Model_Year, Quantity)
 
    VALUES (@UserId, @PId, @UName, @PhoneNumber, @Address, @Pincode, @Price, @BrandName, @Model_Year, 1); -- Quantity set to 1 for example
 
END;

EXEC AddToCart 1,3

select * from Cart

exec UpdateCartQuantity 1,3

CREATE PROCEDURE UpdateCartQuantity
 
    @CartId INT,
 
    @NewQuantity INT
 
AS
 
BEGIN
 
    -- Declare variables to hold the current price and the total price
 
    DECLARE @CurrentPrice DECIMAL(10, 2),
 
            @TotalPrice DECIMAL(10, 2);
 
    -- Retrieve the current price from the Cart table based on CartId
 
    SELECT @CurrentPrice = Price
 
    FROM Cart
 
    WHERE CartId = @CartId;
 
    -- Check if the CartId exists
 
    IF @CurrentPrice IS NULL
 
    BEGIN
 
        RAISERROR('CartId not found.', 16, 1);
 
        RETURN;
 
    END
 
    -- Calculate the total price based on the new quantity
 
    SET @TotalPrice = @CurrentPrice * @NewQuantity;
 
    -- Update the Cart table with the new quantity and total price
 
    UPDATE Cart
 
    SET Quantity = @NewQuantity,
 
        Price = @TotalPrice
 
    WHERE CartId = @CartId;
 
    -- Optionally, return the updated cart details
 
    SELECT
 
        CartId,
 
        UserId,
 
        PId,
 
        UName,
 
        PhoneNumber,
 
        Adress,
 
        Pincode,
 
        Price,
 
        BrandName,
 
        Model_Year,
 
        Quantity
 
    FROM Cart
 
    WHERE CartId = @CartId;
 
END;

EXEC UpdateCartQuantity @CartId = 3, @NewQuantity = 3;

CREATE PROCEDURE DeleteCartEntry
 
    @CartId INT
 
AS
 
BEGIN
 
    -- Check if the CartId exists
 
    IF NOT EXISTS (SELECT 1 FROM Cart WHERE CartId = @CartId)
 
    BEGIN
 
        RAISERROR('CartId not found.', 16, 1);
 
        RETURN;
 
    END
 
    -- Delete the cart entry with the specified CartId
 
    DELETE FROM Cart
 
    WHERE CartId = @CartId;
 
    -- Optionally, return a confirmation message or the deleted cart details
 
    SELECT
 
        CartId,
 
        UserId,
 
        PId,
 
        UName,
 
        PhoneNumber,
 
        Adress,
 
        Pincode,
 
        Price,
 
        BrandName,
 
        Model_Year,
 
        Quantity
 
    FROM Cart
 
    WHERE CartId = @CartId;  -- This should return no rows if deletion was successful
 
END;

EXEC DeleteCartEntry @CartId = 1;


 
CREATE PROCEDURE AddToCart
    @UserId INT,
    @PId INT
AS
BEGIN
    -- Declare variables to hold the data
    DECLARE @UName NVARCHAR(100),
            @PhoneNumber NVARCHAR(15),
            @Address NVARCHAR(255),
            @Pincode NVARCHAR(15),
            @Price DECIMAL(10, 2),
            @BrandName VARCHAR(255),
            @Model_Year INT;
    -- Retrieve user details
    SELECT @UName = UName,
           @PhoneNumber = PhoneNumber,
           @Address = Adress,
           @Pincode = Pincode
    FROM Users
    WHERE UserId = @UserId;
    -- Retrieve product details
    SELECT @Price = Price,
           @BrandName = BrandName,
           @Model_Year = Model_Year
    FROM Product_New
    WHERE PID = @PId;
    -- Insert data into Cart table
    INSERT INTO Cart (UserId, PId, UName, PhoneNumber, Adress, Pincode, Price, BrandName, Model_Year, Quantity)
    VALUES (@UserId, @PId, @UName, @PhoneNumber, @Address, @Pincode, @Price, @BrandName, @Model_Year, 1); -- Quantity set to 1 for example
END;

EXEC AddToCart @UserId = 1, @PId = 2;

select * from Cart

CREATE PROCEDURE UpdateCartQuantity
    @CartId INT,
    @NewQuantity INT
AS
BEGIN
    -- Declare variables to hold the current price and the total price
    DECLARE @CurrentPrice DECIMAL(10, 2),
            @TotalPrice DECIMAL(10, 2);
    -- Retrieve the current price from the Cart table based on CartId
    SELECT @CurrentPrice = Price
    FROM Cart
    WHERE CartId = @CartId;
    -- Check if the CartId exists
    IF @CurrentPrice IS NULL
    BEGIN
        RAISERROR('CartId not found.', 16, 1);
        RETURN;
    END
    -- Calculate the total price based on the new quantity
    SET @TotalPrice = @CurrentPrice * @NewQuantity;
    -- Update the Cart table with the new quantity and total price
    UPDATE Cart
    SET Quantity = @NewQuantity,
        Price = @TotalPrice
    WHERE CartId = @CartId;
    -- Optionally, return the updated cart details
    SELECT 
        CartId,
        UserId,
        PId,
        UName,
        PhoneNumber,
        Adress,
        Pincode,
        Price,
        BrandName,
        Model_Year,
        Quantity
    FROM Cart
    WHERE CartId = @CartId;
END;

EXEC UpdateCartQuantity @CartId = 4, @NewQuantity = 3;
select * from Cart

CREATE PROCEDURE DeleteCartEntry
    @CartId INT
AS
BEGIN
    -- Check if the CartId exists
    IF NOT EXISTS (SELECT 1 FROM Cart WHERE CartId = @CartId)
    BEGIN
        RAISERROR('CartId not found.', 16, 1);
        RETURN;
    END
    -- Delete the cart entry with the specified CartId
    DELETE FROM Cart
    WHERE CartId = @CartId;
    -- Optionally, return a confirmation message or the deleted cart details
    SELECT 
        CartId,
        UserId,
        PId,
        UName,
        PhoneNumber,
        Adress,
        Pincode,
        Price,
        BrandName,
        Model_Year,
        Quantity
    FROM Cart
    WHERE CartId = @CartId;  -- This should return no rows if deletion was successful
END;

EXEC DeleteCartEntry @CartId = 3;

select * from Cart
CREATE TABLE OrderDetails (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CartId INT,
    UserId INT NOT NULL,
    PId INT NOT NULL,
    UName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Adress NVARCHAR(255),
    Pincode NVARCHAR(15),
    BrandName VARCHAR(255),
    Model_Year INT,
    Quantity INT NOT NULL,
    TotalAmount DECIMAL(10, 2),
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(), -- Date when the order is placed
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(), -- Date when the record is created
	Price DECIMAL(10, 2)
    FOREIGN KEY (CartId) REFERENCES Cart(CartId)
);
CREATE PROCEDURE ProcessAllCarts
AS
BEGIN
    -- Declare variables to hold intermediate data
    DECLARE @UserId INT, @CartId INT, @PId INT, @UName NVARCHAR(100), @PhoneNumber NVARCHAR(15),
            @Adress NVARCHAR(255), @Pincode NVARCHAR(15), @BrandName VARCHAR(255),
            @Model_Year INT, @Quantity INT, @Price DECIMAL(10, 2), @TotalAmount DECIMAL(10, 2);
    -- Cursor to iterate through each user
    DECLARE user_cursor CURSOR FOR
    SELECT DISTINCT UserId
    FROM Cart;
    OPEN user_cursor;
    FETCH NEXT FROM user_cursor INTO @UserId;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Initialize the total amount for the current user
        SET @TotalAmount = 0;
        -- Cursor to iterate through each item in the cart for the current user
        DECLARE cart_cursor CURSOR FOR
        SELECT CartId, PId, UName, PhoneNumber, Adress, Pincode, BrandName, Model_Year, Quantity, Price
        FROM Cart
        WHERE UserId = @UserId;
        OPEN cart_cursor;
        FETCH NEXT FROM cart_cursor INTO @CartId, @PId, @UName, @PhoneNumber, @Adress, @Pincode, @BrandName, @Model_Year, @Quantity, @Price;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Calculate the total amount for each product
            SET @TotalAmount = @TotalAmount + (@Price * @Quantity);
            -- Insert data into OrderDetails table
            INSERT INTO OrderDetails (CartId, UserId, PId, UName, PhoneNumber, Adress, Pincode, BrandName, Model_Year, Quantity, TotalAmount, CreatedDate, Price)
            VALUES (@CartId, @UserId, @PId, @UName, @PhoneNumber, @Adress, @Pincode, @BrandName, @Model_Year, @Quantity, @TotalAmount, GETDATE(), @Price);
            -- Move to the next row in the cart cursor
            FETCH NEXT FROM cart_cursor INTO @CartId, @PId, @UName, @PhoneNumber, @Adress, @Pincode, @BrandName, @Model_Year, @Quantity, @Price;
        END
        CLOSE cart_cursor;
        DEALLOCATE cart_cursor;
        -- Update the TotalAmount column in the OrderDetails table
        UPDATE OrderDetails
        SET TotalAmount = (SELECT SUM(Price * Quantity) FROM Cart WHERE Cart.UserId = @UserId)
        WHERE UserId = @UserId;
        -- Move to the next user
        FETCH NEXT FROM user_cursor INTO @UserId;
    END
    CLOSE user_cursor;
    DEALLOCATE user_cursor;
    -- Display the contents of the OrderDetails table
    SELECT * FROM OrderDetails;
END
