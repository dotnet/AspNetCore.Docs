Function Get-SQLAzureDatabaseConnectionString
{
    Param(
        [String]$DatabaseServerName,
        [String]$DatabaseName,
        [String]$UserName,
        [String]$Password
    )

    Return "Server=tcp:$DatabaseServerName.database.windows.net,1433;Database=$DatabaseName;User ID=$UserName@$DatabaseServerName;Password=$Password;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"
}