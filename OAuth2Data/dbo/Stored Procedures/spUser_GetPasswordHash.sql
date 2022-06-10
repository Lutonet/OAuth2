CREATE PROCEDURE [dbo].[spUser_GetPasswordHash]
  @Email VARCHAR(128)
AS
BEGIN
  SELECT PasswordHash, PasswordSalt 
  FROM Users 
  WHERE Email = @Email
END

