CREATE PROCEDURE [dbo].[spTask_Get]
	@Id int
AS
BEGIN
	  SELECT *FROM dbo.Task
	  WHERE Id = @Id
END