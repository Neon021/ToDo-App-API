CREATE PROCEDURE [dbo].[spTask_Create]
	@Body CHAR(10),
	@Created DATETIME,
	@Done BIT
AS
BEGIN
	INSERT INTO dbo.Task(Body, Created, Done)
		VALUES(@Body, NOW() , @Done);
END