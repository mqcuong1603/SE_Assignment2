-- ============================================
-- ORDER MANAGEMENT SYSTEM - INSERT SAMPLE DATA
-- Software Engineering Lab Assignment 2
-- ============================================

USE OrderManagementDB;
GO

PRINT 'Starting data insertion...';
PRINT '';

-- ============================================
-- Step 1: Insert Users (15 records)
-- ============================================
PRINT '1. Inserting Users...';

SET IDENTITY_INSERT Users ON;

INSERT INTO Users (UserID, UserName, Email, Password, IsLocked, Role, CreatedDate) VALUES
(1, 'admin', 'admin@orderms.com', '123456', 0, 'Admin', '2024-01-15'),
(2, 'john.doe', 'john.doe@orderms.com', 'pass123', 0, 'Manager', '2024-02-01'),
(3, 'jane.smith', 'jane.smith@orderms.com', 'pass123', 0, 'User', '2024-02-15'),
(4, 'mike.johnson', 'mike.j@orderms.com', 'pass123', 0, 'User', '2024-03-01'),
(5, 'sarah.williams', 'sarah.w@orderms.com', 'pass123', 0, 'User', '2024-03-10'),
(6, 'david.brown', 'david.b@orderms.com', 'pass123', 0, 'Manager', '2024-03-20'),
(7, 'emily.davis', 'emily.d@orderms.com', 'pass123', 0, 'User', '2024-04-01'),
(8, 'robert.wilson', 'robert.w@orderms.com', 'pass123', 0, 'User', '2024-04-15'),
(9, 'lisa.anderson', 'lisa.a@orderms.com', 'pass123', 0, 'User', '2024-05-01'),
(10, 'james.taylor', 'james.t@orderms.com', 'pass123', 0, 'User', '2024-05-10'),
(11, 'maria.garcia', 'maria.g@orderms.com', 'pass123', 0, 'Manager', '2024-06-01'),
(12, 'thomas.moore', 'thomas.m@orderms.com', 'pass123', 1, 'User', '2024-06-15'),
(13, 'nancy.martin', 'nancy.m@orderms.com', 'pass123', 0, 'User', '2024-07-01'),
(14, 'kevin.lee', 'kevin.l@orderms.com', 'pass123', 0, 'User', '2024-07-15'),
(15, 'laura.white', 'laura.w@orderms.com', 'pass123', 0, 'User', '2024-08-01');

SET IDENTITY_INSERT Users OFF;

PRINT '   ✓ Inserted 15 users (Default password for all: "123456" or "pass123")';
PRINT '   ✓ Admin user: admin / 123456';
PRINT '';

-- ============================================
-- Step 2: Insert Items (30 records)
-- ============================================
PRINT '2. Inserting Items...';

SET IDENTITY_INSERT Item ON;

INSERT INTO Item (ItemID, ItemName, Size, Price, StockQuantity, Category, Description, ImageUrl, IsActive, CreatedDate) VALUES
-- Electronics
(1, 'Laptop Dell XPS 15', '15 inch', 1299.99, 50, 'Electronics', 'High-performance laptop with Intel i7', '/images/laptop1.jpg', 1, '2024-01-01'),
(2, 'Laptop HP Pavilion', '14 inch', 899.99, 75, 'Electronics', 'Mid-range laptop for everyday use', '/images/laptop2.jpg', 1, '2024-01-02'),
(3, 'Wireless Mouse Logitech', 'Standard', 29.99, 200, 'Electronics', 'Ergonomic wireless mouse', '/images/mouse1.jpg', 1, '2024-01-03'),
(4, 'Mechanical Keyboard', 'Full Size', 89.99, 120, 'Electronics', 'RGB mechanical gaming keyboard', '/images/keyboard1.jpg', 1, '2024-01-04'),
(5, 'Monitor Samsung 27"', '27 inch', 349.99, 80, 'Electronics', '4K UHD monitor with HDR', '/images/monitor1.jpg', 1, '2024-01-05'),
(6, 'Webcam HD', 'Standard', 59.99, 150, 'Electronics', '1080p HD webcam with microphone', '/images/webcam1.jpg', 1, '2024-01-06'),
(7, 'USB-C Hub', 'Portable', 39.99, 180, 'Electronics', '7-in-1 USB-C adapter', '/images/hub1.jpg', 1, '2024-01-07'),
(8, 'External SSD 1TB', '1TB', 129.99, 100, 'Electronics', 'Portable solid state drive', '/images/ssd1.jpg', 1, '2024-01-08'),
(9, 'Wireless Headphones', 'Over-ear', 149.99, 90, 'Electronics', 'Noise-cancelling Bluetooth headphones', '/images/headphones1.jpg', 1, '2024-01-09'),
(10, 'Smartphone Samsung S23', '6.1 inch', 799.99, 60, 'Electronics', 'Latest flagship smartphone', '/images/phone1.jpg', 1, '2024-01-10'),

