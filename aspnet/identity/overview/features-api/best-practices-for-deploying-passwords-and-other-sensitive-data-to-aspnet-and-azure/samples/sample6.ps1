param(
  [Parameter(Mandatory=$true)] 
  [String]$Name,
  [Parameter(Mandatory=$true)]
  [String]$Password)

$credPath = $PSScriptRoot + '\' + $Name + ".credential"
$PWord = ConvertTo-SecureString –String $Password –AsPlainText -Force 
$Credential = New-Object –TypeName `
System.Management.Automation.PSCredential –ArgumentList $Name, $PWord
$Credential | Export-CliXml $credPath