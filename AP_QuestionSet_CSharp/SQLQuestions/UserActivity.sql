CREATE TABLE [dbo].[UserActivity]
(
	[Id] INT NOT NULL , 
    [UserId] INT NOT NULL, 
    [Timestamp] DATETIME NOT NULL, 
    [Action] NCHAR(10) NOT NULL, 
    PRIMARY KEY ([Id])
)
