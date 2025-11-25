-- ============================================
-- ORDER MANAGEMENT SYSTEM - DATABASE CREATION
-- Software Engineering Lab Assignment 2
-- ============================================

-- Step 1: Create Database
USE master;
GO

-- Drop database if exists (for clean reinstall)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'OrderManagementDB')
BEGIN
    ALTER DATABASE OrderManagementDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE OrderManagementDB;
END
GO

-- Create new database
CREATE DATABASE OrderManagementDB;
GO

USE OrderManagementDB;
GO

-- ============================================
-- Step 2: Create Tables
-- ============================================

-- Table 1: Users (for authentication)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(255) NOT NULL,  -- In production, use hashed passwords
    IsLocked BIT DEFAULT 0,
    Role NVARCHAR(20) DEFAULT 'User', -- Admin, User, Manager
    CreatedDate DATETIME DEFAULT GETDATE(),
    LastLogin DATETIME NULL
);

-- Table 2: Item (Products/Items for sale)
CREATE TABLE Item (
    ItemID INT PRIMARY KEY IDENTITY(1,1),
    ItemName NVARCHAR(100) NOT NULL,
    Size NVARCHAR(50),
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT DEFAULT 0,
    Category NVARCHAR(50),
    Description NVARCHAR(500),
    ImageUrl NVARCHAR(200),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Table 3: Agent (Sales Agents/Customers)
CREATE TABLE Agent (
    AgentID INT PRIMARY KEY IDENTITY(1,1),
    AgentName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    CompanyName NVARCHAR(100),
    TaxCode NVARCHAR(50),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Table 4: Order (Orders from Agents)
CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME DEFAULT GETDATE(),
    AgentID INT NOT NULL,
    TotalAmount DECIMAL(18,2) DEFAULT 0,
    Status NVARCHAR(50) DEFAULT 'Pending', -- Pending, Confirmed, Shipped, Delivered, Cancelled
    ShippingAddress NVARCHAR(200),
    Notes NVARCHAR(500),
    CreatedBy INT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Order_Agent FOREIGN KEY (AgentID) REFERENCES Agent(AgentID),
    CONSTRAINT FK_Order_User FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

-- Table 5: OrderDetail (Items in each Order)
CREATE TABLE OrderDetail (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    ItemID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitAmount DECIMAL(18,2) NOT NULL,
    Discount DECIMAL(5,2) DEFAULT 0, -- Discount percentage
    TotalAmount AS (Quantity * UnitAmount * (1 - Discount/100)) PERSISTED,
    CONSTRAINT FK_OrderDetail_Order FOREIGN KEY (OrderID) REFERENCES [Order](OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetail_Item FOREIGN KEY (ItemID) REFERENCES Item(ItemID)
);

-- ============================================
-- Create Indexes for Performance
-- ============================================

CREATE INDEX IX_Order_AgentID ON [Order](AgentID);
CREATE INDEX IX_Order_OrderDate ON [Order](OrderDate);
CREATE INDEX IX_OrderDetail_OrderID ON OrderDetail(OrderID);
CREATE INDEX IX_OrderDetail_ItemID ON OrderDetail(ItemID);
CREATE INDEX IX_Item_Category ON Item(Category);
CREATE INDEX IX_Agent_AgentName ON Agent(AgentName);

-- ============================================
-- Create Views for Common Queries
-- ============================================

-- View 1: Order Summary with Agent Details
GO
CREATE VIEW vw_OrderSummary AS
SELECT 
    o.OrderID,
    o.OrderDate,
    a.AgentName,
    a.Phone,
    a.Email,
    o.TotalAmount,
    o.Status,
    COUNT(od.ID) AS TotalItems,
    SUM(od.Quantity) AS TotalQuantity
FROM [Order] o
INNER JOIN Agent a ON o.AgentID = a.AgentID
LEFT JOIN OrderDetail od ON o.OrderID = od.OrderID
GROUP BY o.OrderID, o.OrderDate, a.AgentName, a.Phone, a.Email, o.TotalAmount, o.Status;
GO

-- View 2: Order Detail with Item Information
CREATE VIEW vw_OrderDetailInfo AS
SELECT 
    od.ID,
    od.OrderID,
    o.OrderDate,
    a.AgentName,
    i.ItemName,
    i.Size,
    od.Quantity,
    od.UnitAmount,
    od.Discount,
    od.TotalAmount,
    o.Status
FROM OrderDetail od
INNER JOIN [Order] o ON od.OrderID = o.OrderID
INNER JOIN Item i ON od.ItemID = i.ItemID
INNER JOIN Agent a ON o.AgentID = a.AgentID;
GO

-- View 3: Best Selling Items
CREATE VIEW vw_BestSellingItems AS
SELECT 
    i.ItemID,
    i.ItemName,
    i.Category,
    i.Price,
    COUNT(DISTINCT od.OrderID) AS OrderCount,
    SUM(od.Quantity) AS TotalQuantitySold,
    SUM(od.TotalAmount) AS TotalRevenue
FROM Item i
LEFT JOIN OrderDetail od ON i.ItemID = od.ItemID
GROUP BY i.ItemID, i.ItemName, i.Category, i.Price;
GO

-- View 4: Top Customers (Agents)
CREATE VIEW vw_TopCustomers AS
SELECT 
    a.AgentID,
    a.AgentName,
    a.Phone,
    a.Email,
    COUNT(DISTINCT o.OrderID) AS TotalOrders,
    SUM(o.TotalAmount) AS TotalSpent,
    MAX(o.OrderDate) AS LastOrderDate
FROM Agent a
LEFT JOIN [Order] o ON a.AgentID = o.AgentID
GROUP BY a.AgentID, a.AgentName, a.Phone, a.Email;
GO

-- ============================================
-- Create Stored Procedures
-- ============================================

-- SP 1: Get Order with Details
CREATE PROCEDURE sp_GetOrderWithDetails
    @OrderID INT
AS
BEGIN
    -- Get Order Header
    SELECT 
        o.OrderID,
        o.OrderDate,
        o.AgentID,
        a.AgentName,
        a.Address,
        a.Phone,
        a.Email,
        o.TotalAmount,
        o.Status,
        o.ShippingAddress,
        o.Notes
    FROM [Order] o
    INNER JOIN Agent a ON o.AgentID = a.AgentID
    WHERE o.OrderID = @OrderID;

    -- Get Order Details
    SELECT 
        od.ID,
        od.ItemID,
        i.ItemName,
        i.Size,
        od.Quantity,
        od.UnitAmount,
        od.Discount,
        od.TotalAmount
    FROM OrderDetail od
    INNER JOIN Item i ON od.ItemID = i.ItemID
    WHERE od.OrderID = @OrderID;
END
GO

-- SP 2: Create Order with Details (Transaction)
CREATE PROCEDURE sp_CreateOrder
    @AgentID INT,
    @ShippingAddress NVARCHAR(200),
    @Notes NVARCHAR(500),
    @CreatedBy INT,
    @OrderItems NVARCHAR(MAX), -- JSON format: [{"ItemID":1,"Quantity":2,"UnitAmount":100}]
    @NewOrderID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Insert Order
        INSERT INTO [Order] (AgentID, OrderDate, ShippingAddress, Notes, CreatedBy, Status)
        VALUES (@AgentID, GETDATE(), @ShippingAddress, @Notes, @CreatedBy, 'Pending');
        
        SET @NewOrderID = SCOPE_IDENTITY();
        
        -- Insert Order Details from JSON
        INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount)
        SELECT 
            @NewOrderID,
            JSON_VALUE(value, '$.ItemID'),
            JSON_VALUE(value, '$.Quantity'),
            JSON_VALUE(value, '$.UnitAmount')
        FROM OPENJSON(@OrderItems);
        
        -- Update Order Total Amount
        UPDATE [Order]
        SET TotalAmount = (
            SELECT SUM(TotalAmount)
            FROM OrderDetail
            WHERE OrderID = @NewOrderID
        )
        WHERE OrderID = @NewOrderID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- SP 3: Update Item Stock after Order
CREATE PROCEDURE sp_UpdateItemStock
    @OrderID INT
AS
BEGIN
    UPDATE i
    SET i.StockQuantity = i.StockQuantity - od.Quantity
    FROM Item i
    INNER JOIN OrderDetail od ON i.ItemID = od.ItemID
    WHERE od.OrderID = @OrderID;
END
GO

-- SP 4: Get Items Purchased by Agent
CREATE PROCEDURE sp_GetItemsByAgent
    @AgentID INT
AS
BEGIN
    SELECT DISTINCT
        i.ItemID,
        i.ItemName,
        i.Category,
        i.Size,
        COUNT(DISTINCT od.OrderID) AS TimesPurchased,
        SUM(od.Quantity) AS TotalQuantity,
        SUM(od.TotalAmount) AS TotalSpent,
        MAX(o.OrderDate) AS LastPurchaseDate
    FROM Item i
    INNER JOIN OrderDetail od ON i.ItemID = od.ItemID
    INNER JOIN [Order] o ON od.OrderID = o.OrderID
    WHERE o.AgentID = @AgentID
    GROUP BY i.ItemID, i.ItemName, i.Category, i.Size
    ORDER BY TotalSpent DESC;
END
GO

-- SP 5: Get Agents who purchased specific Item
CREATE PROCEDURE sp_GetAgentsByItem
    @ItemID INT
AS
BEGIN
    SELECT DISTINCT
        a.AgentID,
        a.AgentName,
        a.Phone,
        a.Email,
        COUNT(DISTINCT o.OrderID) AS OrderCount,
        SUM(od.Quantity) AS TotalQuantity,
        SUM(od.TotalAmount) AS TotalSpent,
        MAX(o.OrderDate) AS LastOrderDate
    FROM Agent a
    INNER JOIN [Order] o ON a.AgentID = o.AgentID
    INNER JOIN OrderDetail od ON o.OrderID = od.OrderID
    WHERE od.ItemID = @ItemID
    GROUP BY a.AgentID, a.AgentName, a.Phone, a.Email
    ORDER BY TotalSpent DESC;
END
GO

-- ============================================
-- Create Triggers
-- ============================================

-- Trigger 1: Update Order Total Amount when OrderDetail changes
CREATE TRIGGER trg_UpdateOrderTotal
ON OrderDetail
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Update for inserted/updated records
    UPDATE o
    SET o.TotalAmount = (
        SELECT ISNULL(SUM(od.TotalAmount), 0)
        FROM OrderDetail od
        WHERE od.OrderID = o.OrderID
    )
    FROM [Order] o
    WHERE o.OrderID IN (SELECT DISTINCT OrderID FROM inserted)
       OR o.OrderID IN (SELECT DISTINCT OrderID FROM deleted);
END
GO

PRINT '✓ Database and tables created successfully!';
PRINT '✓ Views created successfully!';
PRINT '✓ Stored procedures created successfully!';
PRINT '✓ Triggers created successfully!';
PRINT '';
PRINT 'Next step: Run 02_InsertSampleData.sql to populate the database with sample data.';
