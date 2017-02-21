# Create a SQL Azure database server firewall rule for the IP address of the machine in which this script will run
# This will also whitelist all the Azure IP so that the website can access the database server
New-AzureSqlDatabaseServerFirewallRule -ServerName $databaseServerName -RuleName $FirewallRuleName -StartIpAddress $StartIPAddress 
-EndIpAddress $EndIPAddress -Verbose
New-AzureSqlDatabaseServerFirewallRule -ServerName $databaseServer.ServerName -AllowAllAzureServices 
-RuleName "AllowAllAzureIP" -Verbose