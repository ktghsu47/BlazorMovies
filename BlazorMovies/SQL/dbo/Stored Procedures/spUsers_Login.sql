CREATE PROCEDURE [dbo].[spUsers_Login]
	@Email NVARCHAR(250),
	@Password NVARCHAR(100)
AS

BEGIN
	SET NOCOUNT ON;

	SELECT p.[Id], p.[RoleId], p.[Email], p.[Password], p.[Name], p.[Biography], p.[Picture],
		p.[DateOfBirth], r.[Name] AS RoleName
	FROM dbo.[People] p JOIN
		dbo.[Roles] r ON p.RoleId = r.Id
	WHERE p.Email = @Email
		AND p.[Password] = @Password
END