CREATE PROCEDURE [dbo].[spUsers_GetById]
	@Id INT
AS

BEGIN	
	SET NOCOUNT ON;

	SELECT p.Id, RoleId, Email, [Password], p.[Name], Biography, Picture, DateOfBirth, r.[Name] AS RoleName
	FROM dbo.People p JOIN
		dbo.Roles r ON p.RoleId = r.Id
	WHERE p.Id = @Id

	SELECT [Id], [PersonId], [MovieId], [Character], [Order]
	FROM dbo.MovieActors
	WHERE PersonId = @Id
END