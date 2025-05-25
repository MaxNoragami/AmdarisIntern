-- 6. Transaction for updating TerritoryID of a customer

SELECT  *
FROM Sales.Customer
WHERE PersonID IS NOT NULL

GO

BEGIN TRANSACTION UpdateCustomerTerritoryTran

DECLARE @CustomerID AS INT = 12232
DECLARE @NewTerritoryID AS INT = 3

BEGIN TRY
	IF NOT EXISTS (SELECT TerritoryID
		FROM Sales.SalesTerritory
		WHERE TerritoryID = @NewTerritoryID)
	BEGIN
		RAISERROR('No territory with the set ID exists', 16, 1)
	END

	IF NOT EXISTS (SELECT CustomerID
		FROM Sales.Customer
		WHERE CustomerID = @CustomerID)
	BEGIN
		RAISERROR('No customer with the set ID exists', 16, 1)
	END

	UPDATE Sales.Customer
	SET TerritoryID = @NewTerritoryID
	WHERE CustomerID = @CustomerID

	SELECT * 
	FROM Sales.Customer
	WHERE CustomerID = @CustomerID

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
