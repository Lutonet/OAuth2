CREATE TABLE [dbo].[Roles]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Name] NVARCHAR (256) NOT NULL, 
    [ApplicationId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_Roles_ToApplications] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications]([Id]),
)
