CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoleId] INT NULL,
    [Email] NVARCHAR(250) NULL, 
    [Password] NVARCHAR(100) NULL,
    [Name] NVARCHAR(50) NULL, 
    [Biography] NVARCHAR(MAX) NULL, 
    [Picture] NVARCHAR(250) NULL, 
    [DateOfBirth] DATETIME2 NULL  
)
