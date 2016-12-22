CREATE PROCEDURE dbo.Categories_Delete
(
    @CategoryID int
)
AS
-- First, delete the associated products...
DELETE FROM Products
WHERE CategoryID = @CategoryID
-- Now delete the category
DELETE FROM Categories
WHERE CategoryID = @CategoryID