-- Office Supplies
(11, 'Office Chair Ergonomic', 'Standard', 199.99, 40, 'Furniture', 'Adjustable ergonomic office chair', '/images/chair1.jpg', 1, '2024-01-11'),
(12, 'Standing Desk', '48x30 inch', 399.99, 30, 'Furniture', 'Electric height-adjustable desk', '/images/desk1.jpg', 1, '2024-01-12'),
(13, 'File Cabinet', '3-Drawer', 159.99, 45, 'Furniture', 'Metal filing cabinet with lock', '/images/cabinet1.jpg', 1, '2024-01-13'),
(14, 'Desk Lamp LED', 'Adjustable', 45.99, 100, 'Furniture', 'Modern LED desk lamp', '/images/lamp1.jpg', 1, '2024-01-14'),
(15, 'Whiteboard', '48x36 inch', 79.99, 55, 'Furniture', 'Magnetic dry erase whiteboard', '/images/whiteboard1.jpg', 1, '2024-01-15'),

-- Stationery
(16, 'Printer Paper A4', '500 sheets', 8.99, 500, 'Stationery', 'Premium white printer paper', '/images/paper1.jpg', 1, '2024-01-16'),
(17, 'Pen Set', '12 pack', 12.99, 300, 'Stationery', 'Ballpoint pens assorted colors', '/images/pens1.jpg', 1, '2024-01-17'),
(18, 'Notebook Set', 'A5 Size', 15.99, 250, 'Stationery', '5-pack spiral notebooks', '/images/notebook1.jpg', 1, '2024-01-18'),
(19, 'Stapler Heavy Duty', 'Standard', 18.99, 150, 'Stationery', 'Metal stapler 50-sheet capacity', '/images/stapler1.jpg', 1, '2024-01-19'),
(20, 'Folder Set', 'Letter Size', 9.99, 400, 'Stationery', '10-pack file folders', '/images/folders1.jpg', 1, '2024-01-20'),

-- Software/Accessories
(21, 'Antivirus Software', '1 Year', 49.99, 200, 'Software', 'Comprehensive security suite', '/images/antivirus1.jpg', 1, '2024-01-21'),
(22, 'Office 365 Subscription', '1 Year', 99.99, 150, 'Software', 'Microsoft Office suite subscription', '/images/office365.jpg', 1, '2024-01-22'),
(23, 'Laptop Bag', '15 inch', 34.99, 120, 'Accessories', 'Padded laptop carrying case', '/images/bag1.jpg', 1, '2024-01-23'),
(24, 'Phone Case', 'Universal', 14.99, 300, 'Accessories', 'Protective smartphone case', '/images/case1.jpg', 1, '2024-01-24'),
(25, 'Screen Protector', 'Universal', 9.99, 350, 'Accessories', 'Tempered glass screen protector', '/images/protector1.jpg', 1, '2024-01-25'),
(26, 'Cable Organizer', 'Set of 5', 12.99, 200, 'Accessories', 'Cable management clips', '/images/organizer1.jpg', 1, '2024-01-26'),
(27, 'Power Strip', '6 Outlets', 24.99, 130, 'Accessories', 'Surge protector power strip', '/images/powerstrip1.jpg', 1, '2024-01-27'),
(28, 'Tablet Stand', 'Adjustable', 19.99, 160, 'Accessories', 'Aluminum tablet holder', '/images/stand1.jpg', 1, '2024-01-28'),
(29, 'Bluetooth Speaker', 'Portable', 59.99, 95, 'Electronics', 'Waterproof portable speaker', '/images/speaker1.jpg', 1, '2024-01-29'),
(30, 'Smart Watch', 'Standard', 199.99, 70, 'Electronics', 'Fitness tracking smartwatch', '/images/watch1.jpg', 1, '2024-01-30');

