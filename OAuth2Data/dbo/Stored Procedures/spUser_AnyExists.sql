﻿CREATE PROCEDURE [dbo].[spUser_AnyExists]
AS
BEGIN
 SELECT * FROM [dbo].[users]
 IF @@ROWCOUNT = 0
 BEGIN
    SELECT 0   
    RETURN 0
 END
 ELSE
 BEGIN
    SELECT 1
    RETURN 1
 END
 RETURN 0
END;