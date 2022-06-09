CREATE PROCEDURE [dbo].[spRefreshToken_Insert]
  @Id int,
  @UserId NVARCHAR(128),
  @Token NVARCHAR(256),
  @JwtId NVARCHAR(128),
  @IsUsed BIT = 0,
  @IsRevoked BIT = 0,
  @AddedDate DATETIME,
  @ExpiresDate DATETIME
  
AS
BEGIN 
    INSERT INTO [dbo].[RefreshTokens]
    (
        [Id],
        [UserId],
        [Token],
        [JwtId],
        [IsUsed],
        [IsRevoked],
        [AddedDate],
        [ExpirationDate]
    )
    VALUES (
        @Id,
        @UserId,
        @Token,
        @JwtId,
        @IsUsed,
        @IsRevoked,
        @AddedDate,
        @ExpiresDate
    )
END

