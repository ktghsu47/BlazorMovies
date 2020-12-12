CREATE PROCEDURE [dbo].[spMovies_Update]
	@Id INT,
	@Title NVARCHAR(50),
	@Summary NVARCHAR(MAX),
	@InTheaters BIT,
	@Trailer NVARCHAR(MAX),
	@ReleaseDate DATETIME2,
	@Poster NVARCHAR(MAX)
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[Movies] SET
		Title = @Title,
		Summary = @Summary,
		InTheaters = @InTheaters,
		Trailer = @Trailer,
		ReleaseDate = @ReleaseDate,
		Poster = @Poster
	WHERE Id = @Id;
END