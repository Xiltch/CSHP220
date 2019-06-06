CREATE TABLE [dbo].[TaskComment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TaskId] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Details] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, 
    CONSTRAINT [FK_TaskComment_ToTask] FOREIGN KEY ([TaskId]) REFERENCES [Task]([Id]), 
    CONSTRAINT [FK_TaskComment_ToUser] FOREIGN KEY ([CreatedBy]) REFERENCES [TaskUser]([Id])
)
