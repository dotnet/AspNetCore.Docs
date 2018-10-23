using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace HealthChecks.SqlServer
{
    public class SqlServerHealthCheck
        : IHealthCheck
    {
        private readonly string _connectionString;
        private readonly string _sql;
        public SqlServerHealthCheck(string sqlserverconnectionstring, string sql)
        {
            _connectionString = sqlserverconnectionstring ?? throw new ArgumentNullException(nameof(sqlserverconnectionstring));
            _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync(cancellationToken);

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = _sql;
                        await command.ExecuteScalarAsync();
                    }

                    return HealthCheckResult.Passed();
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Failed(exception:ex);
            }
        }
    }
}
