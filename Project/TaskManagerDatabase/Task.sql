CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Details] NVARCHAR(MAX) NOT NULL, 
    [Status] INT NOT NULL, 
    [Start] DATE NULL, 
    [Stop] DATETIME NULL, 
    [AssignedTo] INT NULL, 
    CONSTRAINT [FK_Task_ToTable] FOREIGN KEY ([AssignedTo]) REFERENCES [TaskUser]([Id])
)
