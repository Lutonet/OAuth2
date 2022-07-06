CREATE TABLE [dbo].[ApplicationBans]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [ApplicationId] NVARCHAR(128) NOT NULL, 
    [Reason] NVARCHAR(128) NOT NULL, 
    [BannedUntil] DATETIME2 NOT NULL, 
    [LockedUntil] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_ApplicationBans_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_ApplicationBans_ToApplications] FOREIGN KEY (ApplicationId) REFERENCES [Applications]([Id])
)
