--1.	What is a result set?
	--The output set of a query 
--2.	What is the difference between Union and Union All?
	--UNION will remove duplicate records columns
	--UNION will sort the records from first col 
	--UNION cannot be used in recursive cte 
--3.	What are the other Set Operators SQL Server has?
	--INTERSECT, EXCEPT
--4.	What is the difference between Union and Join?
	--JOIN combines data from tables based on a conditon
	--UNION combines result of SELECT statments
--5.	What is the difference between INNER JOIN and FULL JOIN?
	--INNER JOIN returns matching records between tables
	--FULL JOIN returns all records from both tables
--6.	What is difference between left join and outer join
	--LEFT JOIN return record left table and matching record from right table 
	--LEFT JOIN is a type of OUTER JOIN
	--OUTER JOIN also include 
		--RIGHT JOIN which returns record from right table and matching record from left table
		--FULL JOIN returns all records from both tables
--7.	What is cross join?
	--CROSS JOIN returns the cartesian product of two tables
--8.	What is the difference between WHERE clause and HAVING clause?
	--WHERE cannot be used not aggregated fields
	--HAVING is only applied on aggregated fields
	--WHERE goes before aggregations
	--WHERE can be used with SELECT, UPDATE, and DELECT
	--HAVING can only be used with SELECT 
--9.	Can there be multiple group by columns?
	--Yes GROUP BY must be use for all individual field when used with aggregate fields


--1.
SELECT COUNT(*)
FROM Production.Product as p

--2.
SELECT COUNT(p.ProductSubcategoryID)
FROM Production.Product as p

--3.
SELECT p.ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product as p
GROUP BY p.ProductSubcategoryID

--4.
SELECT COUNT(*)-COUNT(p.ProductSubcategoryID)
FROM Production.Product as p

--5.
SELECT SUM(p.Quantity) as TotalProducts
FROM Production.ProductInventory as p

--6.
SELECT p.ProductID, SUM(p.Quantity) as TheSum
FROM Production.ProductInventory as p
WHERE p.LocationID = 40
GROUP BY p.ProductID
HAVING SUM(p.Quantity) < 100

--7.
SELECT TOP 100 p.Shelf, p.ProductID, SUM(p.Quantity) as TheAvg
FROM Production.ProductInventory as p
WHERE p.LocationID = 40
GROUP BY p.shelf, p.ProductID
HAVING SUM(p.Quantity) < 100

--8.
SELECT p.ProductID, AVG(p.Quantity) as TheAvg
FROM Production.ProductInventory as p
WHERE p.LocationID = 10
GROUP BY p.ProductID

--9.
SELECT p.ProductID, p.Shelf, AVG(p.Quantity) as TheAvg
FROM Production.ProductInventory as p
GROUP BY p.ProductID, p.Shelf

--10.
SELECT p.ProductID, p.Shelf, AVG(p.Quantity) as TheAvg
FROM Production.ProductInventory as p
WHERE p.Shelf != 'N/A'
GROUP BY p.ProductID, p.Shelf

--11.
SELECT p.color, p.class, COUNT(p.color) as TheCount, AVG(p.ListPrice) as AvgPrice
FROM Production.Product as p
WHERE p.color IS NOT NULL 
AND p.class IS NOT NULL 
GROUP by p.color, p.class

--12.
SELECT cr.Name as country, sp.Name as Province 
FROM Person.CountryRegion as cr
JOIN
Person.StateProvince as sp
ON cr.CountryRegionCode = sp.CountryRegionCode

--13.
SELECT cr.Name as country, sp.Name as Province 
FROM Person.CountryRegion as cr
JOIN
Person.StateProvince as sp
ON cr.CountryRegionCode = sp.CountryRegionCode
WHERE cr.Name IN ('Germany', 'Canada')

--14.
SELECT DISTINCT p.ProductName
FROM Products as p
JOIN
[Order Details] as od
ON od.ProductID = p.ProductID
JOIN
Orders as o
ON o.OrderID = od.OrderID
WHERE DATEDIFF(YEAR, o.OrderDate, GETDATE()) <= 25

--15.
SELECT TOP 5 o.ShipPostalCode,SUM(od.Quantity) as TotalOrder
FROM [Order Details] as od
JOIN
Orders as o
ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY TotalOrder DESC

--16.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) as TotalOrder
FROM [Order Details] as od
JOIN
Orders as o
ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
AND DATEDIFF(YEAR, o.OrderDate, GETDATE()) <= 25
GROUP BY o.ShipPostalCode
ORDER BY TotalOrder DESC

--17.
SELECT c.city, COUNT(c.CompanyName) as NumOfCustomer
FROM Customers c
GROUP BY c.City

--18.
SELECT c.city, COUNT(c.CustomerID) as NumOfCustomer
FROM Customers as c
GROUP BY c.City
HAVING COUNT(c.CustomerID) > 2

--19.
SELECT DISTINCT c.CompanyName
FROM Customers c 
JOIN
Orders as o 
ON o.CustomerID = c.CustomerID
WHERE OrderDate > '1998-01-01'

--20.
SELECT c.CompanyName
FROM Customers c 
JOIN
Orders as o 
ON o.CustomerID = c.CustomerID
ORDER BY o.OrderDate DESC

--21.
SELECT DISTINCT c.CompanyName, COUNT(od.Quantity) AS [NumOfProd]
FROM Customers c 
JOIN
Orders as o 
ON o.CustomerID = c.CustomerID
JOIN
[Order Details] as od
on od.OrderID = o.OrderID
GROUP BY c.CompanyName
ORDER BY 1

--22.
SELECT o.CustomerID, SUM(od.Quantity) as TotalProducts
FROM Orders as o 
JOIN
[Order Details] as od
on od.OrderID = o.OrderID
GROUP BY o.CustomerID
HAVING SUM(od.Quantity) > 100


--23.
SELECT sup.CompanyName as [Supplier Company Name], shp.CompanyName as [Shipping Company Name]
FROM Suppliers as sup
CROSS JOIN 
Shippers as shp

--24.
SELECT o.OrderDate, p.ProductName
FROM orders as o
JOIN
[Order Details] as od
ON o.OrderID = od.OrderID
JOIN 
Products p 
ON od.ProductID = p.ProductID
ORDER BY 1

--25.
SELECT DISTINCT e1.Title, e1.FirstName + ' ' + e1.LastName as [EmployeeName],
e2.FirstName + ' ' + e2.LastName as [EmployeeName] 
FROM Employees e1
JOIN
Employees e2
ON e1.Title = e2.Title
AND e1.EmployeeID != e2.EmployeeID

--26.
SELECT e1.FirstName + ' ' + e1.LastName as [ManagerName]
FROM Employees e1
JOIN
(SELECT e.ReportsTo
FROM Employees e
GROUP BY e.ReportsTo
HAVING COUNT(ReportsTo) >= 2) e2
ON e1.EmployeeID = e2.ReportsTo

--27.
SELECT c.City, c.CompanyName as name, c.ContactName, 'Customer' Type
FROM Customers c
UNION 
SELECT s.City, s.CompanyName as name, s.ContactName, 'Supplier' Type
FROM Suppliers s
ORDER by 1