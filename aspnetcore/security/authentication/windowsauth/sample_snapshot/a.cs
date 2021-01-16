services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate(options =>
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            options.EnableLdap("contoso.com");
            options.MachineAccountName = "machineName";
            options.MachineAccountPassword = "PassW0rd";
        }
    });