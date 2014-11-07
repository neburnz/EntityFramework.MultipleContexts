CREATE TABLE [first].[States]
(
	[StateID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [CountryID] INT NOT NULL, 
    [Budget] MONEY NULL, 
    CONSTRAINT [FK_States_Countries] FOREIGN KEY ([CountryID]) REFERENCES [first].[Countries]([CountryID])
)
