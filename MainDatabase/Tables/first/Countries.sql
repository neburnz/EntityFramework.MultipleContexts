CREATE TABLE [first].[Countries]
(
	[CountryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Code] VARCHAR(4) NULL, 
    [CreationDate] DATETIME2 NULL, 
    [Order] INT NULL
)
