#Requires -Version 6.1.3
#Requires -RunAsAdministrator

param(
    [Parameter(mandatory=$true)]
    $Name,
    [Parameter(mandatory=$true)]
    $DisplayName,
    [Parameter(mandatory=$true)]
    $Description,
    [Parameter(mandatory=$true)]
    $Path,
    [Parameter(mandatory=$true)]
    $Exe,
    [Parameter(mandatory=$true)]
    $User
)

$cred = Get-Credential -Credential $User

$acl = Get-Acl $Path
$aclRuleArgs = $cred.UserName, "Read,Write,ReadAndExecute", "ContainerInherit, ObjectInherit", "None", "Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule $aclRuleArgs
$acl.SetAccessRule($accessRule)
$acl | Set-Acl $Path

New-Service -Name $Name -BinaryPathName "$Path\$Exe" -Credential $cred -Description $Description -DisplayName $DisplayName -StartupType Automatic
