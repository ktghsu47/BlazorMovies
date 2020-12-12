CREATE PROCEDURE [dbo].[spMovieGenres_Create]
	@GenreId INT,
	@MovieId INT,
	@Id INT OUTPUT
AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[MovieGenres](GenreId, MovieId)
	VALUES (@GenreId, @MovieId)

	SET @Id = SCOPE_IDENTITY();
END