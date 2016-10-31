# WARNING:  DO NOT MODIFY this file. Visual Studio will override it.
param()

$script:AspNetPublishHandlers = @{}

<#
These settings can be overridden with environment variables.
The name of the environment variable should use "Publish" as a
prefix and the names below. For example:

    $env:PublishMSDeployUseChecksum = $true
#>
$global:AspNetPublishSettings = New-Object -TypeName PSCustomObject @{
    MsdeployDefaultProperties = @{
        'MSDeployUseChecksum'=$false
        'SkipExtraFilesOnServer'=$true
        'retryAttempts' = 20
        'EnableMSDeployBackup' = $false
        'DeleteExistingFiles' = $false
        'AllowUntrustedCertificate'= $false
        'MSDeployPackageContentFoldername'='website\'
        'EnvironmentName' = 'Production'
        'AuthType'='Basic'
        'MSDeployPublishMethod'='WMSVC'
    }
}

function InternalOverrideSettingsFromEnv{
    [cmdletbinding()]
    param(
        [Parameter(Position=0)]
        [object[]]$settings = ($global:AspNetPublishSettings,$global:AspNetPublishSettings.MsdeployDefaultProperties),

        [Parameter(Position=1)]
        [string]$prefix = 'Publish'
    )
    process{
        foreach($settingsObj in $settings){
            if($settingsObj -eq $null){
                continue
            }

            $settingNames = $null
            if($settingsObj -is [hashtable]){
                $settingNames = $settingsObj.Keys
            }
            else{
                $settingNames = ($settingsObj | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty Name)

            }

            foreach($name in @($settingNames)){
                $fullname = ('{0}{1}' -f $prefix,$name)
                if(Test-Path "env:$fullname"){
                    $settingsObj.$name = ((get-childitem "env:$fullname").Value)
                }
            }
        }
    }
}

InternalOverrideSettingsFromEnv -prefix 'Publish' -settings $global:AspNetPublishSettings,$global:AspNetPublishSettings.MsdeployDefaultProperties

function Register-AspnetPublishHandler{
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0)]
        $name,
        [Parameter(Mandatory=$true,Position=1)]
        [ScriptBlock]$handler,
        [switch]$force
    )
    process{        
        if(!($script:AspNetPublishHandlers[$name]) -or $force ){
            'Adding handler for [{0}]' -f $name | Write-Verbose
            $script:AspNetPublishHandlers[$name] = $handler
        }
        elseif(!($force)){
            'Ignoring call to Register-AspnetPublishHandler for [name={0}], because a handler with that name exists and -force was not passed.' -f $name | Write-Verbose
        }
    }
}

function Get-AspnetPublishHandler{
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0)]
        $name
    )
    process{
        $foundHandler = $script:AspNetPublishHandlers[$name]

        if(!$foundHandler){
            throw ('AspnetPublishHandler with name "{0}" was not found' -f $name)
        }

        $foundHandler
    }
}

function GetInternal-ExcludeFilesArg{
    [cmdletbinding()]
    param(
        $publishProperties
    )
    process{
        $excludeFiles = $publishProperties['ExcludeFiles']
        foreach($exclude in $excludeFiles){
            if($exclude){
                [string]$objName = $exclude['objectname']

                if([string]::IsNullOrEmpty($objName)){
                    $objName = 'filePath'
                }

                $excludePath = $exclude['absolutepath']

                # output the result to the return list
                ('-skip:objectName={0},absolutePath=''{1}''' -f $objName, $excludePath)
            }   
        }
    }
}

function GetInternal-ReplacementsMSDeployArgs{
    [cmdletbinding()]
    param(
        $publishProperties
    )
    process{
        foreach($replace in ($publishProperties['Replacements'])){     
            if($replace){           
                $typeValue = $replace['type']
                if(!$typeValue){ $typeValue = 'TextFile' }
                
                $file = $replace['file']
                $match = $replace['match']
                $newValue = $replace['newValue']

                if($file -and $match -and $newValue){
                    $setParam = ('-setParam:type={0},scope={1},match={2},value={3}' -f $typeValue,$file, $match,$newValue)
                    'Adding setparam [{0}]' -f $setParam | Write-Verbose

                    # return it
                    $setParam
                }
                else{
                    'Skipping replacement because its missing a required value.[file="{0}",match="{1}",newValue="{2}"]' -f $file,$match,$newValue | Write-Verbose
                }
            }
        }       
    }
}

