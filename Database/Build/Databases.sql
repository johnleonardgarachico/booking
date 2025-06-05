IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Booking')
BEGIN
    CREATE DATABASE Booking;
END