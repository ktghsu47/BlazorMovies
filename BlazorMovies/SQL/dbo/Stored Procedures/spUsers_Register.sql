CREATE PROCEDURE [dbo].[spUsers_Register]
	@Email NVARCHAR(250),
	@Password NVARCHAR(100),
	@Id INT OUTPUT
AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[People](RoleId, Email, [Password])
	VALUES (2, @Email, @Password);

	SET @Id = SCOPE_IDENTITY();
END