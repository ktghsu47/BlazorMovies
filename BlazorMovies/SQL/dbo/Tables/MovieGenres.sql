CREATE TABLE [dbo].[MovieGenres]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MovieId] INT NOT NULL, 
    [GenreId] INT NOT NULL
)
