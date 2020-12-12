CREATE PROCEDURE [dbo].[spRoles_Delete]
	@Id INT,
	@RoleName NVARCHAR(50)
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[People] SET
		RoleId = NULL
	WHERE Id = @Id;
END