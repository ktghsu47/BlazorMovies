CREATE PROCEDURE [dbo].[spGenres_GetById]
	@Id INT
AS

BEGIN	
	SET NOCOUNT ON;

	SELECT [Id], [Name]
	FROM dbo.[Genres]
	WHERE Id = @Id;
END