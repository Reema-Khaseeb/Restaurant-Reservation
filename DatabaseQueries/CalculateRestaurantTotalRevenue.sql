USE [RestaurantReservationCore]
GO

CREATE FUNCTION CalculateRestaurantTotalRevenue(@restaurantId int)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @totalRevenue DECIMAL(10, 2);

    SELECT @totalRevenue = SUM(o.TotalAmount)
    FROM Orders o
    INNER JOIN Reservations r ON o.ReservationId = r.ReservationId
    WHERE r.RestaurantId = @restaurantId;

    RETURN @totalRevenue;
END;
