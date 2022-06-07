CREATE PROCEDURE [dbo].[spRoleCreate]
  @Name NVARCHAR(256),
  @ApplicationId NVARCHAR(128)
AS

BEGIN
    INSERT INTO [Roles]
    ([Name], ApplicationId)
    VALUES (@Name, @ApplicationId);
END
 

