[Xml]$xml = Get-Content $scriptPath\$websiteName.publishsettings 
$password = $xml.publishData.publishProfile.userPWD[0]
$publishXmlFile = Join-Path $scriptPath -ChildPath ($websiteName + ".pubxml")