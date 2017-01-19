CREATE PROCEDURE [dbo].[GetProductsWithPriceGreaterThan] 
( 
    @price money 
) 
WITH EXECUTE AS CALLER 
AS 
EXTERNAL NAME [ManuallyCreatedDBObjects].[StoredProcedures].[GetProductsWithPriceGreaterThan] 
GO