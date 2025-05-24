-- 1. Query sales employees and their status on reaching the SalesQuota
USE AdventureWorks2019

SELECT FullName = (SELECT CONCAT(FirstName, '  ', LastName)
		FROM Person.Person AS P
		WHERE P.BusinessEntityID = SP.BusinessEntityID),
	SP.SalesYTD,
	SP.SalesQuota,
	Status = CASE
		WHEN SP.SalesYTD >= SP.SalesQuota THEN 'Goal exceeded'
		WHEN SP.SalesYTD >= SP.SalesQuota * 0.8 THEN 'Goal almost reached'
		ELSE 'Goal far from reached'
	END
FROM Sales.SalesPerson AS SP
WHERE SP.SalesQuota IS NOT NULL

-- 2. Query the revenue on each saddle type
USE AdventureWorks2019

SELECT P.ProductID,
	P.Name AS SaddleName,
	TotalRevenue = ISNULL(
			(SELECT SUM(SD.LineTotal)
			FROM Sales.SalesOrderDetail AS SD
			WHERE SD.ProductID = P.ProductID), 
		0)
FROM Production.Product AS P
WHERE EXISTS
	(SELECT *
	FROM Production.ProductSubcategory AS PS
	WHERE PS.ProductSubcategoryID = P.ProductSubcategoryID
		AND PS.Name = 'Saddles')
ORDER BY TotalRevenue DESC

-- 3. Products in shopping cart that are on special offers
USE AdventureWorks2019

SELECT P.ProductID,
	P.Name
FROM Production.Product AS P
WHERE ProductID IN 
	(SELECT SC.ProductID
	FROM Sales.ShoppingCartItem AS SC
		WHERE SC.ProductID IN
			(SELECT SOP.ProductID
			FROM Sales.SpecialOfferProduct AS SOP
			WHERE SOP.SpecialOfferID IN 
				(SELECT SO.SpecialOfferID
				FROM Sales.SpecialOffer AS SO
				WHERE MinQty <= SC.Quantity) 
					AND SOP.SpecialOfferID != 1))

-- 4. Query products above average ListPrice (438.6662) and by how much
USE AdventureWorks2019

SELECT P.Name,
	P.ListPrice,
	CONCAT(
		(CONVERT(FLOAT, P.ListPrice / 
			(SELECT AVG(ListPrice)
			FROM Production.Product)
		- 1) * 100), '%') 
	AS AbvAverage
FROM Production.Product AS P
WHERE ListPrice >
	(SELECT AVG(ListPrice)
	FROM Production.Product)
ORDER BY P.ListPrice DESC

-- 5. Query customers that placed orders abv the avg order total (3915.9951)
USE AdventureWorks2019

SELECT PersonID,
	FullName = CONCAT(P.FirstName, ' ', P.LastName),
	TotalOrders = (SELECT COUNT(*)
		FROM Sales.SalesOrderHeader AS SH
		WHERE SH.CustomerID = C.CustomerID),
	AvgOrderValue = (SELECT AVG(TotalDue)
		FROM Sales.SalesOrderHeader AS SH
		WHERE SH.CustomerID = C.CustomerID),
	TotalSpent = (SELECT SUM(TotalDue)
		FROM Sales.SalesOrderHeader AS SH
		WHERE SH.CustomerID = C.CustomerID)
FROM Sales.Customer AS C
INNER JOIN Person.Person AS P
	ON C.PersonID = P.BusinessEntityID
WHERE PersonID IS NOT NULL
	AND EXISTS 
		(SELECT 1
		FROM Sales.SalesOrderHeader AS SH
		WHERE SH.CustomerID = C.CustomerID
			AND SH.TotalDue > 
				(SELECT AVG(TotalDue)
				FROM Sales.SalesOrderHeader))
ORDER BY TotalSpent DESC

-- 6. Query top selling 3 products from each subcategory
USE AdventureWorks2019

SELECT *
FROM(
	SELECT ProductRank = ROW_NUMBER() OVER (PARTITION BY PS.Name ORDER BY SUM(SD.LineTotal) DESC),
		Subcategory = PS.Name,
		P.Name,
		AvgSale = AVG(SD.LineTotal),
		SaleCount = COUNT(SD.ProductID),
		TotalRevenue = SUM(SD.LineTotal)
	FROM Production.Product AS P
	INNER JOIN Sales.SalesOrderDetail AS SD
		ON SD.ProductID = P.ProductID
	INNER JOIN Production.ProductSubcategory AS PS
		ON PS.ProductSubcategoryID = P.ProductSubcategoryID
	GROUP BY PS.Name, P.Name
) AS PRC 
WHERE ProductRank <= 3
ORDER BY Subcategory, ProductRank

-- 7. Query the territories with sales year to date greater than the average (5275120.9953)
USE AdventureWorks2019

SELECT ST.TerritoryID,
	ST.Name,
	ST.CountryRegionCode,
	SalesPersonCount = (SELECT COUNT(*) 
		FROM Sales.SalesPerson AS SP
		WHERE SP.TerritoryID = ST.TerritoryID),
	ST.SalesYTD
FROM Sales.SalesTerritory AS ST
WHERE ST.SalesYTD >
	(SELECT AVG(ST2.SalesYTD)
	FROM Sales.SalesTerritory AS ST2
	WHERE ST2.SalesYTD> 0)
ORDER BY ST.SalesYTD DESC

--8. Query the employees with sales above than avg (2133975.9943)
USE AdventureWorks2019

SELECT E.BusinessEntityID AS EmployeeID,
	FullName = (SELECT CONCAT(P.FirstName, ' ', P.LastName)
	FROM Person.Person AS P
	WHERE P.BusinessEntityID = SP.BusinessEntityID),
	E.JobTitle,
	SP.SalesYTD
FROM HumanResources.Employee AS E
INNER JOIN Sales.SalesPerson AS SP
	ON SP.BusinessEntityID = E.BusinessEntityID
WHERE SP.SalesYTD >
	(SELECT AVG(SP2.SalesYTD)
	FROM Sales.SalesPerson AS SP2
	WHERE SP2.SalesYTD > 0)
ORDER BY SP.SalesYTD DESC