SET IDENTITY_INSERT Item OFF;

PRINT '   ✓ Inserted 30 items across 5 categories';
PRINT '';

-- ============================================
-- Step 3: Insert Agents (25 records)
-- ============================================
PRINT '3. Inserting Agents...';

SET IDENTITY_INSERT Agent ON;

INSERT INTO Agent (AgentID, AgentName, Address, Phone, Email, CompanyName, TaxCode, IsActive, CreatedDate) VALUES
(1, 'Tech Solutions Inc', '123 Tech Street, Silicon Valley, CA 94025', '+1-650-555-0101', 'contact@techsolutions.com', 'Tech Solutions Inc', 'TAX-001-2024', 1, '2024-01-01'),
(2, 'Global Enterprises', '456 Business Ave, New York, NY 10001', '+1-212-555-0102', 'info@globalent.com', 'Global Enterprises LLC', 'TAX-002-2024', 1, '2024-01-05'),
(3, 'Smart Office Co', '789 Commerce Blvd, Chicago, IL 60601', '+1-312-555-0103', 'sales@smartoffice.com', 'Smart Office Co', 'TAX-003-2024', 1, '2024-01-10'),
(4, 'Digital Works Ltd', '321 Innovation Dr, Austin, TX 78701', '+1-512-555-0104', 'orders@digitalworks.com', 'Digital Works Ltd', 'TAX-004-2024', 1, '2024-01-15'),
(5, 'Prime Solutions', '654 Market St, San Francisco, CA 94102', '+1-415-555-0105', 'contact@primesolutions.com', 'Prime Solutions Inc', 'TAX-005-2024', 1, '2024-01-20'),
(6, 'Metro Trading', '987 Trade Center, Boston, MA 02101', '+1-617-555-0106', 'info@metrotrading.com', 'Metro Trading Corp', 'TAX-006-2024', 1, '2024-02-01'),
(7, 'Future Tech', '147 Tech Park, Seattle, WA 98101', '+1-206-555-0107', 'sales@futuretech.com', 'Future Tech LLC', 'TAX-007-2024', 1, '2024-02-05'),
(8, 'Elite Supplies', '258 Supply Chain Rd, Denver, CO 80201', '+1-303-555-0108', 'orders@elitesupplies.com', 'Elite Supplies Inc', 'TAX-008-2024', 1, '2024-02-10'),
(9, 'Innovative Systems', '369 Innovation Way, Portland, OR 97201', '+1-503-555-0109', 'contact@innosystems.com', 'Innovative Systems', 'TAX-009-2024', 1, '2024-02-15'),
(10, 'Best Buy Corp', '741 Retail Plaza, Miami, FL 33101', '+1-305-555-0110', 'info@bestbuycorp.com', 'Best Buy Corporation', 'TAX-010-2024', 1, '2024-02-20'),
(11, 'Mega Store Chain', '852 Shopping Center, Atlanta, GA 30301', '+1-404-555-0111', 'sales@megastore.com', 'Mega Store Chain', 'TAX-011-2024', 1, '2024-03-01'),
(12, 'Quick Office', '963 Quick St, Phoenix, AZ 85001', '+1-602-555-0112', 'orders@quickoffice.com', 'Quick Office Ltd', 'TAX-012-2024', 1, '2024-03-05'),
(13, 'Pro Business', '159 Pro Ave, Dallas, TX 75201', '+1-214-555-0113', 'contact@probusiness.com', 'Pro Business Inc', 'TAX-013-2024', 1, '2024-03-10'),
(14, 'Top Quality Traders', '357 Quality Rd, Houston, TX 77001', '+1-713-555-0114', 'info@topquality.com', 'Top Quality Traders', 'TAX-014-2024', 1, '2024-03-15'),
(15, 'Swift Commerce', '486 Swift Blvd, Philadelphia, PA 19101', '+1-215-555-0115', 'sales@swiftcommerce.com', 'Swift Commerce LLC', 'TAX-015-2024', 1, '2024-03-20'),
(16, 'United Suppliers', '624 United Plaza, San Diego, CA 92101', '+1-619-555-0116', 'orders@unitedsuppliers.com', 'United Suppliers', 'TAX-016-2024', 1, '2024-04-01'),
(17, 'Alpha Trading', '735 Alpha St, San Jose, CA 95101', '+1-408-555-0117', 'contact@alphatrading.com', 'Alpha Trading Co', 'TAX-017-2024', 1, '2024-04-05'),
(18, 'Beta Solutions', '846 Beta Ave, Columbus, OH 43201', '+1-614-555-0118', 'info@betasolutions.com', 'Beta Solutions Inc', 'TAX-018-2024', 1, '2024-04-10'),
(19, 'Gamma Enterprises', '957 Gamma Dr, Indianapolis, IN 46201', '+1-317-555-0119', 'sales@gammaent.com', 'Gamma Enterprises', 'TAX-019-2024', 1, '2024-04-15'),
(20, 'Delta Corp', '168 Delta Way, Charlotte, NC 28201', '+1-704-555-0120', 'orders@deltacorp.com', 'Delta Corporation', 'TAX-020-2024', 1, '2024-04-20'),
(21, 'Omega Trading', '279 Omega Blvd, Detroit, MI 48201', '+1-313-555-0121', 'contact@omegatrading.com', 'Omega Trading Ltd', 'TAX-021-2024', 1, '2024-05-01'),
(22, 'Zenith Business', '381 Zenith St, Memphis, TN 38101', '+1-901-555-0122', 'info@zenithbusiness.com', 'Zenith Business Inc', 'TAX-022-2024', 1, '2024-05-05'),
(23, 'Apex Supplies', '492 Apex Rd, Nashville, TN 37201', '+1-615-555-0123', 'sales@apexsupplies.com', 'Apex Supplies Co', 'TAX-023-2024', 1, '2024-05-10'),
(24, 'Summit Trading', '513 Summit Ave, Baltimore, MD 21201', '+1-410-555-0124', 'orders@summittrading.com', 'Summit Trading LLC', 'TAX-024-2024', 1, '2024-05-15'),
(25, 'Peak Solutions', '624 Peak Plaza, Milwaukee, WI 53201', '+1-414-555-0125', 'contact@peaksolutions.com', 'Peak Solutions Inc', 'TAX-025-2024', 1, '2024-05-20');

