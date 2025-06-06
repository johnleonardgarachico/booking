USE Booking
GO

CREATE PROCEDURE [Booking].[UpdateUser]
    @UserID UNIQUEIDENTIFIER,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @BirthDate DATE,
    @Username VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [Booking].[Users]
    SET FirstName = @FirstName,
        LastName = @LastName,
        BirthDate = @BirthDate,
        Username = @Username,
        [Password] = @Password
    WHERE UserID = @UserID;
END
