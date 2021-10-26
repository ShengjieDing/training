USE AdventureWorks2019
GO

--1 
SELECT p.ProductID, p.Name, p.Color, p.ListPrice
FROM Production.product as p

--2
SELECT p.ProductID, p.Name, p.Color, p.ListPrice
FROM Production.product as p
WHERE p.ListPrice != 0 

--3
SELECT p.ProductID, p.Name, p.Color, p.ListPrice
FROM Production.product as p
WHERE p.Color IS NULL

--4
SELECT p.ProductID, p.Name, p.Color, p.ListPrice
FROM Production.product as p
WHERE p.Color IS NOT NULL

--5
SELECT p.ProductID, p.Name, p.Color, p.ListPrice
FROM Production.product as p
WHERE p.Color IS NOT NULL
AND p.ListPrice > 0

--6
SELECT p.Name + ' ' + p.color AS NameColor 
FROM Production.product as p
WHERE p.Color IS NOT NULL

--7
SELECT 'NAME:' + p.Name + ' -- ' + 'COLOR:' + p.color AS [Name and Color] 
FROM Production.product as p
WHERE p.Color IS NOT NULL

--8
SELECT p.ProductID, p.Name
FROM Production.product as p
WHERE p.ProductID BETWEEN 400 and 500

--9
SELECT p.ProductID, p.Name, p.Color
FROM Production.product as p
WHERE p.Color IN ('black','blue')

--10
SELECT p.ProductID, p.Name, p.Color, p.ListPrice
FROM Production.product as p 
WHERE p.Name LIKE 'S%'

--11
SELECT p.Name, p.ListPrice
FROM Production.product as p 
ORDER BY p.Name ASC

--12
SELECT p.Name, p.ListPrice
FROM Production.product as p 
WHERE p.Name LIKE 'A%' or p.Name LIKE 'S%'
ORDER BY p.Name ASC

--13
SELECT p.Name
FROM Production.product as p 
WHERE p.Name LIKE 'SPO[^k]%' 
ORDER BY p.Name ASC

--14
SELECT DISTINCT p.Color
FROM Production.product as p 
ORDER BY p.Color DESC

--15
SELECT DISTINCT p.ProductSubcategoryID, p.Color
FROM Production.product as p 
WHERE p.ProductSubcategoryID IS NOT NULL
AND p.Color IS NOT NULL
