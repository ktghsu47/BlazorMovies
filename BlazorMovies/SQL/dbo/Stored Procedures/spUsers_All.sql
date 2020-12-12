CREATE PROCEDURE [dbo].[spUsers_All]
AS
BEGIN
	SET NOCOUNT ON

	SELECT [Id], [RoleId], [Email], [Password], [Name], [Biography], [Picture], [DateOfBirth]
	FROM dbo.People
END