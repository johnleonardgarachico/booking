USE Booking
GO

CREATE TABLE [Booking].[Users] (
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    Username VARCHAR(255) NOT NULL,
    [Password] VARCHAR(255) NOT NULL
);

CREATE TABLE [Booking].[Market] (
    MarketID INT IDENTITY(1, 1) PRIMARY KEY,
    Origin VARCHAR(20) NOT NULL,
    Destination VARCHAR(20) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Departure TIME NOT NULL,
);

CREATE TABLE [Booking].[MarketAvailability] (
    MarketAvailabilityID INT IDENTITY(1, 1) PRIMARY KEY,
    MarketID INT NOT NULL,
    Capacity INT NOT NULL,
    Available INT NOT NULL
);

CREATE TABLE [Booking].[Booking] (
    BookingID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserID UNIQUEIDENTIFIER NOT NULL,
    MarketAvailabilityID INT NOT NULL
);

