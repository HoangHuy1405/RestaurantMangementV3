create Database RM;
use RM;
go
-- create table Account
create table Account
(	
	accID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	username VARCHAR(50) UNIQUE NOT NULL,
	password VARCHAR(50) NOT NULL,
	fullname VARCHAR(50) NOT NULL,
	email VARCHAR(50),
	phoneNum VARCHAR(10),
	balance DECIMAL(10,2)
)
-- create table Manager
create table Manager
(	
	mID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID)
)
-- create table Category
create table Category
(
	cateID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	cateName VARCHAR(50) NOT NULL
)
-- create table Product
create table Product
(
	productID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	productName VARCHAR(50) NOT NULL,
	description VARCHAR(50),
	price DECIMAL(10,2),
	cateID VARCHAR(4) FOREIGN KEY REFERENCES Category(cateID)
)
-- create table Orders
create table Orders
(
	orderID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	date DATETIME,
	totalPrice DECIMAL(10,2),
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID)
)
-- create table OrderDetail
create table OrderDetail
(
	odID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	quantity INT,
	productID VARCHAR(4) FOREIGN KEY REFERENCES Product(productID) ON DELETE SET NULL,
	orderID VARCHAR(4) FOREIGN KEY REFERENCES Orders(orderID) ON DELETE CASCADE
)
-- create table Voucher
create table Voucher
(
	voucherID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	voucherName VARCHAR(50) NOT NULL,
	discount DECIMAL(10,2),
	exp_date DATETIME
)
-- create table Room
create table Room
(
	roomID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	type varchar(50) NOT NULL,
	pricePerTable DECIMAL(10, 2) NOT NULL,
	maxTable INT 
)
-- create table [Table]
create table [Table]
(
	tableID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	numchairs int NOT NULL,
	roomID VARCHAR(4) FOREIGN KEY REFERENCES Room(roomID) NOT NULL,
)
-- create table Booking
create table Booking
(
	bookID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	totalPrice DECIMAL(10,2),
	timeBegin DATETIME NOT NULL,
	timeEnd DATETIME NOT NULL,
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID) NOT NULL,
	tableID VARCHAR(4) FOREIGN KEY REFERENCES [Table](tableID) ON DELETE SET NULL,
)
-- create table Bill
create table Bill
(	
	billID VARCHAR(10) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 10)),
	orderID VARCHAR(4) FOREIGN KEY REFERENCES Orders(orderID),
	bookId VARCHAR(4) FOREIGN KEY REFERENCES Booking(bookID),
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID),
	voucherID VARCHAR(4) FOREIGN KEY REFERENCES Voucher(voucherID) ON DELETE SET NULL,
	date DATETIME,
	customerAddress VARCHAR(50),
    customerName VARCHAR(50),
    customerEmail VARCHAR(50),
	customerPhone VARCHAR(10),
    paymentMethods VARCHAR(50),
	status VARCHAR(50) NOT NULL,
	note VARCHAR(50),
	totalPrice DECIMAL(10,2) NOT NULL,
	type VARCHAR(50),
)

