using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using System;
using Dapper;

namespace CustomIdentityProviderSample.CustomProvider
{
    public class DapperUsersTable
    {
        private readonly SqlConnection _connection;
        public DapperUsersTable(SqlConnection connection)
        {
            _connection = connection;
        }

#region createuser
        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            string sql = "INSERT INTO dbo.CustomUser " +
                "VALUES (@id, @Email, @EmailConfirmed, @PasswordHash, @UserName)";

            int rows = await _connection.ExecuteAsync(sql, new { user.Id, user.Email, user.EmailConfirmed, user.PasswordHash, user.UserName });

            if(rows > 0)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });
        }
#endregion

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            string sql = "DELETE FROM dbo.CustomUser WHERE Id = @Id";
            int rows = await _connection.ExecuteAsync(sql, new { user.Id });

            if(rows > 0)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = $"Could not delete user {user.Email}." });
        }


        public async Task<ApplicationUser> FindByIdAsync(Guid userId)
        {
            string sql = "SELECT * " +
                        "FROM dbo.CustomUsers " +
                        "WHERE Id = @Id;";

            return await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new
            {
                Id = userId
            });
        }


        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            string sql = "SELECT * " +
                        "FROM dbo.CustomUser " +
                        "WHERE UserName = @UserName;";

            return await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new
            {
                UserName = userName
            });
        }
    }
}
