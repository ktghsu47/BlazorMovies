CREATE PROCEDURE [dbo].[spMovies_Create]
	@Title NVARCHAR(50),
	@Summary NVARCHAR(MAX),
	@InTheaters BIT,
	@Trailer NVARCHAR(MAX),
	@Poster NVARCHAR(MAX),
	@Id INT OUTPUT
AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[Movies](Title, Summary, InTheaters, Trailer, Poster)
	VALUES (@Title, @Summary, @InTheaters, @Trailer, @Poster);

	SET @Id = SCOPE_IDENTITY();
END