<#
.SYNOPSIS
Returns an array of msdeploy arguments that are used across different providers.
For example this will handle useChecksum, AppOffline etc.
This will also add default properties if they are missing.
#>
function GetInternal-SharedMSDeployParametersFrom{
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0)]
        [HashTable]$publishProperties,
        [Parameter(Mandatory=$true,Position=1)]
        [System.IO.FileInfo]$packOutput
    )
    process{
        $sharedArgs = New-Object psobject -Property @{
            ExtraArgs = @()
            DestFragment = ''
            EFMigrationData = @{}
        }

        # add default properties if they are missing
        foreach($propName in $global:AspNetPublishSettings.MsdeployDefaultProperties.Keys){
            if($publishProperties["$propName"] -eq $null){
                $defValue = $global:AspNetPublishSettings.MsdeployDefaultProperties["$propName"]
                'Adding default property to publishProperties ["{0}"="{1}"]' -f $propName,$defValue | Write-Verbose
                $publishProperties["$propName"] = $defValue
            }
        }

        if($publishProperties['MSDeployUseChecksum'] -eq $true){
            $sharedArgs.ExtraArgs += '-usechecksum'
        }

        if($publishProperties['EnableMSDeployAppOffline'] -eq $true){
            $sharedArgs.ExtraArgs += '-enablerule:AppOffline'
        }

        if($publishProperties['WebPublishMethod'] -eq 'MSDeploy'){           
            if($publishProperties['SkipExtraFilesOnServer'] -eq $true){
                $sharedArgs.ExtraArgs += '-enableRule:DoNotDeleteRule'
            }
        }

        if($publishProperties['WebPublishMethod'] -eq 'FileSystem'){
            if($publishProperties['DeleteExistingFiles'] -eq $false){
                $sharedArgs.ExtraArgs += '-enableRule:DoNotDeleteRule'
            }
        }

        if($publishProperties['retryAttempts']){
            $sharedArgs.ExtraArgs += ('-retryAttempts:{0}' -f ([int]$publishProperties['retryAttempts']))
        }

        if($publishProperties['EncryptWebConfig'] -eq $true){
            $sharedArgs.ExtraArgs += '-EnableRule:EncryptWebConfig'
        }

        if($publishProperties['EnableMSDeployBackup'] -eq $false){
            $sharedArgs.ExtraArgs += '-disablerule:BackupRule'
        }

        if($publishProperties['AllowUntrustedCertificate'] -eq $true){
            $sharedArgs.ExtraArgs += '-allowUntrusted'
        }

        # add excludes
        $sharedArgs.ExtraArgs += (GetInternal-ExcludeFilesArg -publishProperties $publishProperties)
        # add replacements
        $sharedArgs.ExtraArgs += (GetInternal-ReplacementsMSDeployArgs -publishProperties $publishProperties)

        # add EF Migration
        if (($publishProperties['EfMigrations'] -ne $null) -and $publishProperties['EfMigrations'].Count -gt 0){
            if (!(Test-Path -Path $publishProperties['ProjectPath'])) {
                throw 'ProjectPath property needs to be defined in the pubxml for EF migration.'
            }
            try {
                # generate T-SQL files
                $EFSqlFiles = GenerateInternal-EFMigrationScripts -projectPath $publishProperties['ProjectPath'] -packOutput $packOutput -EFMigrations $publishProperties['EfMigrations']
                $sharedArgs.EFMigrationData.Add('EFSqlFiles',$EFSqlFiles)
            }
            catch {
                throw ('An error occurred while generating EF migrations. {0} {1}' -f $_.Exception,(Get-PSCallStack))
            }
        }
        # add connection string update
        if (($publishProperties['DestinationConnectionStrings'] -ne $null) -and $publishProperties['DestinationConnectionStrings'].Count -gt 0) {
            try {
                # create/update appsettings.[environment].json
                GenerateInternal-AppSettingsFile -packOutput $packOutput -environmentName $publishProperties['EnvironmentName'] -connectionStrings $publishProperties['DestinationConnectionStrings']
            }
            catch {
                throw ('An error occurred while generating the publish appsettings file. {0} {1}' -f $_.Exception,(Get-PSCallStack))
            }
        }

        if(-not [string]::IsNullOrWhiteSpace($publishProperties['ProjectGuid'])) {
            AddInternal-ProjectGuidToWebConfig -publishProperties $publishProperties -packOutput $packOutput
        }

        # return the args
        $sharedArgs
    }
}

<#
.SYNOPSIS
This will publish the folder based on the properties in $publishProperties

.PARAMETER publishProperties
This is a hashtable containing the publish properties. See the examples here for more info on how to use this parameter.

.PARAMETER packOutput
The folder path to the output of the dnu publish command. This folder contains the files
that will be published.

.PARAMETER pubProfilePath
Path to a publish profile (.pubxml file) to import publish properties from. If the same property exists in
publishProperties and the publish profile then publishProperties will win.

.EXAMPLE
 Publish-AspNet -packOutput $packOutput -publishProperties @{
     'WebPublishMethod'='MSDeploy'
     'MSDeployServiceURL'='contoso.scm.azurewebsites.net:443';`
     'DeployIisAppPath'='contoso';'Username'='$contoso';'Password'="$env:PublishPwd"}

.EXAMPLE
Publish-AspNet -packOutput $packOutput -publishProperties @{
    'WebPublishMethod'='FileSystem'
    'publishUrl'="$publishDest"
    }

.EXAMPLE
Publish-AspNet -packOutput $packOutput -publishProperties @{
     'WebPublishMethod'='MSDeploy'
     'MSDeployServiceURL'='contoso.scm.azurewebsites.net:443';`
'DeployIisAppPath'='contoso';'Username'='$contoso';'Password'="$env:PublishPwd"
    'ExcludeFiles'=@(
        @{'absolutepath'='test.txt'},
        @{'absolutepath'='references.js'}
)} 

.EXAMPLE
Publish-AspNet -packOutput $packOutput -publishProperties @{
    'WebPublishMethod'='FileSystem'
    'publishUrl'="$publishDest"
    'ExcludeFiles'=@(
        @{'absolutepath'='test.txt'},
        @{'absolutepath'='_references.js'})
    'Replacements' = @(
        @{'file'='test.txt$';'match'='REPLACEME';'newValue'='updatedValue'})
    }

Publish-AspNet -packOutput $packOutput -publishProperties @{
    'WebPublishMethod'='FileSystem'
    'publishUrl'="$publishDest"
    'ExcludeFiles'=@(
        @{'absolutepath'='test.txt'},
        @{'absolutepath'='c:\\full\\path\\ok\\as\\well\\_references.js'})
    'Replacements' = @(
        @{'file'='test.txt$';'match'='REPLACEME';'newValue'='updatedValue'})
    }

