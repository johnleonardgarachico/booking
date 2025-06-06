USE Booking
GO

CREATE PROCEDURE [Booking].[AddUser]
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @BirthDate DATE,
    @Username VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [Booking].[Users] (FirstName, LastName, BirthDate, Username, [Password])
    OUTPUT INSERTED.UserID
    VALUES (@FirstName, @LastName, @BirthDate, @Username, @Password);
END
