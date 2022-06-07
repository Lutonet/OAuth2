CREATE PROCEDURE [dbo].[spUserRoles_AddUserToRole]
  @UserId NVARCHAR(128),
  @RoleId INT
AS
BEGIN
    INSERT INTO [dbo].[UsersRoles]
  ([UserId], [RoleId])
  VALUES
  (@UserId, @RoleId)
END
