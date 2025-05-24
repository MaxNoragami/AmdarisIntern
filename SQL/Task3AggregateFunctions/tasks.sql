/*
Write at least 8 such queries. Each query should include more 
complex operations like different types of joins, grouping sorting 
and aggregate functions in all the possible places that were 
mentioned in the lesson
*/

-- 1. Query to identify the high-value repeat customers
USE AdventureWorks2019

SELECT 
	C.CustomerID,
	P.FirstName + ' ' + P.LastName AS CustomerName,
	COUNT(SH.SalesOrderID) AS OrderCount,
	FORMAT(SUM(SH.TotalDue), 'C') AS LifetimeValue,
	FORMAT(AVG(SH.TotalDue), 'C') AS AvgOrderSize,
	DATEDIFF(MONTH, MIN(SH.OrderDate), MAX(SH.OrderDate)) AS CustomerLifeMonths,
	CASE
		WHEN COUNT(SH.SalesOrderID) > 3 THEN 'High Activity'
		ELSE 'Low Activity'
	END AS CustomerStatus
FROM Sales.Customer C
LEFT JOIN Sales.SalesOrderHeader SH 
	ON C.CustomerID = SH.CustomerID
LEFT JOIN Person.Person P 
	ON C.PersonID = P.BusinessEntityID
GROUP BY C.CustomerID, P.FirstName, P.LastName
HAVING COUNT(SH.SalesOrderID) > 0
ORDER BY SUM(SH.TotalDue) DESC

-- 2. Query to analyze card type payments and their value
USE AdventureWorks2019

SELECT 
	CC.CardType,
	COUNT(DISTINCT SOH.SalesOrderID) AS OrderCount,
	COUNT(DISTINCT SOH.CustomerID) AS UniqueCustomers,
	FORMAT(SUM(SOH.TotalDue), 'C') AS TotalRevenue,
	FORMAT(AVG(SOH.TotalDue), 'C') AS AvgTransactionSize,
	FORMAT(MAX(SOH.TotalDue), 'C') AS LargestTransaction
FROM Sales.SalesOrderHeader SOH
INNER JOIN Sales.CreditCard CC ON SOH.CreditCardID = CC.CreditCardID
GROUP BY CC.CardType
ORDER BY SUM(SOH.TotalDue) DESC

-- 3. Query that shows the avg of the total due amount on the orders by employees
USE AdventureWorks2019

SELECT E.BusinessEntityID,
	CONCAT(P.FirstName, ' ', P.LastName) AS FullName,
	FORMAT(AVG(PH.TotalDue), 'C') AS TotalDueAverage
FROM HumanResources.Employee AS E
INNER JOIN Purchasing.PurchaseOrderHeader AS PH
	ON E.BusinessEntityID = PH.EmployeeID
INNER JOIN Person.Person AS P
	ON E.BusinessEntityID = P.BusinessEntityID
GROUP BY E.BusinessEntityID, P.FirstName, P.LastName
ORDER BY TotalDueAverage DESC

-- 4. Query that shows the total sales amount per territory
USE AdventureWorks2019

SELECT COALESCE(ST.Name, '*** Total ***') AS Territory,
	RANK() 
		OVER (
			ORDER BY SUM(SH.TotalDue) DESC
		) - 1 AS TerritoryRank,
	COUNT(SH.SalesOrderID) AS TotalOrders,
	FORMAT(SUM(SH.TotalDue), 'C') AS TotalSales,
	FORMAT(AVG(SH.TotalDue), 'C') AS AvgOrderValue
FROM Sales.SalesOrderHeader AS SH
INNER JOIN Sales.SalesTerritory AS ST
	ON SH.TerritoryID = ST.TerritoryID
GROUP BY ROLLUP(ST.Name)

-- 5. Query the overall quality of the product by viewing the scrap rate per product
USE AdventureWorks2019

