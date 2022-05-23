CREATE PROCEDURE [dbo].[spUser_GetById]
  @Id NVarchar(128)
AS
BEGIN
  SELECT [Email] 
  FROM [dbo].[Users]
  WHERE Id = @Id;
END
