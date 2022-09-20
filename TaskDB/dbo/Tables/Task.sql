CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Body] CHAR(10) NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [Done] BIT NULL
)
