public class UmbrellaController : ODataController 
{
    public static Company Umbrella;
    static UmbrellaController()
    {
        InitData();
    }
    private static void InitData()
    {
        Umbrella = new Company()
        {
            ID = 1,
            Name = "Umbrella",
            Revenue = 1000,
            Category = CompanyCategory.Communication,
            Employees = new List<Employee>()
        };
    } 
}