Protected Sub EncryptConnStrings_Click(sender As Object, e As EventArgs) _
    Handles EncryptConnStrings.Click
    'Get configuration information about Web.config
    Dim config As Configuration = _
        WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
    ' Let's work with the <connectionStrings> section
    Dim connectionStrings As ConfigurationSection = _
        config.GetSection("connectionStrings")
    If connectionStrings IsNot Nothing Then
        ' Only encrypt the section if it is not already protected
        If Not connectionStrings.SectionInformation.IsProtected Then
            ' Encrypt the <connectionStrings> section using the 
            ' DataProtectionConfigurationProvider provider
            connectionStrings.SectionInformation.ProtectSection( _
                "DataProtectionConfigurationProvider")
            config.Save()
            ' Refresh the Web.config display
            DisplayWebConfig()
        End If
    End If
End Sub
Protected Sub DecryptConnStrings_Click(sender As Object, e As EventArgs) _
    Handles DecryptConnStrings.Click
    ' Get configuration information about Web.config
    Dim config As Configuration = _
        WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
    ' Let's work with the <connectionStrings> section
    Dim connectionStrings As ConfigurationSection = _
        config.GetSection("connectionStrings")
    If connectionStrings IsNot Nothing Then
        ' Only decrypt the section if it is protected
        If connectionStrings.SectionInformation.IsProtected Then
            ' Decrypt the <connectionStrings> section
            connectionStrings.SectionInformation.UnprotectSection()
            config.Save()
            ' Refresh the Web.config display
            DisplayWebConfig()
        End If
    End If
End Sub