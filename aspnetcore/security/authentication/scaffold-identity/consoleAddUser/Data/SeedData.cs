using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManager.Data
{
    public static class SeedData
    {
        #region snippet

        public static async Task Initialize(IServiceProvider serviceProvider,
                                            List<string> userList)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            foreach (var userName in userList)
            {
                var userPassword = GenerateSecurePassword();
                var userId = await EnsureUser(userManager, userName, userPassword);

                NotifyUser(userName, userPassword);
            }
        }

        private static async Task<string> EnsureUser(UserManager<IdentityUser> userManager,
                                                     string userName, string userPassword)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                user = new IdentityUser(userName)
                {
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, userPassword);
            }

            return user.Id;
        }
        #endregion

        private static string GenerateSecurePassword()
        {
            // Generate a secure password
            return "A Str0ng Pa$$w0rd !";
        }

        private static void NotifyUser(string userName, string userPassword)
        {
            // Notify user
        }
    }
}