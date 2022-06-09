CREATE PROCEDURE [dbo].[spApplication_CreateApplication]
  @Id NVARCHAR(128),
  @UserId NVARCHAR(128),
  @Name NVARCHAR(128),
  @Description NVARCHAR(MAX),
  @DateCreated DATETIME2,
  @LockedUntil DATETIME2,
  @ApplicationKey NVARCHAR(128),
  @HomeUrl NVARCHAR(256),
  @LogoUrl NVARCHAR(256),
  @PrivacyUrl NVARCHAR(256),
  @ReturnUrl NVARCHAR(256),
  @TermsUrl NVARCHAR(256),
  @IsActive BIT = 1,
  @IsLocked BIT = 0,
  @AgeFrom INT = 0,
  @UserHasAgeLimit BIT = 0
AS
BEGIN
 INSERT INTO Applications
           ([Id]
           ,[UserId]
           ,[Name]
           ,[Description]
           ,[DateCreated]
           ,[LockedUntil]
           ,[ApplicationKey]
           ,[HomeUrl]
           ,[LogoUrl]
           ,[PrivacyUrl]
           ,[ReturnUrl]
           ,[TermsUrl]
           ,[IsActive]
           ,[IsLocked]
           ,[AgeFrom]
           ,[UserHasAgeLimit])
     VALUES
           (@Id
           ,@UserId
           ,@Name
           ,@Description
           ,@DateCreated
           ,@LockedUntil
           ,@ApplicationKey
           ,@HomeUrl
           ,@LogoUrl
           ,@PrivacyUrl
           ,@ReturnUrl
           ,@TermsUrl
           ,@IsActive
           ,@IsLocked
           ,@AgeFrom
           ,@UserHasAgeLimit)
END