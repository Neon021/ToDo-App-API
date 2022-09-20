CREATE PROCEDURE [dbo].[spTask_Update]
	@Id INT,
	@Body CHAR(10),
	@Done BIT
AS
BEGIN
	 UPDATE dbo.Task
		SET Body = @Body, Done = @Done
			WHERE Id = @Id
END