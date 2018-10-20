using System.Data.Common;
using System.Data.SqlClient;

namespace SampleApp
{
    #region snippet1
    public class SqlConnectionHealthCheck : DbConnectionHealthCheck
    {
        private static readonly string DefaultTestQuery = "SELECT 1";

        public SqlConnectionHealthCheck(string connectionString)
            : this(connectionString, testQuery: DefaultTestQuery)
        {
        }

        public SqlConnectionHealthCheck(string connectionString, 
            string testQuery) : base(connectionString, 
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
