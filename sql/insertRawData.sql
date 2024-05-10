use testRMv3;
-- Inserting data into the Account table
INSERT INTO Account (accID, username, password, fullname, email, phoneNum, balance)
VALUES 
('47BA','john_doe', 'password', 'John Doe', 'john@example.com', '1234567890', 100.00),
('13E1','jane_smith', 'password123', 'Jane Smith', 'jane@example.com', '9876543210', 50.00),
('7628','admin', 'admin123', 'Admin User', 'admin@example.com', '5555555555', 500.00);
-- Inserting data into the Manager table
INSERT INTO Manager (accID) values ('7628');

-- Inserting data into the Voucher table
INSERT INTO Voucher (voucherID ,voucherName, discount, exp_date)
VALUES 
('86E1','Summer Discount', 10.00, '2024-09-30'),
('975D','Weekend Special', 15.00, '2024-12-31');



-- Inserting data into the Category table
INSERT INTO Category (cateID, cateName)
VALUES 
('407F','Appetizers'),
('757B','Main Course'),
('D8F3','Desserts');

-- Inserting data into the Product table
INSERT INTO Product (productID,productName, description, price, cateID)
VALUES 
('42A6','Caesar Salad', 'Fresh lettuce with Caesar dressing', 8.99, '407F'),
('F640','Grilled Chicken', 'Grilled chicken breast with vegetables', 12.99, '757B'),
('1557','Chocolate Cake', 'Decadent chocolate cake', 6.99, 'D8F3'),
('84FE','Pho','vietnamese traditions', 10.4, '757B');


-- Inserting data into the Bill table
INSERT INTO Bill (billID, date, Address, customerName, customerEmail, customerPhone, paymentMethods, Note, status, total_price, accID, voucherID)
VALUES 
('7ACDDC94-D','2024-05-01', '123 Main St', 'John Doe', 'john@example.com', '1234567890', 'Cash', 'No notes', 'Pending', 150.00, '47BA', '86E1'),
('A3DDCEB0-2','2024-05-02', '456 Elm St', 'Jane Smith', 'jane@example.com', '9876543210', 'Credit Card', 'Special instructions', 'Pending', 200.00, '7628', NULL),
('67AA0BC7-2','2024-05-03', '789 Oak St', 'Michael Johnson', 'michael@example.com', '5551234567', 'Cash', 'N/A', 'Pending', 250.00, '13E1', '86E1'),
('FDB18959-0','2024-05-04', '101 Pine St', 'Emily Brown', 'emily@example.com', '3219876543', 'Credit Card', 'Gift wrap required', 'Pending', 350.00, '13E1', NULL);

-- Inserting data into the AccOrderProduct table
INSERT INTO AccOrderProduct (orderID,quantity, accID, billID, productID) 
VALUES 
('CFAC',2, '13E1', '67AA0BC7-2', '84FE'),
('EFD2',3, '13E1', '67AA0BC7-2', '1557'),
('F44F',4, '13E1', '67AA0BC7-2', 'F640'),
('38CF',3, '47BA', '7ACDDC94-D', 'F640'),
('73CF',3, '47BA', '7ACDDC94-D', '42A6'),
('C79D',3, '7628', 'A3DDCEB0-2', '84FE'),
('9205',10, '7628', 'FDB18959-0', '1557'),
('65BA',3, '7628', 'FDB18959-0', '84FE');



-- Inserting data into the Room table
INSERT INTO Room (roomID,type, PricePerTable, MaximumTable) 
VALUES 
('6B0D','Normal', 50.00, 4),
('B5A2','Normal', 75.00, 6),
('DD92','Deluxe', 100.00, 8);
-- Inserting data into the Tables table
INSERT INTO [Table] (tableID, numchair, roomID) 
VALUES 
('838A', 4, '6B0D'),
('AEE6', 6, 'DD92'),
('C2F3', 6, 'B5A2'),
('B028', 8, 'DD92');

-- Inserting data into the AccBookTable table

  INSERT INTO AccBookTable (tableID, accID, timeBegin, timeEnd)
VALUES 
('838A', '47BA', '2024-05-06 08:00:00', '2024-05-06 10:00:00'),
('AEE6', '13E1', '2024-05-06 11:00:00', '2024-05-06 13:00:00'),
('B028', '13E1', '2024-05-06 09:30:00', '2024-05-06 12:00:00');
