CREATE PROCEDURE [dbo].[spApplicationBan-CheckIfUserIsLocked]
  @UserId NVARCHAR(128),
  @ApplicationId NVARCHAR(128)
BEGIN
  SELECT COUNT (*) 
  FROM [dbo].[ApplicationBan] 
  WHERE [UserId] = @UserId 
    AND [ApplicationId] = @ApplicationId 
    AND [LockedUntil] > GETUTCDATE()
END
