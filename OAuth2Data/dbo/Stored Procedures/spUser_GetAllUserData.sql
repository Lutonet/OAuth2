CREATE PROCEDURE [dbo].[spUser_GetAllUserData]
  @Email NVARCHAR(256)
  AS
  BEGIN
  SELECT * FROM Users WHERE Email = @Email
  END
