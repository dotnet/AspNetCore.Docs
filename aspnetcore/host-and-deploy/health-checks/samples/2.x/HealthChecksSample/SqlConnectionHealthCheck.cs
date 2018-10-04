using System.Data.Common;
using System.Data.SqlClient;

namespace SampleApp
{
    #region snippet1
    public class SqlConnectionHealthCheck : DbConnectionHealthCheck
    {
        private static readonly string DefaultTestQuery = "SELECT 1";

        public SqlConnectionHealthCheck(string name, string connectionString)
            : this(name, connectionString, testQuery: DefaultTestQuery)
        {
        }

        public SqlConnectionHealthCheck(string name, string connectionString, 
            string testQuery) : base(name, connectionString, 
            testQuery ?? DefaultTestQuery)
        {
        }

        protected override DbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
    #endregion
}
