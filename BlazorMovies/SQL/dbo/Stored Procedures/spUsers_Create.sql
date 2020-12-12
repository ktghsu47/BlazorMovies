CREATE PROCEDURE [dbo].[spUsers_Create]
	@RoleId INT,
	@Email NVARCHAR(250),
	@Password NVARCHAR(100),
	@Name NVARCHAR(50),
	@Biography NVARCHAR(MAX),
	@Picture NVARCHAR(250),
	@DateOfBirth DATETIME2,
	@Id INT OUTPUT
AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[People](RoleId, Email, [Password], [Name], Biography, Picture, DateOfBirth)
	VALUES (@RoleId, @Email, @Password, @Name, @Biography, @Picture, @DateOfBirth);

	SET @Id = SCOPE_IDENTITY();
END