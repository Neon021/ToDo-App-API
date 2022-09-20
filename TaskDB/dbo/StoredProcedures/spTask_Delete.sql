CREATE PROCEDURE [dbo].[spTask_Delete]
	@Id INT
AS
BEGIN
	DELETE FROM dbo.Task
	WHERE Id = @Id
END