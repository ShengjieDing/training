--1.	What is View? What are the benefits of using views?
	--virtual table that contains data from one or multiple table
	--it simplifies the data
--2.	Can data be modified through views?
	--yes, views contain reference to the orginal data and modifying it also modifys teh original data
--3.	What is stored procedure and what are the benefits of using it?
	--prepared sql query taht can be reused
	--limits the tyes of action user can perform, increasing security
	--it has the benefit of being higher performance
--4.	What is the difference between view and stored procedure?
	--store procedure is a collection of query that can perform data manipulation
--5.	What is the difference between stored procedure and functions?
	--fuctions are typically used for calculations, stored procedure usd for dml
	--stored procedure do not necessarily need input/out, while functions do 
	--sp can call function, function cannot call sp
--6.	Can stored procedure return multiple result sets?
	--yes
--7.	Can stored procedure be executed as part of SELECT Statement? Why?
	--no, sp may not return a value
--8.	What is Trigger? What types of Triggers are there?
	--trigger are a type of sp that is ran on a events occuring
	--Types of triggers:
		--DML: INSERT UPDATE DELETE
		--DDL: CREATE ALTER DROP
		--LOCKDOWN: AUTHENTICATION 
--9.	What is the difference between Trigger and Stored Procedure?
	--trigger is ran passively when an event occure
	--sp are called manually 

--1.
CREATE VIEW view_product_order_ding 
AS
SELECT p.ProductID, p.ProductName, od.Quantity
FROM Products as p 
JOIN 
[Order Details] as od
ON p.ProductID = od.ProductID

--SELECT * 
--FROM view_product_order_ding
--DROP VIEW view_product_order_ding

--2.
CREATE PROC sp_product_order_quantity_ding @ID int, @TotalQuantity int output
AS
BEGIN
	SELECT SUM(od.Quantity) as TotalQuantity
	FROM [Order Details] as od
	WHERE od.ProductID = @ID
END

--DECLARE @Total int
--EXEC sp_product_order_quantity_ding @ID = 1, @TotalQuantity = @Total output
--DROP PROC sp_product_order_quantity_ding

--3.
CREATE PROC sp_product_order_city_ding @ProdName varchar(20)
AS
BEGIN
	SELECT TOP 5 o.ShipCity, SUM(od.Quantity) as TotalQuantity
	FROM Products as p
	JOIN
	[Order Details] as od
	ON p.ProductID = od.ProductID
	JOIN
	Orders as o
	ON o.OrderID = od.OrderID
	WHERE p.ProductName = @ProdName
	GROUP BY o.ShipCity
	ORDER BY 2 DESC
END

--EXEC sp_product_order_city_ding @ProdName = 'Chang'
--DROP PROC sp_product_order_city_ding

--4
CREATE TABLE city_ding(
	Id int primary key,
	City varchar(20)
)

CREATE TABLE people_ding(
	Id int primary key,
	Name varchar(20),
	City int FOREIGN KEY REFERENCES city_ding(Id) ON DELETE SET NULL
)
INSERT INTO city_ding
VALUES (1, 'Seattle'), (2, 'Green Bay')

INSERT INTO people_ding
VALUES (1, 'Aron Rodgers', 2), (2, 'Russell Wilson', 1), (3, 'Jody Nelson', 2)

DELETE FROM city_ding
WHERE City = 'Seattle'

INSERT INTO city_ding
VALUES (3,'Madison')

UPDATE people_ding
SET City = 3 
WHERE City is NULL 

CREATE VIEW Packers_ding
AS
	SELECT p.Name
	FROM people_ding p
	JOIN
	city_ding as c 
	ON c.City = c.Id
	WHERE c.City = 'Green Bay'

DROP VIEW Packers_ding
DROP TABLE people_ding
DROP TABLE city_ding

--5
CREATE PROC sp_birthday_employees_ding
AS 
	CREATE TABLE birthday_employees_ding(
		Id int primary key identity,
		FirstName varchar(20),
		LastName varchar(20)
	)
	INSERT INTO birthday_employees_ding
	SELECT e.FirstName, e.LastName 
	FROM Employees e
	WHERE MONTH(e.BirthDate) = 2 

--EXEC sp_birthday_employees_ding
--SELECT * FROM birthday_employees_ding
--SELECT * FROM Employees where MONTH(BirthDate) = 2 
DROP TABLE birthday_employees_ding
DROP PROC sp_birthday_employees_ding

--displays 
--id | FirstName | LastName
--1  | Andew     | Fuller 


--6
--UNION both table then compare count row of union vs row of original tables

--7
--CREATE TABLE users (
--	Id int primary key identity,
--	FirstName varchar(20),
--	LastName varchar(20),
--	MiddleName varchar(20)
--)
--INSERT INTO users
--VALUES ('John', 'Mike', NULL), ('Mike', 'White', 'M')
--SELECT * FROM users

SELECT(
CASE WHEN MiddleName IS NOT NULL 
THEN FirstName + ' ' + MiddleName + '. ' + LastName
ELSE FirstName + ' ' + LastName END) as userName
FROM users

--DROP TABLE users 

--8
--CREATE TABLE students (
--	Id int primary key identity,
--	sName varchar(20),
--	marks int,
--	sex varchar(20)
--)
--INSERT INTO students
--VALUES ('Ci', 70, 'f'),('Bob', 80, 'm'),('Li', 90, 'f'),('Mi', 95, 'm')

SELECT TOP 1 marks 
FROM students
WHERE sex = 'f'
order by marks desc

--9
SELECT * 
FROM students
ORDER BY sex, marks desc

--DROP TABLE students
