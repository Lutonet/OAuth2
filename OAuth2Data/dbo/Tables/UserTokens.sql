CREATE TABLE [dbo].[UserTokens]
(
  [UserId] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [ApplicationId] NVARCHAR(128) NOT NULL, 
    [Token] NVARCHAR(128) NOT NULL, 
    [Issued] DATETIME2 NOT NULL, 
    [Expiration] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_UserTokens_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_UserTokens_ToApplications] FOREIGN KEY (ApplicationId) REFERENCES Applications(Id)
)

GO

CREATE INDEX [IX_UserTokens_LoginProvider] ON [dbo].[UserTokens] ([ApplicationId])

GO

CREATE INDEX [IX_UserTokens_Name] ON [dbo].[UserTokens] ([Token])