SET IDENTITY_INSERT Agent OFF;

PRINT '   ✓ Inserted 25 agents (companies/customers)';
PRINT '';

-- ============================================
-- Step 4: Insert Orders (20 records)
-- ============================================
PRINT '4. Inserting Orders...';

SET IDENTITY_INSERT [Order] ON;

INSERT INTO [Order] (OrderID, OrderDate, AgentID, TotalAmount, Status, ShippingAddress, Notes, CreatedBy) VALUES
(1, '2024-06-01 09:30:00', 1, 0, 'Delivered', '123 Tech Street, Silicon Valley, CA 94025', 'Rush delivery requested', 1),
(2, '2024-06-03 10:15:00', 2, 0, 'Delivered', '456 Business Ave, New York, NY 10001', 'Standard shipping', 2),
(3, '2024-06-05 14:20:00', 3, 0, 'Shipped', '789 Commerce Blvd, Chicago, IL 60601', 'Fragile items', 3),
(4, '2024-06-07 11:00:00', 4, 0, 'Confirmed', '321 Innovation Dr, Austin, TX 78701', NULL, 1),
(5, '2024-06-10 16:45:00', 5, 0, 'Pending', '654 Market St, San Francisco, CA 94102', 'Bulk order', 2),
(6, '2024-06-12 09:00:00', 1, 0, 'Delivered', '123 Tech Street, Silicon Valley, CA 94025', 'Follow-up order', 3),
(7, '2024-06-15 13:30:00', 6, 0, 'Shipped', '987 Trade Center, Boston, MA 02101', NULL, 1),
(8, '2024-06-18 10:30:00', 7, 0, 'Delivered', '147 Tech Park, Seattle, WA 98101', 'Express shipping', 2),
(9, '2024-06-20 15:00:00', 8, 0, 'Confirmed', '258 Supply Chain Rd, Denver, CO 80201', 'Payment via wire transfer', 3),
(10, '2024-06-22 11:45:00', 9, 0, 'Pending', '369 Innovation Way, Portland, OR 97201', NULL, 1),
(11, '2024-06-25 14:15:00', 10, 0, 'Shipped', '741 Retail Plaza, Miami, FL 33101', 'Large order', 2),
(12, '2024-06-27 09:30:00', 11, 0, 'Delivered', '852 Shopping Center, Atlanta, GA 30301', NULL, 3),
(13, '2024-06-29 16:00:00', 12, 0, 'Confirmed', '963 Quick St, Phoenix, AZ 85001', 'Quarterly order', 1),
(14, '2024-07-01 10:00:00', 13, 0, 'Pending', '159 Pro Ave, Dallas, TX 75201', 'New customer', 2),
(15, '2024-07-03 13:45:00', 14, 0, 'Shipped', '357 Quality Rd, Houston, TX 77001', NULL, 3),
(16, '2024-07-05 11:20:00', 15, 0, 'Delivered', '486 Swift Blvd, Philadelphia, PA 19101', 'Gift wrapping requested', 1),
(17, '2024-07-07 15:30:00', 3, 0, 'Confirmed', '789 Commerce Blvd, Chicago, IL 60601', 'Repeat customer', 2),
(18, '2024-07-10 09:15:00', 5, 0, 'Pending', '654 Market St, San Francisco, CA 94102', NULL, 3),
(19, '2024-07-12 14:00:00', 2, 0, 'Shipped', '456 Business Ave, New York, NY 10001', 'Urgent order', 1),
(20, '2024-07-15 10:45:00', 1, 0, 'Delivered', '123 Tech Street, Silicon Valley, CA 94025', 'Monthly subscription', 2);

