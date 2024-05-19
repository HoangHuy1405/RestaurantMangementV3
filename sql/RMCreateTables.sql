create Database RMv7;
use RMv7;
go
-- create table Account
create table Account
(	
	accID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	username VARCHAR(50) unique not null,
	password VARCHAR(50) not null,
	fullname VARCHAR(50) not null,
	email VARCHAR(50),
	phoneNum VARCHAR(10),
	balance DECIMAL(10,2)
)
-- create table Manager
create table Manager
(	
	mID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	accID VARCHAR(4) foreign key references Account(accID)
)
-- create table Category
create table Category
(
	cateID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	cateName VARCHAR(50) not null
)
-- create table Product
create table Product
(
	productID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	productName VARCHAR(50) not null,
	description VARCHAR(50),
	price DECIMAL(10,2),
	cateID VARCHAR(4) foreign key references Category(cateID)
)
-- create table Orders
create table Orders
(
	orderID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	date DATETIME,
	totalPrice DECIMAL(10,2),
	accID VARCHAR(4) foreign key references Account(accID)
)
-- create table OrderDetail
create table OrderDetail
(
	odID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	quantity INT,
	productID VARCHAR(4) foreign key references Product(productID),
	orderID VARCHAR(4) foreign key references Orders(orderID) on delete cascade
)
-- create table Voucher
create table Voucher
(
	voucherID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	voucherName VARCHAR(50) not null,
	discount DECIMAL(10,2),
	exp_date DATETIME
)
-- create table Room
create table Room
(
	roomID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	type varchar(50),
	pricePerTable DECIMAL(10, 2),
	maxTable int
)
-- create table [Table]
create table [Table]
(
	tableID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	numchairs int not null,
	roomID VARCHAR(4) foreign key references Room(roomID) not null,
)
-- create table Booking
create table Booking
(
	bookID VARCHAR(4) PRIMARY KEY DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	totalPrice DECIMAL(10,2),
	timeBegin DATETIME,
	timeEnd DATETIME,
	accID VARCHAR(4) foreign key references Account(accID),
	tableID VARCHAR(4) foreign key references [Table](tableID) ON DELETE SET NULL,
)
-- create table Bill
create table Bill
(	
	billID VARCHAR(4) primary key DEFAULT (SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 4)),
	orderID VARCHAR(4) foreign key references Orders(orderID),
	bookId VARCHAR(4) foreign key references Booking(bookID),
	accID VARCHAR(4) foreign key references Account(accID),
	voucherID VARCHAR(4) foreign key references Voucher(voucherID) ON DELETE SET NULL,
	date DATETIME,
	customerAddress VARCHAR(50),
    customerName VARCHAR(50),
    customerEmail VARCHAR(50),
	customerPhone VARCHAR(10),
    paymentMethods VARCHAR(50),
	status VARCHAR(50) not null,
	note VARCHAR(50),
	totalPrice DECIMAL(10,2),
	type VARCHAR(50),
)


