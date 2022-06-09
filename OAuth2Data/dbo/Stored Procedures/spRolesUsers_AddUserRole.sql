CREATE PROCEDURE [dbo].[spRolesUsers_AddUserRole]
  @Id int,
  @userId nvarchar(256),
  @roleId int
AS
BEGIN
  INSERT INTO [dbo].[UsersRoles]
  ([UserId], [RoleId])
  VALUES
  (@userId, @roleId) 
END

