-- 3. Transaction for updating the product to retired
GO

BEGIN TRANSACTION RetireProductTran

DECLARE @RetireProductID AS INT
SET @RetireProductID = 34434343

BEGIN TRY
	IF EXISTS (SELECT ProductID
		FROM Production.Product
		WHERE ProductID = @RetireProductID
			AND DiscontinuedDate IS NOT NULL)
	BEGIN
		RAISERROR('This product is already retired', 16, 1)
	END

	IF NOT EXISTS (SELECT ProductID
		FROM Production.Product
		WHERE ProductID = @RetireProductID)
	BEGIN
		RAISERROR('No product with the set ID exists', 16, 1)
	END

	UPDATE Production.Product
	SET SellEndDate = SYSDATETIME(),
		DiscontinuedDate = SYSDATETIME()
	WHERE ProductID = @RetireProductID

	SELECT * 
	FROM Production.Product
	WHERE ProductID = @RetireProductID

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
