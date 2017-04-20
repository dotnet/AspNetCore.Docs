CREATE FUNCTION udf_ComputeInventoryValue
(
    @UnitPrice money,
    @UnitsInStock smallint,
    @Discontinued bit
)
RETURNS money
AS
BEGIN
    DECLARE @Value decimal
    SET @Value = ISNULL(@UnitPrice, 0) * ISNULL(@UnitsInStock, 0)
    IF @Discontinued = 1
        SET @Value = @Value * 0.5
    
    RETURN @Value
END