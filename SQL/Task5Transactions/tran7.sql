-- 7. Transaction for inserting a new special offer

SELECT * FROM  Sales.SpecialOffer

GO

BEGIN TRANSACTION InsertNewOfferTran

DECLARE @OfferStartDate AS DATE = GETDATE()
DECLARE @OfferEndDate AS DATE = DATEADD(MONTH, 3, GETDATE())
DECLARE @Description AS NVARCHAR(32) = 'Summer Sale 2025'
DECLARE @DiscountPct AS SMALLMONEY = 0.45
DECLARE @Type AS NVARCHAR(32) = 'Seasonal Discount'
DECLARE @Category AS NVARCHAR(32) = 'Promotion'
DECLARE @NewSpecialOfferID AS INT

BEGIN TRY

	INSERT INTO Sales.SpecialOffer (
		Description, DiscountPct, Type, Category,
		StartDate, EndDate, MinQty, MaxQty)
	VALUES (
		@Description, @DiscountPct, @Type, @Category,
		@OfferStartDate, @OfferEndDate, 1, 5);

	SET @NewSpecialOfferID = SCOPE_IDENTITY()

	SELECT * 
	FROM Sales.SpecialOffer
	WHERE SpecialOfferID = @NewSpecialOfferID

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
