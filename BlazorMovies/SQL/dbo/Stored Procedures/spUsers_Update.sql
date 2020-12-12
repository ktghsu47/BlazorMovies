CREATE PROCEDURE [dbo].[spUsers_Update]
	@Id INT,
	@RoleId INT,
	@Email NVARCHAR(250),
	@Password NVARCHAR(100),
	@Name NVARCHAR(50),
	@Biography NVARCHAR(MAX),
	@Picture NVARCHAR(MAX),
	@DateOfBirth DATETIME2
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[People] SET
		RoleId = @RoleId,
		Email = @Email,
		[Password] = @Password,
		[Name] = @Name,
		Biography = @Biography,
		Picture = @Picture,
		DateOfBirth = @DateOfBirth
	WHERE Id = @Id;
END