SET IDENTITY_INSERT [Order] OFF;

PRINT '   ✓ Inserted 20 orders';
PRINT '';

-- ============================================
-- Step 5: Insert OrderDetails (60+ records)
-- ============================================
PRINT '5. Inserting OrderDetails...';

SET IDENTITY_INSERT OrderDetail ON;

INSERT INTO OrderDetail (ID, OrderID, ItemID, Quantity, UnitAmount, Discount) VALUES
-- Order 1 (Tech Solutions Inc) - Large technology order
(1, 1, 1, 5, 1299.99, 5.00),    -- 5 Laptops Dell XPS
(2, 1, 3, 10, 29.99, 0.00),     -- 10 Wireless Mouse
(3, 1, 5, 3, 349.99, 5.00),     -- 3 Monitors
(4, 1, 9, 5, 149.99, 0.00),     -- 5 Headphones

-- Order 2 (Global Enterprises) - Office furniture
(5, 2, 11, 20, 199.99, 10.00),  -- 20 Office Chairs
(6, 2, 12, 10, 399.99, 10.00),  -- 10 Standing Desks
(7, 2, 14, 15, 45.99, 0.00),    -- 15 Desk Lamps

-- Order 3 (Smart Office Co) - Mixed order
(8, 3, 2, 8, 899.99, 5.00),     -- 8 HP Laptops
(9, 3, 4, 8, 89.99, 0.00),      -- 8 Keyboards
(10, 3, 7, 20, 39.99, 0.00),    -- 20 USB-C Hubs
(11, 3, 16, 50, 8.99, 15.00),   -- 50 Printer Paper packs

