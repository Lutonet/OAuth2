CREATE PROCEDURE [dbo].[spUser_GetPasswordHash]
  @Email VARCHAR(128)
AS
BEGIN
  SELECT PasswordHash FROM Users WHERE Email = @Email
END

