#Requires -Version 6.2
#Requires -RunAsAdministrator

param(
    [Parameter(mandatory=$true)]
    [string]
    $Name,
    [Parameter(mandatory=$true)]
    [string]
    $DisplayName,
    [Parameter(mandatory=$true)]
    [string]
    $Description,
    [Parameter(mandatory=$true)]
    [string]
    $Path,
    [Parameter(mandatory=$true)]
    [string]
    $Exe,
    [Parameter(mandatory=$true)]
    [string]
    $User
)

$acl = Get-Acl $Path
$aclRuleArgs = $cred.UserName, "Read, Write, ReadAndExecute", "ContainerInherit, ObjectInherit", "None", "Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule $aclRuleArgs
$acl.SetAccessRule($accessRule)
$acl | Set-Acl $Path

New-Service -Name $Name -BinaryPathName "$Path\$Exe" -Credential $User -Description $Description -DisplayName $DisplayName -StartupType Automatic
