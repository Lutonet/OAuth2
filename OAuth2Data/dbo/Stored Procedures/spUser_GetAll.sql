CREATE PROCEDURE [dbo].[spUser_GetAll]

AS
BEGIN
  SELECT [Id], [Email], [EmailConfirmed], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [LockoutEndDateUtc], [AccessFailedCount], [FirstName], [LastName], [PublicName], [DateOfBirth], [IsDeveloper], [Facebook], [Twitter], [Microsoft], [WebPage], [Timestamp], [AccountCreated], [AccountLocked]
  FROM [dbo].[Users];
END

