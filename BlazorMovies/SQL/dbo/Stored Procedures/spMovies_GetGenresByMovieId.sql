CREATE PROCEDURE [dbo].[spMovies_GetGenresByMovieId]
	@Id INT
AS

BEGIN
	SET NOCOUNT ON;

	SELECT b.Id, b.[Name]
	FROM dbo.MovieGenres a JOIN
		dbo.Genres b ON a.GenreId = b.Id
	WHERE a.MovieId = @Id
END