CREATE TABLE [dbo].[InstagramFiles]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
    [Filename] NVARCHAR(150) NULL, 
    [Created] DATETIME NULL, 
    [CreatedBy] NVARCHAR(100) NULL, 
    [Content] IMAGE NULL
)

