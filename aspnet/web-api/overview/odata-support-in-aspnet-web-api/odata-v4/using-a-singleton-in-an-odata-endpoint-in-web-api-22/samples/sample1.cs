/// <summary> 
/// Present the EntityType "Employee" 
/// </summary> 
public class Employee 
{     
    public int ID { get; set; }     
    public string Name { get; set; }  
   
    [Singleton]     
    public Company Company { get; set; } 
} 
/// <summary> 
/// Present company category, which is an enum type 
/// </summary> 
public enum CompanyCategory 
{ 
    IT = 0,     
    Communication = 1,     
    Electronics = 2,     
    Others = 3 
} 
/// <summary> 
/// Present the EntityType "Company" 
/// </summary> 
public class Company 
{
     public int ID { get; set; }
     public string Name { get; set; }
     public Int64 Revenue { get; set; }
     public CompanyCategory Category { get; set; }
     public List<Employee> Employees { get; set; } 
}