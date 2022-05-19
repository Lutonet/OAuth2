CREATE TABLE [dbo].[UsersRoles]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [FK_Users_Roles_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Users_Roles_ToRoles] FOREIGN KEY (RoleId) REFERENCES [Roles]([Id])
)

GO
CREATE INDEX [IX_Users_Roles_UserId] ON [dbo].[UsersRoles] (UserId)
GO
CREATE INDEX [IX_Users_Roles_RoleId] ON [dbo].[UsersRoles] (RoleId)
