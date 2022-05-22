CREATE TABLE [dbo].[UserTokens]
(
  [UserId] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [LoginProvider] NVARCHAR(128) NOT NULL, 
    [Name] NVARCHAR(128) NOT NULL, 
    [Value] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_UserTokens_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users]([Id])
)

GO

CREATE INDEX [IX_UserTokens_LoginProvider] ON [dbo].[UserTokens] (LoginProvider)

GO

CREATE INDEX [IX_UserTokens_Name] ON [dbo].[UserTokens] ([Name])
