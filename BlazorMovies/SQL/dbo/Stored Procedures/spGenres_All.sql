CREATE PROCEDURE [dbo].[spGenres_All]
AS

BEGIN
	SET NOCOUNT ON

	SELECT [Id], [Name]
	FROM dbo.Genres
END