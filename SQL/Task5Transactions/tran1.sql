-- 1. Transaction for when inserting an employee
BEGIN TRANSACTION InsertEmployeeTran

DECLARE @PersonID AS INT
SET @PersonID = 369

BEGIN TRY
	
	IF EXISTS (SELECT BusinessEntityID 
		FROM HumanResources.Employee 
		WHERE BusinessEntityID = @PersonID)
	BEGIN
		RAISERROR('This person is already an employee', 16, 1)
	END

	IF NOT EXISTS (SELECT BusinessEntityID
		FROM Person.Person
		WHERE BusinessEntityID = @PersonID)
	BEGIN
		RAISERROR('No person with the set ID exists', 16, 1)
	END

	INSERT INTO HumanResources.Employee 
		(BusinessEntityID, 
		NationalIDNumber, 
		LoginID,
		JobTitle,
		BirthDate,
		MaritalStatus,
		Gender,
		HireDate,
		SalariedFlag,
		VacationHours,
		SickLeaveHours,
		CurrentFlag,
		ModifiedDate)
	SELECT 
		@PersonID, 
		RAND(), 
		CONCAT('adventure-works\', LOWER(FirstName), BusinessEntityID),
		'Sales Representative',
		CONVERT(DATE, DATEADD(year, -18, SYSDATETIME())),
		'S',
		'M',
		CONVERT(DATE, SYSDATETIME()),
		1,
		128,
		72,
		1,
		SYSDATETIME()
	FROM Person.Person
	WHERE BusinessEntityID = @PersonID

	SELECT *
	FROM HumanResources.Employee
	WHERE BusinessEntityID = @PersonID

	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END CATCH
