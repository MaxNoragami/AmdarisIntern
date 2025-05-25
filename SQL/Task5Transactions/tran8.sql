-- 8. Transaction to update a phone num of a person

-- Look for ppl without a phone num
SELECT P.BusinessEntityID, PP.PhoneNumber
FROM Person.PersonPhone AS PP
RIGHT JOIN Person.Person AS P
	ON PP.BusinessEntityID = P.BusinessEntityID
WHERE PP.PhoneNumber IS NULL

BEGIN TRANSACTION UpdatePhoneNumTran

DECLARE @PersonID AS INT = 2553
DECLARE @NewPhoneNum AS NVARCHAR(25) = '111-222-1234'
DECLARE @NewPgoneNumTypeID AS INT = 2

BEGIN TRY
	IF NOT EXISTS (SELECT BusinessEntityID 
		FROM Person.Person
		WHERE BusinessEntityID = @PersonID)
	BEGIN
		RAISERROR('No person with the set ID exists', 16, 1)
	END

	IF NOT EXISTS (SELECT PhoneNumberTypeID
		FROM Person.PhoneNumberType
		WHERE PhoneNumberTypeID = @NewPgoneNumTypeID)
	BEGIN
		RAISERROR('No phone num type with the set ID exists', 16, 1)
	END

	IF NOT EXISTS (SELECT BusinessEntityID 
		FROM Person.PersonPhone
		WHERE BusinessEntityID = @PersonID)
	BEGIN
		INSERT INTO Person.PersonPhone
			VALUES (@PersonID, 
				@NewPhoneNum, 
				@NewPgoneNumTypeID,
				GETDATE())
		PRINT 'inserted'
	END

	ELSE
	BEGIN
		UPDATE Person.PersonPhone
		SET PhoneNumber = @NewPhoneNum
		WHERE BusinessEntityID = @PersonID

		PRINT 'updated'
	END

	SELECT * 
	FROM Person.PersonPhone
	WHERE BusinessEntityID = @PersonID

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
