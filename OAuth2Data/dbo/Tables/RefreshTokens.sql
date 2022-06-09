CREATE TABLE [dbo].[RefreshTokens]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [UserId] NVARCHAR(128) NOT NULL,
  [Token] NVARCHAR(256) NOT NULL, 
    [JwtId] NVARCHAR(128) NOT NULL, 
    [IsUsed] BIT NOT NULL, 
    [IsRevoked] BIT NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL, 
    [ExpirationDate] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_RefreshTokens_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users]([Id]),
)
