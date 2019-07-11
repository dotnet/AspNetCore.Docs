using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace WebPWrecover
{
    #region snippet1
    public class CustomEmailConfirmationTokenProvider<TUser>
                     : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomEmailConfirmationTokenProvider(IDataProtectionProvider 
            dataProtectionProvider,
            IOptions<EmailConfirmationTokenProviderOptions> options, 
            ILogger<DataProtectorTokenProvider<TUser>> logger)
                          : base(dataProtectionProvider, options, logger)
        {

        }
    }
    public class EmailConfirmationTokenProviderOptions
                                 : DataProtectionTokenProviderOptions
    {
        public EmailConfirmationTokenProviderOptions()
        {
            Name = "EmailDataProtectorTokenProvider";
            TokenLifespan = TimeSpan.FromHours(4);
        }
    }
    #endregion
}
