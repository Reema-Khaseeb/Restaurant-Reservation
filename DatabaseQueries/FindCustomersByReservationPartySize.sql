USE [RestaurantReservationCore]
GO

IF OBJECT_ID('dbo.FindCustomersByReservationPartySize', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.FindCustomersByReservationPartySize;
END

CREATE PROCEDURE FindCustomersByReservationPartySize
    @partySizeThreshold INT
AS
BEGIN
    SELECT C.*
    FROM Customers C
    INNER JOIN Reservations R ON C.CustomerId = R.CustomerId
    WHERE R.PartySize > @partySizeThreshold;
END
