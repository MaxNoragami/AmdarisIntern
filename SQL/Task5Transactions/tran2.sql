-- 2. Transaction for inserting a new location
GO

BEGIN TRANSACTION AddLocationTran

DECLARE @NewLocationName AS NVARCHAR(30)
SET @NewLocationName = 'NewLocation'

BEGIN TRY
	INSERT INTO Production.Location (Name, CostRate, Availability, ModifiedDate)
	VALUES (@NewLocationName, 96, 100, SYSDATETIME())
	
	SELECT * 
	FROM Production.Location
	WHERE Name = @NewLocationName

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
