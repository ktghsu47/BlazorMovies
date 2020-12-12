CREATE PROCEDURE [dbo].[spMovieActors_Create]
	@PersonId INT,
	@MovieId INT,
	@Character NVARCHAR(250),
	@Order INT,
	@Id INT OUTPUT
AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[MovieActors](PersonId, MovieId, [Character], [Order])
	VALUES (@PersonId, @MovieId, @Character, @Order)

	SET @Id = SCOPE_IDENTITY();
END