.EXAMPLE
Publish-AspNet -packOutput $packOutput -publishProperties @{
    'WebPublishMethod'='FileSystem'
    'publishUrl'="$publishDest"
    'EnableMSDeployAppOffline'='true'
    'AppOfflineTemplate'='offline-template.html'
    'MSDeployUseChecksum'='true'
}
#>
function Publish-AspNet{
    param(
        [Parameter(Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
        [hashtable]$publishProperties = @{},

        [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
        [System.IO.FileInfo]$packOutput,

        [Parameter(Position=2,ValueFromPipelineByPropertyName=$true)]
        [System.IO.FileInfo]$pubProfilePath
    )
    process{
        if($publishProperties['WebPublishMethodOverride']){
            'Overriding publish method from $publishProperties[''WebPublishMethodOverride''] to [{0}]' -f  ($publishProperties['WebPublishMethodOverride']) | Write-Verbose
            $publishProperties['WebPublishMethod'] = $publishProperties['WebPublishMethodOverride']
        }

        if(-not [string]::IsNullOrWhiteSpace($pubProfilePath)){
            $profileProperties = Get-PropertiesFromPublishProfile -filepath $pubProfilePath
            foreach($key in $profileProperties.Keys){
                if(-not ($publishProperties.ContainsKey($key))){
                    'Adding properties from publish profile [''{0}''=''{1}'']' -f $key,$profileProperties[$key] | Write-Verbose
                    $publishProperties.Add($key,$profileProperties[$key])
                }
            }
        }

        if(!([System.IO.Path]::IsPathRooted($packOutput))){
            $packOutput = [System.IO.Path]::GetFullPath((Join-Path $pwd $packOutput))
        }

        $pubMethod = $publishProperties['WebPublishMethod']
        'Publishing with publish method [{0}]' -f $pubMethod | Write-Output

        # get the handler based on WebPublishMethod, and call it.
        &(Get-AspnetPublishHandler -name $pubMethod) $publishProperties $packOutput
    }
}

<#
.SYNOPSIS

Inputs:

Example of $xmlDocument: '<?xml version="1.0" encoding="utf-8"?><sitemanifest></sitemanifest>'
Example of $providerDataArray:

    [System.Collections.ArrayList]$providerDataArray = @()

    $iisAppSourceKeyValue=@{"iisApp" = @{"path"='c:\temp\pathtofiles';"appOfflineTemplate" ='offline-template.html'}}
    $providerDataArray.Add($iisAppSourceKeyValue)

    $dbfullsqlKeyValue=@{"dbfullsql" = @{"path"="c:\Temp\PathToSqlFile"}}
    $providerDataArray.Add($dbfullsqlKeyValue)

    $dbfullsqlKeyValue=@{"dbfullsql" = @{"path"="c:\Temp\PathToSqlFile2"}}
    $providerDataArray.Add($dbfullsqlKeyValue)

    Manifest File content:
            <?xml version="1.0" encoding="utf-8"?>
            <sitemanifest>
            <iisApp path="c:\temp\pathtofiles" appOfflineTemplate=�offline-template.html" />
            <dbFullSql path="c:\Temp\PathToSqlFile" />
            <dbFullSql path="c:\Temp\PathToSqlFile2" />
            </sitemanifest>
#>
function AddInternal-ProviderDataToManifest {
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true, Position=0)]
        [XML]$xmlDocument,
        [Parameter(Position=1)]
        [System.Collections.ArrayList]$providerDataArray
    )
    process {
        $siteNode = $xmlDocument.SelectSingleNode("/sitemanifest")
        if ($siteNode -eq $null) {
            throw 'sitemanifest element is missing in the xml object'
        }
        foreach ($providerData in $providerDataArray) {
            foreach ($providerName in $providerData.Keys) {
                $providerValue = $providerData[$providerName]
                $xmlNode = $xmlDocument.CreateElement($providerName)
                foreach ($providerValueKey in $providerValue.Keys) {
                    $xmlNode.SetAttribute($providerValueKey, $providerValue[$providerValueKey]) | Out-Null
                }
                $siteNode.AppendChild($xmlNode) | Out-Null 
            }
        }
    }
} 

function AddInternal-ProjectGuidToWebConfig {
    [cmdletbinding()]
    param(
        [Parameter(Position=0)]
        [HashTable]$publishProperties,
        [Parameter(Position=1)]
        [System.IO.FileInfo]$packOutput
    )
    process {
        try {
            [Reflection.Assembly]::LoadWithPartialName("System.Xml.Linq") | Out-Null
            $webConfigPath = Join-Path $packOutput 'web.config'
            $projectGuidCommentValue = 'ProjectGuid: {0}' -f $publishProperties['ProjectGuid']
            $xDoc = [System.Xml.Linq.XDocument]::Load($webConfigPath)
            $allNodes = $xDoc.DescendantNodes() 
            $projectGuidComment = $allNodes | Where-Object { $_.NodeType -eq [System.Xml.XmlNodeType]::Comment -and $_.Value -eq $projectGuidCommentValue } | Select -First 1    
            if($projectGuidComment -ne $null) {
                if($publishProperties['IgnoreProjectGuid'] -eq $true) {
                   $projectGuidComment.Remove() | Out-Null
                   $xDoc.Save($webConfigPath) | Out-Null
                }
            }
            else {
                if(-not ($publishProperties['IgnoreProjectGuid'] -eq $true)) {
                   $projectGuidComment = New-Object -TypeName System.Xml.Linq.XComment -ArgumentList $projectGuidCommentValue
                   $xDoc.LastNode.AddAfterSelf($projectGuidComment) | Out-Null
                   $xDoc.Save($webConfigPath) | Out-Null
                }
            }
        }
        catch {
        }
    }
}

<#
.SYNOPSIS

Example of $EFMigrations:
            $EFMigrations = @{'CarContext'='Car Context ConnectionString';'MovieContext'='Movie Context Connection String'}

#>

function GenerateInternal-EFMigrationScripts {
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0)]
        [System.IO.FileInfo]$projectPath,
        [Parameter(Mandatory=$true,Position=1)]
        [System.IO.FileInfo]$packOutput,
        [Parameter(Position=2)]
        [HashTable]$EFMigrations
    )
    process {          
        $files = @{}
        $dotnetExePath = GetInternal-DotNetExePath
        foreach ($dbContextName in $EFMigrations.Keys) {
            try 
            {
                $tempDir = GetInternal-PublishTempPath -packOutput $packOutput
                $efScriptFile = Join-Path $tempDir ('{0}.sql' -f $dbContextName)
                $arg = ('ef migrations script --idempotent --output {0} --context {1}' -f
                                       $efScriptFile,
                                       $dbContextName)

                Execute-Command $dotnetExePath $arg $projectPath | Out-Null
                if (Test-Path -Path $efScriptFile) {
                    if (!($files.ContainsKey($dbContextName))) {
                        $files.Add($dbContextName, $efScriptFile) | Out-Null
                    }
                }            
            }
            catch
            {
                throw 'error occured when executing dotnet.exe to generate EF T-SQL file'
            }
        }
        # return files object
        $files
    }
}

