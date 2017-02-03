protected void EncryptConnStrings_Click(object sender, EventArgs e)
{
    // Get configuration information about Web.config
    Configuration config = 
        WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    // Let's work with the <connectionStrings> section
    ConfigurationSection connectionStrings = config.GetSection("connectionStrings");
    if (connectionStrings != null)
        // Only encrypt the section if it is not already protected
        if (!connectionStrings.SectionInformation.IsProtected)
        {
            // Encrypt the <connectionStrings> section using the 
            // DataProtectionConfigurationProvider provider
            connectionStrings.SectionInformation.ProtectSection(
                "DataProtectionConfigurationProvider");
            config.Save();
            
            // Refresh the Web.config display
            DisplayWebConfig();
        }
}
protected void DecryptConnStrings_Click(object sender, EventArgs e)
{
    // Get configuration information about Web.config
    Configuration config = 
        WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    // Let's work with the <connectionStrings> section
    ConfigurationSection connectionStrings = 
        config.GetSection("connectionStrings");
    if (connectionStrings != null)
        // Only decrypt the section if it is protected
        if (connectionStrings.SectionInformation.IsProtected)
        {
            // Decrypt the <connectionStrings> section
            connectionStrings.SectionInformation.UnprotectSection();
            config.Save();
            // Refresh the Web.config display
            DisplayWebConfig();
        }
}