CREATE TABLE [dbo].[Applications]
(
  [Id] NVARCHAR(128) NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Name] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
    [ApplicationKey] NVARCHAR(128) NOT NULL,
    [DateCreated] DATETIME2 NULL DEFAULT GETUTCDATE(), 
    [LockedUntil] DATETIME2 NULL DEFAULT GETUTCDATE(), 
    [HomeUrl] NVARCHAR(256) NULL, 
    [LogoUrl] NVARCHAR(256) NULL, 
    [PrivacyUrl] NVARCHAR(256) NULL, 
    [ReturnUrl] NVARCHAR(256) NULL, 
    [TermsUrl] NVARCHAR(256) NULL, 
    [IsActive] BIT NULL DEFAULT 1, 
    [IsLocked] BIT NULL DEFAULT 0, 
    [AgeFrom] INT NULL DEFAULT 0, 
    [UserHasAgeLimit] BIT NULL DEFAULT 0, 
    CONSTRAINT [FK_Applications_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 

)

GO

CREATE INDEX [IX_Applications_Name] ON [dbo].[Applications] ([Name])

GO

CREATE INDEX [IX_Applications_UserId] ON [dbo].[Applications] (UserId)
