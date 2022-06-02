CREATE PROCEDURE [dbo].[SpUserRolesUserRolesApplication_FirstRun]
  @Email NVARCHAR(128),
  @EmailConfirmed BIT = 1,
  @PasswordHash NVARCHAR(256),
  @LockoutEnabled BIT = 0,
  @FirstName NVARCHAR (128),
  @LastName NVARCHAR (128),
  @PublicName NVARCHAR (256),
  @IsDeveloper BIT = 1,
  -- application Table
  @Name NVARCHAR(128),
  @Description NVARCHAR(MAX),
  @ApplicationKey NVARCHAR(128),
  @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN
        
        BEGIN TRY
            -- Create the user record
            
            INSERT INTO Users (
            Email, 
            EmailConfirmed, 
            PasswordHash,
            LockoutEnabled,
            FirstName,
            LastName,
            PublicName,
            IsDeveloper)
            
            VALUES (
            @Email, 
            @EmailConfirmed, 
            @PasswordHash, 
            @LockoutEnabled,
            @FirstName, 
            @LastName, 
            @PublicName, 
            @IsDeveloper)

            DECLARE @UserId NVARCHAR(128) = SCOPE_IDENTITY();
            
            -- create the application record
            INSERT INTO Applications(UserId, [Name], [Description], IsActive)
            VALUES(@UserId, @Name, @Description, @IsActive)

            DECLARE @ApplicationId NVARCHAR(128) = SCOPE_IDENTITY();

            -- create the roles record 
            DECLARE @role1 NVARCHAR(128) = N'User'
            DECLARE @role2 NVARCHAR(128) = N'Admin'
            DECLARE @role3 NVARCHAR(128) = N'Server Admin'

            -- insert roles to the table 
            INSERT INTO Roles (Name, ApplicationId)
            VALUES (@role1, @ApplicationId);
            DECLARE @role1Id int = SCOPE_IDENTITY();
            -- add new role to the user
            INSERT INTO [dbo].[UsersRoles] (UserId, RoleId) VALUES (@UserId, @role1Id)


            INSERT INTO Roles (Name, ApplicationId)
            VALUES (@role2, @ApplicationId);
            DECLARE @role2Id int = SCOPE_IDENTITY();
            -- add new role to the user
            INSERT INTO UsersRoles (UserId, RoleId) VALUES (@UserId, @role2Id)

            INSERT INTO Roles (Name, ApplicationId)
            VALUES (@role3, @ApplicationId)
            DECLARE @role3Id int = SCOPE_IDENTITY();
            -- add new role to the user
            INSERT INTO UsersRoles (UserId, RoleId) VALUES (@UserId, @role3Id)

            COMMIT TRANSACTION

        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION
        END CATCH

END
