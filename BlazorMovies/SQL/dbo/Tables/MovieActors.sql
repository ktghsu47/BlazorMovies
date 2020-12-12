CREATE TABLE [dbo].[MovieActors]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PersonId] INT NOT NULL, 
    [MovieId] INT NOT NULL, 
    [Character] NVARCHAR(250) NULL, 
    [Order] INT NULL 
)