<#
.SYNOPSIS

Example of $connectionStrings:
            $connectionStrings = @{'DefaultConnection'='Default ConnectionString';'CarConnection'='Car Connection String'}

#>
function GenerateInternal-AppSettingsFile {
    [cmdletbinding()]
    param(
        [Parameter(Mandatory = $true,Position=0)]
        [System.IO.FileInfo]$packOutput,
        [Parameter(Mandatory = $true,Position=1)]
        [string]$environmentName,
        [Parameter(Position=2)]
        [HashTable]$connectionStrings
    )
    process {    
        $configProdJsonFile = 'appsettings.{0}.json' -f $environmentName
        $configProdJsonFilePath = Join-Path -Path $packOutput -ChildPath $configProdJsonFile 

        if ([string]::IsNullOrEmpty($configProdJsonFilePath)) {
            throw ('The path of {0} is empty' -f $configProdJsonFilePath)
        }
        
        if(!(Test-Path -Path $configProdJsonFilePath)) {
            # create new file
            '{}' | out-file -encoding utf8 -filePath $configProdJsonFilePath -Force
        }
        
        $jsonObj = ConvertFrom-Json -InputObject (Get-Content -Path $configProdJsonFilePath -Raw)
        # update when there exists one or more connection strings
        if ($connectionStrings -ne $null) {            
            foreach ($name in $connectionStrings.Keys) {
                #check for hierarchy style
                if ($jsonObj.ConnectionStrings.$name) {
                    $jsonObj.ConnectionStrings.$name = $connectionStrings[$name]
                    continue
                }
                #check for horizontal style
                $horizontalName = 'ConnectionStrings.{0}:' -f $name
                if ($jsonObj.$horizontalName) {
                    $jsonObj.$horizontalName = $connectionStrings[$name]
                    continue
                }
                # create new one
                if (!($jsonObj.ConnectionStrings)) {
                    $contentForDefaultConnection = '{}'
                    $jsonObj | Add-Member -name 'ConnectionStrings' -value (ConvertFrom-Json -InputObject $contentForDefaultConnection) -MemberType NoteProperty | Out-Null
                }
                if (!($jsonObj.ConnectionStrings.$name)) {
                    $jsonObj.ConnectionStrings | Add-Member -name $name -value $connectionStrings[$name] -MemberType NoteProperty | Out-Null
                }
            }            
        }
        
        $jsonObj | ConvertTo-Json | out-file -encoding utf8 -filePath $configProdJsonFilePath -Force
          
        #return the path of config.[environment].json
        $configProdJsonFilePath
    }
}

<#
.SYNOPSIS

Inputs:
Example of $providerDataArray:

    [System.Collections.ArrayList]$providerDataArray = @()

    $iisAppSourceKeyValue=@{"iisApp" = @{"path"='c:\temp\pathtofiles';"appOfflineTemplate" ='offline-template.html'}}
    $providerDataArray.Add($iisAppSourceKeyValue)

    $dbfullsqlKeyValue=@{"dbfullsql" = @{"path"="c:\Temp\PathToSqlFile"}}
    $providerDataArray.Add($dbfullsqlKeyValue)

    $dbfullsqlKeyValue=@{"dbfullsql" = @{"path"="c:\Temp\PathToSqlFile2"}}
    $providerDataArray.Add($dbfullsqlKeyValue)

    Manifest File content:
        <?xml version="1.0" encoding="utf-8"?>
        <sitemanifest>
        <iisApp path="c:\temp\pathtofiles" appOfflineTemplate=�offline-template.html" />
        <dbFullSql path="c:\Temp\PathToSqlFile" />
        <dbFullSql path="c:\Temp\PathToSqlFile2" />
        </sitemanifest>

#>

function GenerateInternal-ManifestFile {
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0)]
        [System.IO.FileInfo]$packOutput,
        [Parameter(Mandatory=$true,Position=1)]
        $publishProperties,
        [Parameter(Mandatory=$true,Position=2)]
        [System.Collections.ArrayList]$providerDataArray,
        [Parameter(Mandatory=$true,Position=3)]
        [ValidateNotNull()]
        $manifestFileName
    )
    process{
        $xmlDocument = [xml]'<?xml version="1.0" encoding="utf-8"?><sitemanifest></sitemanifest>'
        AddInternal-ProviderDataToManifest -xmlDocument $xmlDocument -providerDataArray $providerDataArray | Out-Null
        $publishTempDir = GetInternal-PublishTempPath -packOutput $packOutput
        $XMLFile = Join-Path $publishTempDir $manifestFileName
        $xmlDocument.OuterXml | out-file -encoding utf8 -filePath $XMLFile -Force
        
        # return 
        [System.IO.FileInfo]$XMLFile
    }
}

function GetInternal-PublishTempPath {
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true, Position=0)]
        [System.IO.FileInfo]$packOutput
    )
    process {
        $tempDir = [io.path]::GetTempPath()
        $packOutputFolderName = Split-Path $packOutput -Leaf
        $publishTempDir = [io.path]::combine($tempDir,'PublishTemp','obj',$packOutputFolderName)
        if (!(Test-Path -Path $publishTempDir)) {
            New-Item -Path $publishTempDir -type directory | Out-Null
        }
        # return 
        [System.IO.FileInfo]$publishTempDir
    }
}

