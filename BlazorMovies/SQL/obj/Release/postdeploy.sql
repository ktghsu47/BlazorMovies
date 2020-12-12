/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT * FROM dbo.Genres) BEGIN
    INSERT INTO dbo.Genres([Name]) VALUES
    ('Action'),
    ('Adventure'),
    ('Comedy')
    INSERT INTO dbo.Roles([Name]) VALUES
    ('Admin'),
    ('User'),
    ('Actor')
    INSERT INTO dbo.People(RoleID, Email, [Password], [Name]) VALUES
    (1, 'ktghsu@hotmail.com', '123', 'Gordon Hsu')
    INSERT INTO dbo.Movies(Title, ReleaseDate, Poster) VALUES
    ('Spider-Man: Far From Home', '12/15/2019', 'https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg'),
    ('Moana', '10/25/2016', 'https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_SY1000_CR0,0,674,1000_AL_.jpg'),
    ('Inception', '11/30/2010', 'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg')
END
GO
