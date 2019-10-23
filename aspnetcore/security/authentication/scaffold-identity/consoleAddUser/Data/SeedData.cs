using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace ContactManager.Data
{
    #region snippet
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string userList)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var userPW = GetNextUserGeneratePW(userList);
                while (userPW.user != null)
                {
                    var userID = await EnsureUser(serviceProvider, userPW.password, userPW.user);
                    NotifyUser(userPW);
                    userPW = GetNextUserGeneratePW(userList);
                }
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("Create user failed");
            }

            return user.Id;
        }
        #endregion

        private static (string password, string user) GetNextUserGeneratePW(string userList)
        {
            return (password: "strong password", user: "useralias");
        }

        private static void NotifyUser((string password, string user) userPW)
        {
            throw new NotImplementedException();
        }
    }
}