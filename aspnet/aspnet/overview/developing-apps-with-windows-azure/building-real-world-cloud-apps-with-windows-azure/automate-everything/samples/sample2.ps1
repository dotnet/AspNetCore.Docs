[CmdletBinding(PositionalBinding=$True)]
Param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-z0-9]*$")]
    [String]$Name,                             
    [String]$Location = "West US",             
    [String]$SqlDatabaseUserName = "dbuser",   
    [String]$SqlDatabasePassword,              
    [String]$StartIPAddress,                   
    [String]$EndIPAddress                      
    )