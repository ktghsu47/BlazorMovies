CREATE PROCEDURE [dbo].[spRoles_All]
AS

BEGIN
	SET NOCOUNT ON

	SELECT [Id], [Name]
	FROM dbo.Roles
END
