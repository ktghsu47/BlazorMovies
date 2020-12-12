CREATE PROCEDURE [dbo].[spUsers_Search]
	@Limit INT,
	@SearchText NVARCHAR(50)
AS

BEGIN
	SET NOCOUNT ON;

	SELECT TOP (@Limit) [Id], [RoleId], [Email], [Password], [Name], [Biography], [Picture], [DateOfBirth]
	FROM dbo.People
	WHERE [Name] LIKE '%'+@SearchText+'%'
	ORDER BY [Name]
END