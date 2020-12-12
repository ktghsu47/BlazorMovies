CREATE PROCEDURE [dbo].[spMovieRatings_GetAverage]
	@MovieId INT
AS

BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM dbo.MovieRatings WHERE MovieId = @MovieId) BEGIN
		SELECT AVG(Rate) AS AverageRate
		FROM dbo.MovieRatings
		WHERE MovieId = @MovieId
	END ELSE BEGIN
		SELECT 0 AS AverageRate
	END
END