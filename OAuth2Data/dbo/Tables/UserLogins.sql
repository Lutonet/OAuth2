CREATE TABLE [dbo].[UserLogins]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LoginProvider] NVARCHAR(128) NOT NULL, 
    [ProviderKey] NVARCHAR(128) NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    CONSTRAINT [FK_UserLogins_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users]([Id])
)

GO

CREATE INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins] (UserId)
