MSBuild.exe /t:Build
            /p:Configuration=DEBUG
            /p:DeployOnBuild=true
            /p:DeployTarget=Package
            /p:EnablePackageProcessLoggingAndAssert=true
            [Your project].csproj