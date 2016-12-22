Function GetPW_fromCredFile { Param( [String]$CredFile )
  $Credential = GetCredsFromFile $CredFile
  $PW = $Credential.GetNetworkCredential().Password  
  # $user just for debugging.
  $user = $Credential.GetNetworkCredential().username 
  Return $PW
}	
$AppSettings = @{	
  "FB_AppSecret"     = GetPW_fromCredFile "FB_AppSecret.credential";
  "GoogClientSecret" = GetPW_fromCredFile "GoogClientSecret.credential";
  "TwitterSecret"    = GetPW_fromCredFile "TwitterSecret.credential";
}
Set-AzureWebsite -Name $WebSiteName -AppSettings $AppSettings