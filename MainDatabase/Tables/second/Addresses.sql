CREATE TABLE [second].[Addresses]
(
	[AddressID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StreetName] VARCHAR(50) NOT NULL, 
    [StreetNumber] SMALLINT NULL, 
    [PersonID] INT NULL, 
    CONSTRAINT [FK_Addresses_People] FOREIGN KEY ([PersonID]) REFERENCES [second].[People]([PersonID])
)
