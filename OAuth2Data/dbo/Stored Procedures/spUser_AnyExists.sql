CREATE PROCEDURE [dbo].[spUser_AnyExists]

AS
BEGIN
 SELECT COUNT(*) FROM [dbo].[users]
   
 
END;