-- Order 4 (Digital Works Ltd) - Software and accessories
(12, 4, 21, 25, 49.99, 20.00),  -- 25 Antivirus licenses
(13, 4, 22, 15, 99.99, 15.00),  -- 15 Office 365 subscriptions
(14, 4, 23, 30, 34.99, 10.00),  -- 30 Laptop bags

-- Order 5 (Prime Solutions) - Large mixed order
(15, 5, 1, 10, 1299.99, 10.00), -- 10 Dell Laptops
(16, 5, 5, 10, 349.99, 10.00),  -- 10 Monitors
(17, 5, 8, 15, 129.99, 5.00),   -- 15 External SSDs
(18, 5, 11, 15, 199.99, 10.00), -- 15 Office Chairs

-- Order 6 (Tech Solutions Inc - repeat customer)
(19, 6, 6, 20, 59.99, 0.00),    -- 20 Webcams
(20, 6, 27, 15, 24.99, 0.00),   -- 15 Power Strips
(21, 6, 26, 30, 12.99, 10.00),  -- 30 Cable Organizers

-- Order 7 (Metro Trading)
(22, 7, 13, 12, 159.99, 5.00),  -- 12 File Cabinets
(23, 7, 15, 8, 79.99, 0.00),    -- 8 Whiteboards
(24, 7, 19, 25, 18.99, 15.00),  -- 25 Staplers

-- Order 8 (Future Tech)
(25, 8, 10, 15, 799.99, 8.00),  -- 15 Smartphones
(26, 8, 24, 30, 14.99, 10.00),  -- 30 Phone Cases
(27, 8, 25, 30, 9.99, 10.00),   -- 30 Screen Protectors

-- Order 9 (Elite Supplies)
(28, 9, 17, 100, 12.99, 20.00), -- 100 Pen Sets
(29, 9, 18, 80, 15.99, 15.00),  -- 80 Notebook Sets
(30, 9, 20, 150, 9.99, 20.00),  -- 150 Folder Sets

-- Order 10 (Innovative Systems)
(31, 10, 2, 12, 899.99, 7.00),  -- 12 HP Laptops
(32, 10, 4, 12, 89.99, 5.00),   -- 12 Keyboards
(33, 10, 3, 12, 29.99, 5.00),   -- 12 Wireless Mouse

-- Order 11 (Best Buy Corp) - Large retail order
(34, 11, 29, 50, 59.99, 15.00), -- 50 Bluetooth Speakers
(35, 11, 30, 40, 199.99, 12.00),-- 40 Smart Watches
(36, 11, 10, 30, 799.99, 10.00),-- 30 Smartphones

-- Order 12 (Mega Store Chain)
(37, 12, 16, 200, 8.99, 25.00), -- 200 Printer Paper
(38, 12, 17, 150, 12.99, 20.00),-- 150 Pen Sets
(39, 12, 18, 120, 15.99, 20.00),-- 120 Notebook Sets

-- Order 13 (Quick Office)
(40, 13, 11, 25, 199.99, 12.00),-- 25 Office Chairs
(41, 13, 14, 30, 45.99, 10.00), -- 30 Desk Lamps
(42, 13, 28, 35, 19.99, 5.00),  -- 35 Tablet Stands

-- Order 14 (Pro Business)
(43, 14, 1, 8, 1299.99, 8.00),  -- 8 Dell Laptops
(44, 14, 5, 8, 349.99, 8.00),   -- 8 Monitors
(45, 14, 9, 8, 149.99, 5.00),   -- 8 Headphones

