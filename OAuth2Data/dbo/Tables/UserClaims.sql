CREATE TABLE [dbo].[UserClaims]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [ApplicationId] NVARCHAR(128) NOT NULL,
    [ClaimType] NVARCHAR(MAX) NULL, 
    [ClaimValue] NVARCHAR(MAX) NULL, 
    [Timestamp] DATETIME2 NULL DEFAULT GETUTCDATE(), 
    CONSTRAINT [FK_UserClaims_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_UserClaims_ToApplications] FOREIGN KEY (ApplicationId) REFERENCES [Applications]([Id]))

GO

CREATE INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims] (UserId)
