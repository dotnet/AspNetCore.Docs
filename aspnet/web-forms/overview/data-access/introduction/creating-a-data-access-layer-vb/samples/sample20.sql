SELECT     EmployeeID, LastName, FirstName, Title, 
HireDate, ReportsTo, Country
FROM         Employees
WHERE ReportsTo = @ManagerID