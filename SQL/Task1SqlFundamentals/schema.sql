USE FarmProject;

CREATE TABLE dbo.Rabbits(
	Id INT PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL
		CHECK(LEN(Name) >= 3),
	Gender INT NOT NULL
		CHECK(Gender IN (0, 1)),
	BreedingStatus INT NOT NULL
		CHECK(BreedingStatus BETWEEN 0 AND 5)
)

CREATE TABLE dbo.Pairs(
	Id INT PRIMARY KEY,
	MaleRabbitId INT NOT NULL,
	FemaleRabbitId INT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME,
	PairingStatus INT NOT NULL
		CHECK(PairingStatus BETWEEN 0 AND 2),

	CONSTRAINT FK_Pair_MaleRabbit 
	FOREIGN KEY (MaleRabbitId)
	REFERENCES dbo.Rabbits(Id),

	CONSTRAINT FK_Pair_FemaleRabbit 
	FOREIGN KEY (FemaleRabbitId)
	REFERENCES dbo.Rabbits(Id)
)

CREATE TABLE dbo.Tasks(
	Id INT PRIMARY KEY,
	TaskType INT NOT NULL,
	Message NVARCHAR(MAX) NOT NULL,
	IsCompleted BIT NOT NULL DEFAULT 0,
	CreatedOn DATETIME NOT NULL,
	DueOn DATETIME NOT NULL
);

CREATE TABLE dbo.Cages(
	Id INT PRIMARY KEY,
	CageLabel NVARCHAR(30) NOT NULL,
	Size INT NOT NULL
		CHECK(Size BETWEEN 0 AND 2),
	AnonymousRabbits INT NOT NULL DEFAULT 0,
);

CREATE TABLE dbo.RabbitCageAssignments(
	Id INT PRIMARY KEY,
	RabbitId INT NOT NULL,
	CageId INT NOT NULL,

	CONSTRAINT FK_RabbitCageAssignment_Rabbit
	FOREIGN KEY (RabbitId)
	REFERENCES dbo.Rabbits(Id),

	CONSTRAINT FK_RabbitCageAssignment_Cage
	FOREIGN KEY (CageId)
	REFERENCES dbo.Cages(Id),

	CONSTRAINT UQ_RabbitCageAssignment_Rabbit
	UNIQUE (RabbitId)
);