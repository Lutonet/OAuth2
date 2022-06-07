CREATE PROCEDURE [dbo].[spApplication_CreateApplication]
  @Id NVARCHAR(128),
  @UserId NVARCHAR(128),
  @Name NVARCHAR(128),
  @Description NVARCHAR(MAX),
  @ApplicationKey NVARCHAR(128),
  @HomeUrl NVARCHAR(256),
  @LogoUrl NVARCHAR(256),
  @PrivacyUrl NVARCHAR(256),
  @AgeFrom INT,
  @UserHasAgeLimit BIT
AS

BEGIN
 INSERT INTO Applications
           ([Id]
           ,[UserId]
           ,[Name]
           ,[Description]
           ,[ApplicationKey]
           ,[HomeUrl]
           ,[LogoUrl]
           ,[PrivacyUrl]
           ,[AgeFrom]
           ,[UserHasAgeLimit])
     VALUES
           (@Id
           ,@UserId
           ,@Name
           ,@Description
           ,@ApplicationKey
           ,@HomeUrl
           ,@LogoUrl
           ,@PrivacyUrl
           ,@AgeFrom
           ,@UserHasAgeLimit)
END