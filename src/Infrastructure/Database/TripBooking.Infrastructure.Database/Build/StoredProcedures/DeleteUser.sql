USE Booking
GO

CREATE PROCEDURE [Booking].[DeleteUser]
    @UserID UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [Booking].[Users] WHERE UserID = @UserID;
END
