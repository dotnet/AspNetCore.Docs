# Create a database context which includes the server name and credential
# These are all local operations. No API call to Azure
$credential = New-PSCredentialFromPlainText -UserName $UserName -Password $Password
$context = New-AzureSqlDatabaseServerContext -ServerName $databaseServer.ServerName -Credential $credential