CREATE PROCEDURE [dbo].[spUser_EmailIsUnique]
  @email nvarchar(128)
AS
BEGIN
  SELECT COUNT (*) FROM [Users] WHERE email = @email;
END