:: Creates a Web API project, adds ApiDescription.Server
:: and displays first few lines
set ProgramName=MyOpenApiTest
set Project=%ProgramName%.csproj
echo %ProgramName%
dotnet new webapi -n %ProgramName%
cd %ProgramName%
dotnet add package Microsoft.Extensions.ApiDescription.Server --version 9.0.0-*
dotnet build
findstr /n . obj\%ProgramName%.json  | findstr "^[0-5]:"
