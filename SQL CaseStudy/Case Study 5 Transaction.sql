CREATE DATABASE CustomerTransaction;
USE CustomerTransaction;

--1: Table Structures

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductName VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);

--2: Insert Sample Data

INSERT INTO Orders (CustomerName)
VALUES 
('Faisal Ahmed'),
('Ananya Iyer'),
('Rohan Mehra'),
('Sneha Kapoor'),
('Vikram Nair');

SELECT * FROM Orders;

INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
VALUES
(1, 'Bluetooth Speaker', 1, 3500.00),
(2, 'Power Bank', 2, 1200.00),
(3, 'LED Monitor', 1, 9500.00),
(4, 'Mechanical Keyboard', 1, 4500.00),
(5, 'HDMI Cable', 3, 600.00);

SELECT * FROM OrderItems;

--3: Use Transaction to Insert Data in Both Tables

BEGIN TRANSACTION;
BEGIN
	BEGIN TRY
		
		INSERT INTO Orders (CustomerName, OrderDate)
		VALUES ('Kavya Rao', '2025-06-05');

		IF @@ROWCOUNT = 0
        THROW 50001, 'Order insertion failed.', 1;

		INSERT INTO OrderItems (ProductName, Quantity, UnitPrice)
		VALUES ('Smartwatch', 2, 15000.00);

		IF @@ROWCOUNT = 0
        THROW 50001, 'OrderItems insertion failed.', 1;

		COMMIT;
		PRINT 'Transaction completed successfully';
	END TRY
	BEGIN CATCH
		ROLLBACK;
		PRINT 'Transaction rolled back due to error: ' + ERROR_MESSAGE();
	END CATCH
END;

--4: Test the Transaction

DELETE FROM OrderItems WHERE OrderID IS NULL;
DELETE FROM Orders WHERE OrderID = 9;

SELECT * FROM Orders WHERE OrderID = 10;
SELECT * FROM OrderItems WHERE OrderID IS NULL;

--5: Check All Data

SELECT * FROM Orders;
SELECT * FROM OrderItems;
