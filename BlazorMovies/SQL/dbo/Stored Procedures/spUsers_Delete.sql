CREATE PROCEDURE [dbo].[spUsers_Delete]
	@Id INT
AS

BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.[People]
	WHERE Id = @Id;
END
