/*
1. From the Person.Person table write a query in SQL to return all
rows and a subset of the columns (FirstName, LastName, businessentityid) 
from the person table in the AdventureWorks database. The third column 
heading is renamed to Employee_id. Arranged the output in ascending order 
by lastname.
*/
USE AdventureWorks2019

SELECT FirstName, 
		LastName, 
		BusinessEntityID AS Employee_id 
	FROM Person.Person
ORDER BY LastName

------------------------------------------------------------------------

/*
2. From the Person.PersonPhone table write a query in SQL to find the 
persons whose last name starts with letter 'L'. Return BusinessEntityID, 
FirstName, LastName, and PhoneNumber. Sort the result on lastname and 
firstname.
*/
USE AdventureWorks2019

SELECT PP.BusinessEntityID, 
		P.FirstName, 
		P.LastName, 
		PP.PhoneNumber 
	FROM Person.PersonPhone AS PP
INNER JOIN Person.Person AS P
	ON P.BusinessEntityID = PP.BusinessEntityID
WHERE P.LastName LIKE 'L%'
ORDER BY LastName, FirstName

------------------------------------------------------------------------

/*
3.  From the following tables: Sales.SalesPerson, Person.Person, 
Person.Address

Write a query in SQL to retrieve the salesperson for each PostalCode who 
belongs to a territory and SalesYTD is not zero. Return row numbers of 
each group of PostalCode, last name, salesytd, postalcode column. Sort 
the salesytd of each postalcode group in descending order. Shorts the 
postalcode in ascending order.
*/
USE AdventureWorks2019

SELECT ROW_NUMBER() OVER (PARTITION BY A.PostalCode ORDER BY SP.SalesYTD DESC) AS RowNumber, 
		PP.LastName, 
		SP.SalesYTD, 
		A.PostalCode
	FROM Sales.SalesPerson AS SP
INNER JOIN Person.Person AS PP
	ON SP.BusinessEntityID = PP.BusinessEntityID
INNER JOIN Person.BusinessEntityAddress AS BEA
	ON SP.BusinessEntityID = BEA.BusinessEntityID
INNER JOIN Person.Address AS A
	ON BEA.AddressID = A.AddressID
WHERE SP.SalesYTD > 0 
	AND SP.TerritoryID IS NOT NULL
ORDER BY A.PostalCode ASC, SP.SalesYTD DESC

------------------------------------------------------------------------

/*
4. From the following table: Sales.SalesOrderDetail 

Write a query in SQL to retrieve the total cost of each salesorderID that 
exceeds 100000. Return SalesOrderID, total cost.
*/
USE AdventureWorks2019

SELECT SalesOrderID,
		SUM(LineTotal) AS TotalCost
	FROM Sales.SalesOrderDetail
GROUP BY SalesOrderID
HAVING SUM(LineTotal) > 100000