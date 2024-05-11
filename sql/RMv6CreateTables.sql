CREATE DATABASE testRMv3;
USE testRMv3;

-- Create Account table
CREATE TABLE Account
(	
	accID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	username VARCHAR(50) unique not null,
	password VARCHAR(50) not null,
	fullname VARCHAR(50) not null,
	email VARCHAR(50),
	phoneNum VARCHAR(10),
	balance real
)

-- Create Manager table
CREATE TABLE Manager
(
	mID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID) NOT NULL,
)
-- Create Category table
CREATE TABLE Category
(
	cateID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	cateName VARCHAR(50) NOT NULL
)

-- Create Product table
CREATE TABLE Product
(
	productID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	productName VARCHAR(50) NOT NULL,
	description VARCHAR(50),
	price DECIMAL(10, 2) NOT NULL,
	cateID VARCHAR(4) FOREIGN KEY REFERENCES Category(cateID) NOT NULL,
)
-- Create Voucher table
CREATE TABLE Voucher
(
	voucherID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	voucherName VARCHAR(50) NOT NULL,
	discount DECIMAL(10, 2) NOT NULL,
	exp_date DATETIME NOT NULL
)
-- Create Bill table
CREATE TABLE Bill
(
	billID VARCHAR(10) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 10)),
	date DATETIME NOT NULL,
	Address VARCHAR(200) NOT NULL,
    customerName VARCHAR(100) NOT NULL,
    customerEmail VARCHAR(100) NOT NULL,
	customerPhone VARCHAR(20) NOT NULL,
    paymentMethods VARCHAR(100) NOT NULL,
	Note TEXT,
	status VARCHAR(50) DEFAULT 'Pending',
	total_price real NOT NULL,
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID) NOT NULL,
	voucherID VARCHAR(4) FOREIGN KEY REFERENCES Voucher(voucherID),
)

-- Create AccOrderProduct table
CREATE TABLE AccOrderProduct
(
	orderID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	quantity INT NOT NULL,
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID) NOT NULL,
	billID VARCHAR(10) FOREIGN KEY REFERENCES Bill(billID) NOT NULL,
	productID VARCHAR(4) FOREIGN KEY REFERENCES Product(productID) NOT NULL
)

-- Create Room table
CREATE TABLE Room
(
	roomID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	type varchar(50),
	PricePerTable DECIMAL(10, 2) NOT NULL,
	MaximumTable INT NOT NULL
)

-- Create "Table" table
CREATE TABLE "Table"
(
	tableID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	numchair INT NOT NULL,
	roomID VARCHAR(4) FOREIGN KEY REFERENCES Room(roomID) NOT NULL,
)

-- Create AccBookTable table
CREATE TABLE AccBookTable
(
	tableID VARCHAR(4) FOREIGN KEY REFERENCES "Table"(tableID),
	accID VARCHAR(4) FOREIGN KEY REFERENCES Account(accID) NOT NULL,
	timeBegin DATETIME NOT NULL,
	timeEnd DATETIME NOT NULL
	PRIMARY KEY (accID, tableID, timeBegin, timeEnd),
)

