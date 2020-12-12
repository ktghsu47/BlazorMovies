CREATE PROCEDURE [dbo].[spMovieRatings_Create]
	@MovieId INT,
	@UserId INT,
	@Rate INT,
	@Id INT OUTPUT
AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[MovieRatings](MovieId, UserId, Rate)
	VALUES (@MovieId, @UserId, @Rate);

	SET @Id = SCOPE_IDENTITY();
END