-- Order 15 (Top Quality Traders)
(46, 15, 22, 50, 99.99, 18.00), -- 50 Office 365 licenses
(47, 15, 21, 50, 49.99, 18.00), -- 50 Antivirus licenses

-- Order 16 (Swift Commerce)
(48, 16, 12, 15, 399.99, 12.00),-- 15 Standing Desks
(49, 16, 11, 15, 199.99, 12.00),-- 15 Office Chairs
(50, 16, 15, 10, 79.99, 8.00),  -- 10 Whiteboards

-- Order 17 (Smart Office Co - repeat)
(51, 17, 7, 40, 39.99, 15.00),  -- 40 USB-C Hubs
(52, 17, 8, 20, 129.99, 10.00), -- 20 External SSDs
(53, 17, 6, 25, 59.99, 5.00),   -- 25 Webcams

-- Order 18 (Prime Solutions - repeat)
(54, 18, 3, 50, 29.99, 20.00),  -- 50 Wireless Mouse
(55, 18, 4, 50, 89.99, 20.00),  -- 50 Keyboards
(56, 18, 27, 40, 24.99, 15.00), -- 40 Power Strips

-- Order 19 (Global Enterprises - repeat)
(57, 19, 13, 20, 159.99, 10.00),-- 20 File Cabinets
(58, 19, 19, 50, 18.99, 18.00), -- 50 Staplers
(59, 19, 20, 100, 9.99, 20.00), -- 100 Folder Sets

-- Order 20 (Tech Solutions Inc - subscription)
(60, 20, 22, 100, 99.99, 25.00),-- 100 Office 365 subscriptions
(61, 20, 21, 100, 49.99, 25.00),-- 100 Antivirus licenses
(62, 20, 23, 50, 34.99, 15.00); -- 50 Laptop Bags

SET IDENTITY_INSERT OrderDetail OFF;

PRINT '   ✓ Inserted 62 order detail records';
PRINT '';

-- ============================================
-- Step 6: Update Order TotalAmount
-- ============================================
PRINT '6. Calculating order totals...';

UPDATE o
SET o.TotalAmount = (
    SELECT SUM(od.TotalAmount)
    FROM OrderDetail od
    WHERE od.OrderID = o.OrderID
)
FROM [Order] o;

PRINT '   ✓ Order totals calculated';
PRINT '';

-- ============================================
-- Step 7: Display Summary Statistics
-- ============================================
PRINT '==========================================';
PRINT 'DATABASE POPULATED SUCCESSFULLY!';
PRINT '==========================================';
PRINT '';
PRINT 'Summary Statistics:';
PRINT '-------------------';

SELECT 'Users' AS TableName, COUNT(*) AS RecordCount FROM Users
UNION ALL
SELECT 'Items', COUNT(*) FROM Item
UNION ALL
SELECT 'Agents', COUNT(*) FROM Agent
UNION ALL
SELECT 'Orders', COUNT(*) FROM [Order]
UNION ALL
SELECT 'OrderDetails', COUNT(*) FROM OrderDetail;

PRINT '';
PRINT 'Sample Queries to Verify Data:';
PRINT '--------------------------------';
PRINT '1. View all orders with details:';
PRINT '   SELECT * FROM vw_OrderSummary;';
PRINT '';
PRINT '2. View best selling items:';
PRINT '   SELECT TOP 10 * FROM vw_BestSellingItems ORDER BY TotalQuantitySold DESC;';
PRINT '';
PRINT '3. View top customers:';
PRINT '   SELECT TOP 10 * FROM vw_TopCustomers ORDER BY TotalSpent DESC;';
PRINT '';
PRINT '4. Get order with details (Order ID 1):';
PRINT '   EXEC sp_GetOrderWithDetails @OrderID = 1;';
PRINT '';
PRINT '5. Get items purchased by specific agent (Agent ID 1):';
PRINT '   EXEC sp_GetItemsByAgent @AgentID = 1;';
PRINT '';
PRINT '==========================================';
PRINT 'Ready for Application Development!';
PRINT '==========================================';
