CREATE PROCEDURE [dbo].[spUser_GetById]
  @Id NVarchar(128)
AS
BEGIN
  SELECT [Id], 
         [Email], 
         [EmailConfirmed], 
         [PhoneNumber], 
         [PhoneNumberConfirmed], 
         [TwoFactorEnabled], 
         [LockoutEnabled], 
         [LockoutEndDateUtc], 
         [FirstName], 
         [LastName], 
         [PublicName], 
         [DateOfBirth], 
         [IsDeveloper], 
         [Facebook], 
         [Twitter], 
         [Microsoft], 
         [WebPage], 
         [AccountCreated], 
         [AccountLocked]
  FROM [dbo].[Users]
  WHERE Id = @Id;
END
