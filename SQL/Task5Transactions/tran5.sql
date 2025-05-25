-- 5. Transaction for restocking the quantity of products at a given location
GO

BEGIN TRANSACTION ProductRestockTran

DECLARE @ProductID INT = 1
DECLARE @LocationID INT = 6
DECLARE @Quantity INT = 25
DECLARE @TransactionDate DATETIME = GETDATE()

BEGIN TRY

	IF NOT EXISTS (SELECT ProductID
		FROM Production.Product
		WHERE ProductID = @ProductID)
	BEGIN
		RAISERROR('No product with the set ID exists', 16, 1)
	END

	IF NOT EXISTS (SELECT LocationID
		FROM Production.Location
		WHERE LocationID = @LocationID)
	BEGIN
		RAISERROR('No location with the set ID exists', 16, 1)
	END

	IF NOT EXISTS (SELECT 1
	FROM Production.ProductInventory
	WHERE ProductID = @ProductID 
		AND LocationID = @LocationID)
	BEGIN
		RAISERROR('No such product at the set location ID', 16, 1)
	END

	IF @Quantity < 0
	BEGIN
		RAISERROR('Cannot set a negative quantity', 16, 1)
	END

	IF EXISTS (SELECT ProductID
		FROM Production.Product
		WHERE ProductID = @ProductID
			AND DiscontinuedDate IS NOT NULL)
	BEGIN
		RAISERROR('This product is already retired', 16, 1)
	END

	UPDATE Production.ProductInventory
	SET Quantity = Quantity + @Quantity,
		ModifiedDate = @TransactionDate
	WHERE ProductID = @ProductID 
		AND LocationID = @LocationID

	SELECT *
	FROM Production.ProductInventory
	WHERE ProductID = @ProductID 
		AND LocationID = @LocationID

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
