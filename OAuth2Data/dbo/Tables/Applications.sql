﻿CREATE TABLE [dbo].[Applications]
(
  [Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Name] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [DateCreated] DATETIME2 NOT NULL, 
    [HomeUrl] NVARCHAR(256) NULL, 
    [LockedUntil] DATETIME2 NULL, 
    [LogoUrl] NVARCHAR(256) NULL, 
    [PrivacyURL] NVARCHAR(256) NULL, 
    [ReturnUrl] NVARCHAR(256) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 0, 
    [IsLocked] BIT NOT NULL DEFAULT 0, 
    [TermsURL] NVARCHAR(256) NULL, 
    CONSTRAINT [FK_Applications_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 

)

GO

CREATE INDEX [IX_Applications_Name] ON [dbo].[Applications] ([Name])

GO

CREATE INDEX [IX_Applications_UserId] ON [dbo].[Applications] (UserId)
