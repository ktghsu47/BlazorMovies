﻿CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Summary] NVARCHAR(MAX) NULL, 
    [InTheaters] BIT NOT NULL DEFAULT 0, 
    [Trailer] NVARCHAR(MAX) NULL, 
    [ReleaseDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [Poster] NVARCHAR(MAX) NULL
)