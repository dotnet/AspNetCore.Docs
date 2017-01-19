CREATE FUNCTION [dbo].[NearestDinners]
      (
      @lat real,
      @long real
      )
RETURNS  TABLE
AS
      RETURN
      SELECT Dinners.DinnerID
      FROM   Dinners 
      WHERE  dbo.DistanceBetween(@lat, @long, Latitude, Longitude) <100