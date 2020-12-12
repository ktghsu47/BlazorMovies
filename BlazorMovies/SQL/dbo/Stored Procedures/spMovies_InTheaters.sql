CREATE PROCEDURE [dbo].[spMovies_InTheaters]
	@Limit INT
AS

BEGIN
	SET NOCOUNT ON;

	SELECT TOP (@Limit) [Id], [Title], [Summary], [InTheaters], [Trailer], [ReleaseDate], [Poster]
	FROM dbo.Movies
	WHERE InTheaters > 0
	ORDER BY ReleaseDate DESC
END