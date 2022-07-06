CREATE PROCEDURE [dbo].[spApplicationBans_CheckIfUserIsBanned]
  @UserId NVARCHAR(128),
  @ApplicationId NVARCHAR(128)
AS
BEGIN
  SELECT COUNT(*) 
  FROM [dbo].[ApplicationBans] 
  WHERE [UserId] = @UserId 
      AND [ApplicationId] = @ApplicationId AND [BannedUntil] > GETUTCDATE()
END