SELECT Employees.EmployeeID, Employees.LastName, 
       Employees.FirstName, Employees.Title, 
       Employees.HireDate, Employees.ReportsTo, 
       Employees.Country,
       Manager.FirstName as ManagerFirstName, 
       Manager.LastName as ManagerLastName
FROM Employees
    LEFT JOIN Employees AS Manager ON
        Employees.ReportsTo = Manager.EmployeeID