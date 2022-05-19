CREATE PROCEDURE [dbo].[spUser_Update]
  @Id NVARCHAR(128),
  @Email NVARCHAR(128),
  @EmailConfirmed BIT,
  @PasswordHash NVARCHAR(256),
  @PhoneNumber NVARCHAR(24),
  @TwoFactorEnabled BIT,
  @LockoutEnabled BIT,
  @AccessFailedCount INT,
  @FirstName NVARCHAR(50),
  @LastName NVARCHAR(50),
  @PublicName NVARCHAR(64),
  @IsDeveloper BIT,
  @Facebook NVARCHAR(256),
  @Twitter NVARCHAR(256),
  @Microsoft NVARCHAR(256),
  @Google NVARCHAR(256),
  @WebPage NVARCHAR(256),
  @Timestamp Datetime2 = GETUTCDATE,
  @AccountLocked DATETIME2,
  @LockedReason NVARCHAR(MAX),
  @LockedByAdminId NVARCHAR(128)
AS
  SELECT @param1, @param2
RETURN 0
