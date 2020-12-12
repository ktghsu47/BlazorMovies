CREATE PROCEDURE [dbo].[spGenres_Update]
	@Id INT,
	@Name NVARCHAR(50)
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[Genres] SET
		Name = @Name
	WHERE Id = @Id;
END