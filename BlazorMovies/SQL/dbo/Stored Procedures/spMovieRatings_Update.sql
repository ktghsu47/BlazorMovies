CREATE PROCEDURE [dbo].[spMovieRatings_Update]
	@Id INT,
	@Rate INT
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[MovieRatings] SET
		Rate = @Rate
	WHERE Id = @Id;
END