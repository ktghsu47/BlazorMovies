CREATE PROCEDURE [dbo].[spRoles_Create]
	@Id INT,
	@RoleName NVARCHAR(50)
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[People] SET
		RoleId = (SELECT Id FROM Roles WHERE Name = @RoleName)
	WHERE Id = @Id;
END
