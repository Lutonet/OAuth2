CREATE PROCEDURE [dbo].[spUser_Insert]

@Id NVARCHAR(128),
@Email NVARCHAR(128),
@PasswordHash VARCHAR(256),
@PasswordSalt VARCHAR(128),
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@PublicName NVARCHAR(256),
@DateOfBirth DATETIME2
AS
BEGIN
    INSERT INTO dbo.Users (Id,
                           Email,
                           PasswordHash,
                           PasswordSalt,
                           FirstName, 
                           LastName, 
                           PublicName, 
                           DateOfBirth)
    VALUES (@Id,
            @Email,
            @PasswordHash,
            @PasswordSalt,
            @FirstName, 
            @LastName, 
            @PublicName, 
            @DateOfBirth);
END
