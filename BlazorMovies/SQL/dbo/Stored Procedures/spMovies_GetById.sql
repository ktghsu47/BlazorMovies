CREATE PROCEDURE [dbo].[spMovies_GetById]
	@Id INT
AS

BEGIN	
	SET NOCOUNT ON;

	SELECT [Id], [Title], [Summary], [InTheaters], [Trailer], [ReleaseDate], [Poster]
	FROM dbo.Movies
	WHERE Id = @Id

	SELECT [Id], [MovieId], [GenreId] 
	FROM dbo.MovieGenres
	WHERE MovieId = @Id

	SELECT [Id], [PersonId], [MovieId], [Character], [Order] 
	FROM dbo.MovieActors
	WHERE MovieId = @Id
END