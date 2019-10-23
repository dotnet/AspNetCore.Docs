using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace ContactManager.Data
{
    public static class SeedData
    {
        #region snippet

        public static async Task Initialize(IServiceProvider serviceProvider, string userList)
        {
            using (var context = new AppDbCntx(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbCntx>>()))
            {
                var userPW = GetNextUserGeneratePW(userList);
                while (userPW.user != null)
                {
                    var userID = await EnsureUser(serviceProvider, userPW.password, 
                                                  userPW.user);
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

        static int cnt;

        private static (string password, string user) GetNextUserGeneratePW(string userList)
        {
            if (cnt++ > 0)
                return (password: null, user: null);


            return (password: "A Str0ng Pa$$w0rd !", user: "joe@example.com");
        }

        private static void NotifyUser((string password, string user) userPW)
        {
            return;
            // Notify user
        }
    }
}