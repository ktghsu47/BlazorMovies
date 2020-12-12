CREATE PROCEDURE [dbo].[spMovieRatings_GetUserRate]
	@UserId INT,
	@MovieId INT
AS

BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [MovieId], [UserId], [Rate], [RatingDate]
	FROM dbo.MovieRatings
	WHERE UserId = @UserId AND MovieId = @MovieId
END