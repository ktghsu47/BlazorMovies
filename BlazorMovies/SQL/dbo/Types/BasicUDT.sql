CREATE TYPE [dbo].[BasicUDT] AS TABLE (
	[Name] NVARCHAR(50)
)

--CREATE PROCEDURE [dbo].[spGenres_InsertSet]
--	@Genres BasicUDT READONLY
--AS

--BEGIN
--	INSERT INTO dbo.Genres([Name])
--	SELECT [Name] FROM @Genres
--END