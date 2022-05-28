CREATE PROCEDURE [dbo].[spUser_Exists]
@Email NVARCHAR(128)
AS

BEGIN
 SELECT COUNT(*) FROM [dbo].[users]
 WHERE Email = @Email;
   
 
END;
RETURN 0
