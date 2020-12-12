CREATE PROCEDURE [dbo].[spMovies_GetActorsByMovieId]
	@Id INT
AS

BEGIN
	SET NOCOUNT ON;

	SELECT a.[Id], a.[RoleId], a.[Email], a.[Password], a.[Name], a.[Biography], a.[Picture], 
		a.[DateOfBirth], b.[Character]
	FROM dbo.People a JOIN
		dbo.MovieActors b  ON b.PersonId = a.Id	
	WHERE b.MovieId = @Id
END