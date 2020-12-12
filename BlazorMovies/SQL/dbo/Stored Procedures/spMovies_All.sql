CREATE PROCEDURE [dbo].[spMovies_All]
AS

BEGIN
	SET NOCOUNT ON

	SELECT [Id], [Title], [Summary], [InTheaters], [Trailer], [ReleaseDate], [Poster]
	FROM dbo.Movies
END