CREATE TABLE [dbo].[Applications]
(
  [Id] NVARCHAR(128) NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Name] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [DateCreated] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [HomeUrl] NVARCHAR(256) NULL, 
    [LockedUntil] DATETIME2 NULL, 
    [LogoUrl] NVARCHAR(256) NULL, 
    [PrivacyUrl] NVARCHAR(256) NULL, 
    [ReturnUrl] NVARCHAR(256) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 0, 
    [IsLocked] BIT NOT NULL DEFAULT 0, 
    [TermsUrl] NVARCHAR(256) NULL, 
    [AgeFrom] INT NOT NULL DEFAULT 0, 
    [UserHasAgeLimit] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Applications_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 

)

GO

CREATE INDEX [IX_Applications_Name] ON [dbo].[Applications] ([Name])

GO

CREATE INDEX [IX_Applications_UserId] ON [dbo].[Applications] (UserId)
