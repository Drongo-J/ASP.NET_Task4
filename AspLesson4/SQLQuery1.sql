CREATE DATABASE ProductDb
USE ProductDb
GO
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Title NVARCHAR(50) NOT NULL
)
GO 
INSERT INTO Categories([Title])
VALUES('Drink'),('Beverages'),('Junks'),('Hot Meals')

CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
Price MONEY NOT NULL
)

INSERT INTO Products([Name],[Price])
VALUES('Apple', 3000),('Samsung',2202),('XIAOMI', 990),('BlackBerry', 650)

SELECT * FROM Categories