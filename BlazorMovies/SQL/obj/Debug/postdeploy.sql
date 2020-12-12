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
    TRUNCATE TABLE dbo.Genres
    INSERT INTO dbo.Genres([Name]) VALUES
    ('Action'),
    ('Adventure'),
    ('Comedy')

    TRUNCATE TABLE dbo.Roles
    INSERT INTO dbo.Roles([Name]) VALUES
    ('Admin'),
    ('User'),
    ('Actor')

    TRUNCATE TABLE dbo.People
    INSERT INTO dbo.People(RoleID, Email, [Password], [Name]) VALUES
    (1, 'ktghsu@hotmail.com', '123', 'Gordon Hsu'),
    (2, 'TestUser@yahoo.com', '123', 'User Hsu'),
    (3, 'TestActor1@yahoo.com', '123', 'Actor1 Hsu'),
    (3, 'TestActor2@yahoo.com', '123', 'Actor2 Hsu'),
    (3, 'TestActor3@yahoo.com', '123', 'Actor3 Hsu'),
    (3, 'TestActor4@yahoo.com', '123', 'Actor4 Hsu'),
    (3, 'TestActor5@yahoo.com', '123', 'Actor5 Hsu')

    TRUNCATE TABLE dbo.Movies
    INSERT INTO dbo.Movies(Title, Summary, ReleaseDate, InTheaters, Poster) VALUES
    ('Spider-Man: Far From Home', 'Summary for Spider-Man: Far From Home', '12/15/2019', 1, 'https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg'),
    ('Moana', 'Summary for Moana', '10/25/2030', 0, 'https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_SY1000_CR0,0,674,1000_AL_.jpg'),
    ('Inception', 'Summary for Inception', '11/30/2010', 1, 'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg')

    TRUNCATE TABLE dbo.MovieActors
    INSERT INTO dbo.MovieActors(PersonId, MovieId, [Character], [Order]) VALUES
    (3, 1, 'Character 1', 1),
    (4, 1, 'Character 2', 2),
    (5, 1, 'Character 3', 3),
    (3, 2, 'Character 4', 3),
    (6, 2, 'Character 5', 1),
    (7, 3, 'Character 6', 1)

    TRUNCATE TABLE dbo.MovieGenres
    INSERT INTO dbo.MovieGenres(MovieId, GenreId) VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (2, 1),
    (2, 2),
    (3, 1)

    TRUNCATE TABLE dbo.MovieRatings
    INSERT INTO dbo.MovieRatings(MovieId, UserId, Rate, RatingDate) VALUES
    (1, 1, 5, '12/31/2020'),
    (1, 2, 4, '12/31/2020'),
    (1, 3, 4, '12/31/2020'),
    (2, 1, 5, '12/31/2020'),
    (3, 1, 5, '12/31/2020')
END
GO
