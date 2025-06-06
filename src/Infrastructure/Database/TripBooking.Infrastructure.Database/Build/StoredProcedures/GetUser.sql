USE Booking
GO

CREATE PROCEDURE [Booking].[GetUser]
    @UserID UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UserID, 
           FirstName, 
           LastName, 
           BirthDate, 
           Username 
    FROM [Booking].[Users] 
    WHERE UserID = @UserID;
END