SELECT 
	P.Name AS ProductName,
	COUNT(WO.WorkOrderID) AS TotalWorkOrders,
	SUM(WO.OrderQty) AS TotalUnitsProduced,
	SUM(WO.ScrappedQty) AS TotalScrapped,
	CAST(SUM(WO.ScrappedQty) AS FLOAT) / SUM(WO.OrderQty) * 100 AS ScrapRate,
	AVG(DATEDIFF(DAY, WO.StartDate, WO.EndDate)) AS AvgProductionDays,
	FORMAT(SUM(WO.OrderQty * P.StandardCost), 'C') AS TotalProductionCost
FROM Production.WorkOrder WO
INNER JOIN Production.Product P
	ON WO.ProductID = P.ProductID
WHERE WO.EndDate IS NOT NULL
GROUP BY P.Name
HAVING SUM(WO.OrderQty) > 100
ORDER BY ScrapRate DESC

-- 6. Rank the sales reason types by total revenue they brought
USE AdventureWorks2019

SELECT 
	RANK() OVER (ORDER BY AVG(SH.TotalDue) DESC) AS RevenueRank,
	SR.ReasonType,
	COUNT(DISTINCT SH.SalesOrderID) AS TotalOrders,
	FORMAT(SUM(SH.TotalDue), 'C') AS TotalRevenue,
	FORMAT(AVG(SH.TotalDue), 'C') AS AvgOrderValue
FROM Sales.SalesOrderHeader AS SH
INNER JOIN Sales.SalesOrderHeaderSalesReason AS SHR
	ON SH.SalesOrderID = SHR.SalesOrderID
INNER JOIN Sales.SalesReason AS SR
	ON SHR.SalesReasonID = SR.SalesReasonID
GROUP BY SR.ReasonType
ORDER BY RevenueRank

-- 7. Query which shipping method handles the most revenue
USE AdventureWorks2019

SELECT SM.Name,
	COUNT(DISTINCT(SH.SalesOrderID)) AS OrderCount,
	COUNT(SD.SalesOrderDetailID) AS LineItemCount,
	FORMAT(SUM(SD.LineTotal), 'C') AS ProductTotal,
	FORMAT(SUM(SD.LineTotal) / COUNT(DISTINCT SH.SalesOrderID), 'C') AS AvgOrderValue,
	FORMAT(SUM(DISTINCT SH.Freight) / COUNT(DISTINCT SH.SalesOrderID), 'C') AS AvgFreight
FROM Sales.SalesOrderHeader AS SH
INNER JOIN Purchasing.ShipMethod AS SM
	ON SH.ShipMethodID = SM.ShipMethodID
INNER JOIN Sales.SalesOrderDetail AS SD
	ON SH.SalesOrderID = SD.SalesOrderID
GROUP BY SM.Name
ORDER BY SUM(SD.LineTotal) DESC

-- 8. Query sales productivity by sales job role
USE AdventureWorks2019

SELECT E.JobTitle,
	AVG(EPH.Rate) AS AvgHourlyRate,
	COUNT(DISTINCT(SP.BusinessEntityID)) AS Employees,
	FORMAT(SUM(SH.TotalDue), 'C') AS TotalRevenue,
	FORMAT(CONVERT(FLOAT, SUM(SH.TotalDue) / COUNT(DISTINCT(SP.BusinessEntityID))), 'C') AS SalesRate
FROM HumanResources.Employee AS E
INNER JOIN HumanResources.EmployeePayHistory AS EPH
	ON E.BusinessEntityID = EPH.BusinessEntityID
INNER JOIN Sales.SalesPerson AS SP
	ON E.BusinessEntityID = SP.BusinessEntityID
INNER JOIN Sales.SalesOrderHeader AS SH
	ON SH.SalesPersonID = SP.BusinessEntityID
GROUP BY E.JobTitle
ORDER BY SUM(SH.TotalDue) / COUNT(DISTINCT(SP.BusinessEntityID)) DESC
