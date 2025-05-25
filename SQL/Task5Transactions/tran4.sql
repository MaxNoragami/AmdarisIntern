-- 4. Transaction for deleting an item from shopping cart
GO
ALTER TRIGGER Sales.DeleteShopCartItemTrigger
ON Sales.ShoppingCartItemCopy
AFTER DELETE
AS
BEGIN
	INSERT INTO Sales.ShoppingCartItemHistory
		(ShoppingCartItemID, 
		ShoppingCartID,
		Quantity,
		ProductID,
		DateCreated,
		ModifiedDate)
	SELECT d.ShoppingCartItemID, 
		d.ShoppingCartID,
		d.Quantity,
		d.ProductID,
		d.DateCreated,
		d.ModifiedDate
	FROM deleted d;
END

GO

SELECT *
FROM Sales.ShoppingCartItemCopy

BEGIN TRANSACTION RmvShoppingCartItemTran

DECLARE @ProductID AS INT
SET @ProductID = 874

BEGIN TRY

	IF NOT EXISTS (SELECT ProductID
		FROM Production.Product
		WHERE ProductID = @ProductID)
	BEGIN
		RAISERROR('No product with the set ID exists', 16, 1)
	END

	IF NOT EXISTS (SELECT ProductID
		FROM Sales.ShoppingCartItemCopy
		WHERE ProductID = @ProductID)
	BEGIN
		RAISERROR('No product with the set ID in the shopping cart', 16, 1)
	END

	DELETE FROM Sales.ShoppingCartItemCopy
	WHERE ProductID = @ProductID

	SELECT * 
	FROM Sales.ShoppingCartItemHistory
	WHERE ProductID = @ProductID

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
