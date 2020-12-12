CREATE PROCEDURE [dbo].[spRoles_GetRoleByUserId]
	@Id INT
AS

BEGIN
	SET NOCOUNT ON

	SELECT a.[Id], a.[Name]
	FROM dbo.Roles a JOIN
		dbo.People b on a.Id = b.RoleId
	WHERE b.id = @Id
END