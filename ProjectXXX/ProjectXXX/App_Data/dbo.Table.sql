CREATE TABLE [dbo].[Event]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [FromDate] DATETIME NULL, 
    [ToDate] DATETIME NULL, 
    [Location] NVARCHAR(50) NULL
)
