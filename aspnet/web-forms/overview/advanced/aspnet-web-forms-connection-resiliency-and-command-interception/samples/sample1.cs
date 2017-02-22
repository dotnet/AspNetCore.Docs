using System.Data.Entity;
using System.Data.Entity.SqlServer;
 
namespace WingtipToys.Logic
{
	public class WingtipToysConfiguration : DbConfiguration
	{
		public WingtipToysConfiguration()
		{
		  SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
		}
	}
}