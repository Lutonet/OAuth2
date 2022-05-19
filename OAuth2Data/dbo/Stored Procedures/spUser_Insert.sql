CREATE PROCEDURE [dbo].[spUser_Insert]
--  SELECT [Email], [EmailConfirmed], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [LockoutEndDateUtd], [AccessFailedCount], [FirstName], [LastName], [PublicName], [DateOfBirth], [IsDeveloper], [Facebook], [Twitter], [Microsoft], [WebPage], [Timestamp], [AccountCreated], [AccountLocked]
@Email NVARCHAR(128),
@PhoneNumber NVARCHAR(24),
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@PublicName NVARCHAR(256),
@DateOfBirth DATETIME2,
@Facebook NVARCHAR(256),
@Twitter NVARCHAR(256),
@Microsoft NVARCHAR(256),
@Google NVARCHAR(256),
@WebPage NVARCHAR(256)
AS
BEGIN
    INSERT INTO dbo.Users (Email, 
                           PhoneNumber, 
                           FirstName, 
                           LastName, 
                           PublicName, 
                           DateOfBirth, 
                           Facebook, 
                           Twitter,
                           Microsoft,
                           Google,
                           WebPage)
    VALUES (@Email, 
            @PhoneNumber, 
            @FirstName, 
            @LastName, 
            @PublicName, 
            @DateOfBirth,
            @Facebook,
            @Twitter,
            @Microsoft,
            @Google,
            @WebPage);
END
