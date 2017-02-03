protected string DisplayDaysOnJob(Northwind.EmployeesRow employee)
{
    // Make sure HiredDate is not null... if so, return "Unknown"
    if (employee.IsHireDateNull())
        return "Unknown";
    else
    {
        // Returns the number of days between the current
        // date/time and HireDate
        TimeSpan ts = DateTime.Now.Subtract(employee.HireDate);
        return ts.Days.ToString("#,##0");
    }
}