function Publish-AspNetMSDeploy{
    param(
        [Parameter(Mandatory = $true,Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
        $publishProperties,
        [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
        $packOutput
    )
    process{
        if($publishProperties){
            $publishPwd = $publishProperties['Password']
            
            $sharedArgs = GetInternal-SharedMSDeployParametersFrom -publishProperties $publishProperties -packOutput $packOutput
            $iisAppPath = $publishProperties['DeployIisAppPath']
            
            # create source manifest

            # e.g
            # <?xml version="1.0" encoding="utf-8"?>
            # <sitemanifest>
            # <iisApp path="C:\Temp\PublishTemp\WebApplication\" appOfflineTemplate=�offline-template.html" />
            # <dbFullSql path="C:\Temp\PublishTemp\obj\WebApplication.Data.ApplicationDbContext.sql" />
            # <dbFullSql path="C:\Temp\PublishTemp\obj\WebApplication.Data.CarContext.sql" />
            # </sitemanifest>

            [System.Collections.ArrayList]$providerDataArray = @()
            $iisAppValues = @{"path"=$packOutput};
            $iisAppSourceKeyValue=@{"iisApp" = $iisAppValues}
            $providerDataArray.Add($iisAppSourceKeyValue) | Out-Null

            if ($sharedArgs.EFMigrationData -ne $null -and $sharedArgs.EFMigrationData.Contains('EFSqlFiles')) { 
                foreach ($sqlFile in $sharedArgs.EFMigrationData['EFSqlFiles'].Values) { 
                    $dbFullSqlSourceKeyValue=@{"dbFullSql" = @{"path"=$sqlFile}}
                    $providerDataArray.Add($dbFullSqlSourceKeyValue) | Out-Null       
                }
            }
            
            [System.IO.FileInfo]$sourceXMLFile = GenerateInternal-ManifestFile -packOutput $packOutput -publishProperties $publishProperties -providerDataArray $providerDataArray -manifestFileName 'SourceManifest.xml'
            
            $providerDataArray.Clear() | Out-Null
            # create destination manifest   

            # e.g
            # <?xml version="1.0" encoding="utf-8"?>
            # <sitemanifest><iisApp path="WebApplication8020160609015407" />
            # <dbFullSql path="Data Source=tcp:webapplicationdbserver.database.windows.net,1433;Initial Catalog=WebApplication_db;User Id=sqladmin@webapplicationdbserver;Password=<password>" />
            # <dbFullSql path="Data Source=tcp:webapplicationdbserver.database.windows.net,1433;Initial Catalog=WebApplication_db;User Id=sqladmin@webapplicationdbserver;Password=<password>" />
            # </sitemanifest>

            $iisAppValues = @{"path"=$iisAppPath};
            if(-not [string]::IsNullOrWhiteSpace($publishProperties['AppOfflineTemplate'])){
                $iisAppValues.Add("appOfflineTemplate", $publishProperties['AppOfflineTemplate']) | Out-Null
            }

            $iisAppDestinationKeyValue=@{"iisApp" = $iisAppValues}
            $providerDataArray.Add($iisAppDestinationKeyValue) | Out-Null

            if ($publishProperties['EfMigrations'] -ne $null -and $publishProperties['EfMigrations'].Count -gt 0) { 
                foreach ($connectionString in $publishProperties['EfMigrations'].Values) { 
                    $dbFullSqlDestinationKeyValue=@{"dbFullSql" = @{"path"=$connectionString}}
                    $providerDataArray.Add($dbFullSqlDestinationKeyValue) | Out-Null       
                }
            }


            [System.IO.FileInfo]$destXMLFile = GenerateInternal-ManifestFile -packOutput $packOutput -publishProperties $publishProperties -providerDataArray $providerDataArray -manifestFileName 'DestinationManifest.xml'
  
            <#
            "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" 
                -source:manifest='C:\Users\testuser\AppData\Local\Temp\PublishTemp\obj\SourceManifest.xml' 
                -dest:manifest='C:\Users\testuser\AppData\Local\Temp\PublishTemp\obj\DestManifest.xml',ComputerName='https://contoso.scm.azurewebsites.net/msdeploy.axd',UserName='$contoso',Password='<PWD>',IncludeAcls='False',AuthType='Basic' 
                -verb:sync 
                -enableRule:DoNotDeleteRule 
                -retryAttempts=2"
            #>

            if(-not [string]::IsNullOrWhiteSpace($publishProperties['MSDeployPublishMethod'])){
                $serviceMethod = $publishProperties['MSDeployPublishMethod']
            }
            
            $msdeployComputerName= InternalNormalize-MSDeployUrl -serviceUrl $publishProperties['MSDeployServiceURL'] -siteName $iisAppPath -serviceMethod $publishProperties['MSDeployPublishMethod']
            if($publishProperties['UseMSDeployServiceURLAsIs'] -eq $true){
               $msdeployComputerName = $publishProperties['MSDeployServiceURL']
            }

            $publishArgs = @()
            #use manifest to publish
            $publishArgs += ('-source:manifest=''{0}''' -f $sourceXMLFile.FullName)
            $publishArgs += ('-dest:manifest=''{0}'',ComputerName=''{1}'',UserName=''{2}'',Password=''{3}'',IncludeAcls=''False'',AuthType=''{4}''{5}' -f 
                                    $destXMLFile.FullName,
                                    $msdeployComputerName,
                                    $publishProperties['UserName'],
                                    $publishPwd,
                                    $publishProperties['AuthType'],
                                    $sharedArgs.DestFragment)
            $publishArgs += '-verb:sync'
            $publishArgs += $sharedArgs.ExtraArgs

            $command = '"{0}" {1}' -f (Get-MSDeploy),($publishArgs -join ' ')
            
            if (! [String]::IsNullOrEmpty($publishPwd)) {
            $command.Replace($publishPwd,'{PASSWORD-REMOVED-FROM-LOG}') | Print-CommandString
            }
            Execute-Command -exePath (Get-MSDeploy) -arguments ($publishArgs -join ' ')
        }
        else{
            throw 'publishProperties is empty, cannot publish'
        }
    }
}

function Escape-TextForRegularExpressions{
    [cmdletbinding()]
    param(
        [Parameter(Position=0,Mandatory=$true)]
        [string]$text
    )
    process{
        [regex]::Escape($text)
    }
}

function Publish-AspNetMSDeployPackage{
    param(
        [Parameter(Mandatory = $true,Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
        $publishProperties,
        [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
        $packOutput
    )
    process{
        if($publishProperties){
            $packageDestinationFilepath = $publishProperties['DesktopBuildPackageLocation']

            if(!$packageDestinationFilepath){
                throw ('The package destination property (DesktopBuildPackageLocation) was not found in the publish properties')
            }

            if(!([System.IO.Path]::IsPathRooted($packageDestinationFilepath))){
                $packageDestinationFilepath = [System.IO.Path]::GetFullPath((Join-Path $pwd $packageDestinationFilepath))
            }

            # if the dir doesn't exist create it
            $pkgDir = ((new-object -typename System.IO.FileInfo($packageDestinationFilepath)).Directory)
            if(!(Test-Path -Path $pkgDir)) {
                New-Item $pkgDir -type Directory | Out-Null
            }

            <#
            "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" 
                -source:manifest='C:\Users\testuser\AppData\Local\Temp\PublishTemp\obj\SourceManifest.xml'
                -dest:package=c:\temp\path\contosoweb.zip
                -verb:sync 
                -enableRule:DoNotDeleteRule  
                -retryAttempts=2 
            #>

            $sharedArgs = GetInternal-SharedMSDeployParametersFrom -publishProperties $publishProperties -packOutput $packOutput

            # create source manifest

            # e.g
            # <?xml version="1.0" encoding="utf-8"?>
            # <sitemanifest>
            # <iisApp path="C:\Temp\PublishTemp\WebApplication\" />
            # </sitemanifest>

            [System.Collections.ArrayList]$providerDataArray = @()
            $iisAppSourceKeyValue=@{"iisApp" = @{"path"=$packOutput}}
            $providerDataArray.Add($iisAppSourceKeyValue) | Out-Null

            [System.IO.FileInfo]$sourceXMLFile = GenerateInternal-ManifestFile -packOutput $packOutput -publishProperties $publishProperties -providerDataArray $providerDataArray -manifestFileName 'SourceManifest.xml' 

            $publishArgs = @()
            $publishArgs += ('-source:manifest=''{0}''' -f $sourceXMLFile.FullName)
            $publishArgs += ('-dest:package=''{0}''' -f $packageDestinationFilepath)
            $publishArgs += '-verb:sync'
            $packageContentFolder = $publishProperties['MSDeployPackageContentFoldername']
            if(!$packageContentFolder){ $packageContentFolder = 'website' }
            $publishArgs += ('-replace:match=''{0}'',replace=''{1}''' -f (Escape-TextForRegularExpressions $packOutput), $packageContentFolder )
            $publishArgs += $sharedArgs.ExtraArgs
            
            $command = '"{0}" {1}' -f (Get-MSDeploy),($publishArgs -join ' ')
            $command | Print-CommandString
            Execute-Command -exePath (Get-MSDeploy) -arguments ($publishArgs -join ' ')
        }
        else{
            throw 'publishProperties is empty, cannot publish'
        }
    }
}

function Publish-AspNetFileSystem{
    param(
        [Parameter(Mandatory = $true,Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
        $publishProperties,
        [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
        $packOutput
    )
    process{
        $pubOut = $publishProperties['publishUrl']
        
        if([string]::IsNullOrWhiteSpace($pubOut)){
            throw ('publishUrl is a required property for FileSystem publish but it was empty.')
        }

        # if it's a relative path then update it to a full path
        if(!([System.IO.Path]::IsPathRooted($pubOut))){
            $pubOut = [System.IO.Path]::GetFullPath((Join-Path $pwd $pubOut))
            $publishProperties['publishUrl'] = "$pubOut"
        }

        'Publishing files to {0}' -f $pubOut | Write-Output

        # we use msdeploy.exe because it supports incremental publish/skips/replacements/etc
        # msdeploy.exe -verb:sync -source:manifest='C:\Users\testuser\AppData\Local\Temp\PublishTemp\obj\SourceManifest.xml' -dest:manifest='C:\Users\testuser\AppData\Local\Temp\PublishTemp\obj\DestManifest.xml'
        
        $sharedArgs = GetInternal-SharedMSDeployParametersFrom -publishProperties $publishProperties -packOutput $packOutput

        # create source manifest

        # e.g
        # <?xml version="1.0" encoding="utf-8"?>
        # <sitemanifest>
        # <contentPath path="C:\Temp\PublishTemp\WebApplication\" appOfflineTemplate=�offline-template.html" />
        # </sitemanifest>

        [System.Collections.ArrayList]$providerDataArray = @()
        $contentPathValues = @{"path"=$packOutput};
        $contentPathSourceKeyValue=@{"contentPath" = $contentPathValues}
        $providerDataArray.Add($contentPathSourceKeyValue) | Out-Null
            
        [System.IO.FileInfo]$sourceXMLFile = GenerateInternal-ManifestFile -packOutput $packOutput -publishProperties $publishProperties -providerDataArray $providerDataArray -manifestFileName 'SourceManifest.xml'
            
        $providerDataArray.Clear() | Out-Null
        # create destination manifest   

        # e.g
        # <?xml version="1.0" encoding="utf-8"?>
        # <sitemanifest><contentPath path="C:\Temp\PublishTemp\WebApplicationDestination\" />
        # </sitemanifest>
        $contentPathValues = @{"path"=$publishProperties['publishUrl']};
        if(-not [string]::IsNullOrWhiteSpace($publishProperties['AppOfflineTemplate'])){
            $contentPathValues.Add("appOfflineTemplate", $publishProperties['AppOfflineTemplate']) | Out-Null
        }
        $contentPathDestinationKeyValue=@{"contentPath" = $contentPathValues}
        $providerDataArray.Add($contentPathDestinationKeyValue) | Out-Null

        [System.IO.FileInfo]$destXMLFile = GenerateInternal-ManifestFile -packOutput $packOutput -publishProperties $publishProperties -providerDataArray $providerDataArray -manifestFileName 'DestinationManifest.xml'
        
        $publishArgs = @()
        $publishArgs += ('-source:manifest=''{0}''' -f $sourceXMLFile.FullName)
        $publishArgs += ('-dest:manifest=''{0}''{1}' -f $destXMLFile.FullName, $sharedArgs.DestFragment)
        $publishArgs += '-verb:sync'
        $publishArgs += $sharedArgs.ExtraArgs

        $command = '"{0}" {1}' -f (Get-MSDeploy),($publishArgs -join ' ')
        $command | Print-CommandString
        Execute-Command -exePath (Get-MSDeploy) -arguments ($publishArgs -join ' ')
        
        # copy sql script to script folder
        if (($sharedArgs.EFMigrationData['EFSqlFiles'] -ne $null) -and ($sharedArgs.EFMigrationData['EFSqlFiles'].Count -gt 0)) {
            $scriptsDir = Join-Path $pubOut 'efscripts'

            if (!(Test-Path -Path $scriptsDir)) {
                New-Item -Path $scriptsDir -type directory | Out-Null
            }

            foreach ($sqlFile in $sharedArgs.EFMigrationData['EFSqlFiles'].Values) {
                Copy-Item $sqlFile -Destination $scriptsDir -Force -Recurse | Out-Null
            }
        }
    }
}

<#
.SYNOPSIS
    This can be used to read a publish profile to extract the property values into a hashtable.

.PARAMETER filepath
    Path to the publish profile to get the properties from. Currenlty this only supports reading
    .pubxml files.

.EXAMPLE
    Get-PropertiesFromPublishProfile -filepath c:\projects\publish\devpublish.pubxml
#>
function Get-PropertiesFromPublishProfile{
    [cmdletbinding()]
    param(
        [Parameter(Position=0,Mandatory=$true)]
        [ValidateNotNull()]
        [ValidateScript({Test-Path $_})]
        [System.IO.FileInfo]$filepath
    )
    begin{
        Add-Type -AssemblyName System.Core
        Add-Type -AssemblyName Microsoft.Build
    }
    process{
        'Reading publish properties from profile [{0}]' -f $filepath | Write-Verbose
        # use MSBuild to get the project and read properties
        $projectCollection = (New-Object Microsoft.Build.Evaluation.ProjectCollection)
        if(!([System.IO.Path]::IsPathRooted($filepath))){
            $filepath = [System.IO.Path]::GetFullPath((Join-Path $pwd $filepath))
        }
        $project = ([Microsoft.Build.Construction.ProjectRootElement]::Open([string]$filepath.Fullname, $projectCollection))

        $properties = @{}
        foreach($property in $project.Properties){
            $properties[$property.Name]=$property.Value
        }

        $properties
    }
}

function Print-CommandString{
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0,ValueFromPipeline=$true)]
        $command
    )
    process{
        'Executing command [{0}]' -f $command | Write-Output
    }
}

function Execute-CommandString{
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0,ValueFromPipeline=$true)]
        [string[]]$command,
        
        [switch]
        $useInvokeExpression,

        [switch]
        $ignoreErrors
    )
    process{
        foreach($cmdToExec in $command){
            'Executing command [{0}]' -f $cmdToExec | Write-Verbose
            if($useInvokeExpression){
                try {
                    Invoke-Expression -Command $cmdToExec
                }
                catch {
                    if(-not $ignoreErrors){
                        $msg = ('The command [{0}] exited with exception [{1}]' -f $cmdToExec, $_.ToString())
                        throw $msg
                    }
                }
            }
            else {
                cmd.exe /D /C $cmdToExec

                if(-not $ignoreErrors -and ($LASTEXITCODE -ne 0)){
                    $msg = ('The command [{0}] exited with code [{1}]' -f $cmdToExec, $LASTEXITCODE)
                    throw $msg
                }
            }
        }
    }
}

function Execute-Command {
    [cmdletbinding()]
    param(
        [Parameter(Mandatory = $true,Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
        [String]$exePath,
        [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
        [String]$arguments,
        [Parameter(Position=2)]
        [System.IO.FileInfo]$workingDirectory
        )
    process{
        $psi = New-Object -TypeName System.Diagnostics.ProcessStartInfo
        $psi.CreateNoWindow = $true
        $psi.UseShellExecute = $false
        $psi.RedirectStandardOutput = $true
        $psi.RedirectStandardError=$true
        $psi.FileName = $exePath
        $psi.Arguments = $arguments
        if($workingDirectory -and (Test-Path -Path $workingDirectory)) {
            $psi.WorkingDirectory = $workingDirectory
        }

        $process = New-Object -TypeName System.Diagnostics.Process
        $process.StartInfo = $psi
        $process.EnableRaisingEvents=$true

        # Register the event handler for error
        $stdErrEvent = Register-ObjectEvent -InputObject $process  -EventName 'ErrorDataReceived' -Action {
            if (! [String]::IsNullOrEmpty($EventArgs.Data)) {
             $EventArgs.Data | Write-Error 
            }
        }

        # Starting process.
        $process.Start() | Out-Null
        $process.BeginErrorReadLine() | Out-Null
        $output = $process.StandardOutput.ReadToEnd()
        $process.WaitForExit() | Out-Null
        $output | Write-Output
        
        # UnRegister the event handler for error
        Unregister-Event -SourceIdentifier $stdErrEvent.Name | Out-Null
    }
}


function GetInternal-DotNetExePath {
    process {
        $dotnetinstallpath = $env:dotnetinstallpath
        if (!$dotnetinstallpath) {
            $DotNetRegItem = Get-ItemProperty -Path 'hklm:\software\dotnet\setup\'
            if ($env:DOTNET_HOME) {
                $dotnetinstallpath = Join-Path $env:DOTNET_HOME -ChildPath 'dotnet.exe'
            }
            elseif ($DotNetRegItem -and $DotNetRegItem.InstallDir){
                $dotnetinstallpath = Join-Path $DotNetRegItem.InstallDir -ChildPath 'dotnet.exe'
            }
        }
        if (!(Test-Path $dotnetinstallpath)) {
            throw 'Unable to find dotnet.exe, please install it and try again'
        }
        # return
        [System.IO.FileInfo]$dotnetinstallpath
    }
}

function Get-MSDeploy{
    [cmdletbinding()]
    param()
    process{
        $installPath = $env:msdeployinstallpath

        if(!$installPath){
            $keysToCheck = @('hklm:\SOFTWARE\Microsoft\IIS Extensions\MSDeploy\3','hklm:\SOFTWARE\Microsoft\IIS Extensions\MSDeploy\2','hklm:\SOFTWARE\Microsoft\IIS Extensions\MSDeploy\1')

            foreach($keyToCheck in $keysToCheck){
                if(Test-Path $keyToCheck){
                    $installPath = (Get-itemproperty $keyToCheck -Name InstallPath -ErrorAction SilentlyContinue | select -ExpandProperty InstallPath -ErrorAction SilentlyContinue)
                }

                if($installPath){
                    break;
                }
            }
        }

        if(!$installPath){
            throw "Unable to find msdeploy.exe, please install it and try again"
        }

        [string]$msdInstallLoc = (join-path $installPath 'msdeploy.exe')

        "Found msdeploy.exe at [{0}]" -f $msdInstallLoc | Write-Verbose
        
        $msdInstallLoc
    }
}

function InternalNormalize-MSDeployUrl{
    [cmdletbinding()]
    param(
        [Parameter(Position=0,Mandatory=$true)]
        [string]$serviceUrl,

        [string] $siteName,
        
        [ValidateSet('WMSVC','RemoteAgent','InProc')]
        [string]$serviceMethod = 'WMSVC'
    )
    process{
        $tempUrl = $serviceUrl
        $resultUrl = $serviceUrl

        $httpsStr = 'https://'
        $httpStr = 'http://'
        $msdeployAxd = 'msdeploy.axd'

        if(-not [string]::IsNullOrWhiteSpace($serviceUrl)){
            if([string]::Compare($serviceMethod,'WMSVC',[StringComparison]::OrdinalIgnoreCase) -eq 0){
                # if no http or https then add one
                if(-not ($serviceUrl.StartsWith($httpStr,[StringComparison]::OrdinalIgnoreCase) -or 
                            $serviceUrl.StartsWith($httpsStr,[StringComparison]::OrdinalIgnoreCase)) ){

                    $serviceUrl = [string]::Concat($httpsStr,$serviceUrl.TrimStart())
                }
                [System.Uri]$serviceUri = New-Object -TypeName 'System.Uri' $serviceUrl
                [System.UriBuilder]$serviceUriBuilder = New-Object -TypeName 'System.UriBuilder' $serviceUrl

                # if it's https and the port was not passed in override it to 8172
                if( ([string]::Compare('https',$serviceUriBuilder.Scheme,[StringComparison]::OrdinalIgnoreCase) -eq 0) -and
                     -not $serviceUrl.Contains((':{0}' -f $serviceUriBuilder.Port)) ) {
                    $serviceUriBuilder.Port = 8172
                }

                # if no path then add one
                if([string]::Compare('/',$serviceUriBuilder.Path,[StringComparison]::OrdinalIgnoreCase) -eq 0){
                    $serviceUriBuilder.Path = $msdeployAxd
                }
                
                if ([string]::IsNullOrEmpty($serviceUriBuilder.Query) -and -not([string]::IsNullOrEmpty($siteName)))
                {
                    $serviceUriBuilder.Query = "site=" + $siteName;
                }

                $resultUrl = $serviceUriBuilder.Uri.AbsoluteUri
            }
            elseif([string]::Compare($serviceMethod,'RemoteAgent',[StringComparison]::OrdinalIgnoreCase) -eq 0){
                [System.UriBuilder]$serviceUriBuilder = New-Object -TypeName 'System.UriBuilder' $serviceUrl
                # http://{computername}/MSDEPLOYAGENTSERVICE
                # remote agent must use http
                $serviceUriBuilder.Scheme = 'http'
                $serviceUriBuilder.Path = '/MSDEPLOYAGENTSERVICE'
                
                $resultUrl = $serviceUriBuilder.Uri.AbsoluteUri
            }
            else{
                # see if it's for localhost
                [System.Uri]$serviceUri = New-Object -TypeName 'System.Uri' $serviceUrl
                $resultUrl = $serviceUri.AbsoluteUri
            }
        }

        # return the result to the caller
        $resultUrl        
    }
}

function InternalRegister-AspNetKnownPublishHandlers{
    [cmdletbinding()]
    param()
    process{
        'Registering MSDeploy handler' | Write-Verbose
        Register-AspnetPublishHandler -name 'MSDeploy' -force -handler {
            [cmdletbinding()]
            param(
                [Parameter(Mandatory = $true,Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
                $publishProperties,
                [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
                $packOutput
            )

            Publish-AspNetMSDeploy -publishProperties $publishProperties -packOutput $packOutput
        }

        'Registering MSDeploy package handler' | Write-Verbose
        Register-AspnetPublishHandler -name 'Package' -force -handler {
            [cmdletbinding()]
            param(
                [Parameter(Mandatory = $true,Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
                $publishProperties,
                [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
                $packOutput
            )

            Publish-AspNetMSDeployPackage -publishProperties $publishProperties -packOutput $packOutput
        }

        'Registering FileSystem handler' | Write-Verbose
        Register-AspnetPublishHandler -name 'FileSystem' -force -handler {
            [cmdletbinding()]
            param(
                [Parameter(Mandatory = $true,Position=0,ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
                $publishProperties,
                [Parameter(Mandatory = $true,Position=1,ValueFromPipelineByPropertyName=$true)]
                $packOutput
            )
    
            Publish-AspNetFileSystem -publishProperties $publishProperties -packOutput $packOutput
        }
    }
}

<#
.SYNOPSIS
    Used for testing purposes only.
#>
function InternalReset-AspNetPublishHandlers{
    [cmdletbinding()]
    param()
    process{
        $script:AspNetPublishHandlers = @{}
        InternalRegister-AspNetKnownPublishHandlers
    }
}

Export-ModuleMember -function Get-*,Publish-*,Register-*,Enable-*
if($env:IsDeveloperMachine){
    # you can set the env var to expose all functions to importer. easy for development.
    # this is required for executing pester test cases, it's set by build.ps1
    Export-ModuleMember -function *
}

# register the handlers so that Publish-AspNet can be called
InternalRegister-AspNetKnownPublishHandlers

