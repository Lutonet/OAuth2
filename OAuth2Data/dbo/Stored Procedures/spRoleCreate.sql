CREATE PROCEDURE [dbo].[spRoleCreate]
  @Id Int,
  @Name NVARCHAR(256),
  @ApplicationId NVARCHAR(128)

AS

BEGIN
    INSERT INTO [Roles]
    ([Name], ApplicationId)
    VALUES (@Name, @ApplicationId);
    SELECT SCOPE_IDENTITY();
END
 

