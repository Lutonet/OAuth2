CREATE TABLE [dbo].[Users]
(
    [Id] NVARCHAR(128) NOT NULL DEFAULT NEWID(),
    [Email] NVARCHAR(128) NOT NULL, 
    [EmailConfirmed] BIT NOT NULL DEFAULT 0, 
    [PasswordHash] NVARCHAR(256) NOT NULL, 
    [PasswordSalt] NVARCHAR(256) NOT NULL,
    [PhoneNumber] NVARCHAR(24) NULL, 
    [PhoneNumberConfirmed] BIT NULL DEFAULT 0, 
    [TwoFactorEnabled] BIT NULL DEFAULT 0, 
    [LockoutEnabled] BIT NULL DEFAULT 1, 
    [LockoutEndDateUtc] DATETIME2 NULL, 
    [AccessFailedCount] INT NULL DEFAULT 0, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [PublicName] NVARCHAR(64) NOT NULL, 
    [DateOfBirth] DATETIME2 NULL, 
    [IsDeveloper] BIT NULL DEFAULT 0, 
    [Facebook] NVARCHAR(256) NULL, 
    [Twitter] NVARCHAR(256) NULL, 
    [Microsoft] NVARCHAR(256) NULL, 
    [Google] NVARCHAR(256) NULL,
    [WebPage] NVARCHAR(256) NULL, 
    [Timestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [AccountCreated] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [AccountLocked] DATETIME2 NULL, 
    [LockedReason] NVARCHAR(MAX) NULL, 
    [LockedByAdminId] NVARCHAR(128) NULL, 
    
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Users_ToUsers] FOREIGN KEY (LockedByAdminId) REFERENCES [Users]([Id])
)

GO

CREATE INDEX [IX_Users_Email] ON [dbo].[Users] (Email)
