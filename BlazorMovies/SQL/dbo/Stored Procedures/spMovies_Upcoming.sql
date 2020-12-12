CREATE PROCEDURE [dbo].[spMovies_Upcoming]
	@Limit INT
AS

BEGIN
	SET NOCOUNT ON;

	SELECT TOP (@Limit) [Id], [Title], [Summary], [InTheaters], [Trailer], [ReleaseDate], [Poster]
	FROM dbo.Movies
	WHERE ReleaseDate > GETDATE()
	ORDER BY ReleaseDate
END