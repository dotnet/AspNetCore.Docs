Overview
The Negotiate package on Kestrel for ASP.NET Core 6.0/7.0 attempts by default to use Kerberos, which is a more secure and peformant authentication scheme than NTLM.  
You can see this configuration in services configuration in Program.cs.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});


NegotiateDefaults.AuthenticationScheme says to use Kerberos by default.  The FallbackPolicy will use the DefaultPolicy meaning if Kerberos not available, Kestrel will fall back to NTLM.
Kerberos is known as the Negotiate AuthenticationType, whereas NTLM is known as the NTLM AuthenticationType.  This can be seen by analyzing a request in Fiddler where you will the WWW-Authenticate header will contain either Negotiate or NTLM.
IIS and IISExpress supports both Kerberos and NTLM, however, Kestrel in disallows NTLM connections.
Steps to Reproduce
In Visual Studio Code, 
1.	Create a boilerplate ASP.NET Core MVC app with dotnet new mvc or stock ASP.NET Core React app with dotnet new react.  
2.	Install the Microsoft.AspNetCore.Authentication.Negotiate package.
3.	Add the above code for authentication and authorization.
4.	Ensure authentication and authorization are in the pipeline in the correct order.
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

5.	Run the application in Visual Studio Code or deploy it to a VM or server with Kestrel instead of IIS.
6.	When navigating to the site you may either see a login prompt or 401 status code.
7.	When analyzing the request in Fiddler, you notice a WWW-Authenticate: NTLM header.
Troubleshooting and Resolution
You will need to check to see if the computer running the application has a valid service principal name (SPN) registration with the HTTP service.  These same steps can be run locally, on a VM, server or within a Docker container host.
Kerberos on Kestrel is considered a user-defined authentication system.  Therefore, the SPN needs to be registered to a user account, not a machine account.
Steps for non-container environments
1.	The first step is to verify whether the account running dotnet.exe has a valid SPN on the container host.
2.	Run the setspn -L command to list all of the services your computer has an SPN registration for.
setspn -L <dotnet-account>
setspn -L MySiteAccount
NOTE: In this example, MySiteAccount needs to be an Active Directory domain account.  This account is not used to run the setspn command, it is the account the SPN will be registered under.  You will use a privileged account to run the setspn command.

3.	You will see a readout.  If you do not see any service named http or HTTP attached to the machine running the ASP.NET Core site then you do not have a valid SPN for Negotiate. We will assume the name of the machine running the site is myhost1.example.com.

Registered ServicePrincipalNames for CN=MySiteAccount, DC=com, DC=example:

HOST/myhost1.example.com

4.	Above you see that MySiteAccount, does not have an entry attached to the http service for myhost1.example.com, which is the  server or computer the website will run on.  Since you do not see a valid registration, you need to add your account to the http service for the server myhost1.example.com

5.	Run the setspn -S command TWICE once for the container host common  name and once for the FQDN. 
 
NOTE: In order to update setspn successfully, you will need to run the command either with an elevated command prompt with an account with either Domain Admin or Account Operators permissions.

Syntax:
setspn -S http/<server with FQDN> <dotnet-Account>
setspn -S http/myhost1.example.com MySiteAccount
setspn -S http/myhost1 MySiteAccount

6.	If successful you will see a message that the service principal name was updated.  If it fails, you will see an error.
7.	Run the setspn -L <dotnet Account> command again to verify that the registration was successfully updated.

setspn -L MySiteAccount

8.	You should see two listings for http with your account listed for the container host.
9.	Now exit from the command line and fire up the application again in a web browser.
10.	You should be able to successfully able to navigate within the web site without login prompts or 401 errors.
11.	You can confirm this by analyzing the request in Fiddler, noticing the WWW-Authenticate: Negotiate header.

        For a Docker container you will need to check whether the Group Managed Service Account (gMSA)  account you set up Kerberos has a valid service principal name (SPN) registered with the container host for the http service class.  For this example, the assumption is that you have have already created a gMSA account, named MyGMSA.
        To Create a gMSA account with credential spec file, please refer to the article Create gMSAs for Windows containers, https://learn.microsoft.com/en-us/virtualization/windowscontainers/manage-containers/manage-serviceaccounts.
       Steps for Windows container environments
1.	The first step is to verify whether the gMSA account has a valid SPN on the container host.
2.	Run the setspn -L command to list all of the services your computer has an SPN registration for.
setspn -L <gMSA-Account>
setspn -L MyGMSA
3.	You will see a readout.  If you do not see any service named http or HTTP attached to the container host then you do not have a valid SPN for Negotiate.

Registered ServicePrincipalNames for CN=MyGMSA,CN=Managed Service Accounts, DC=com, DC=example:

HOST/myhost1.example.com

4.	Above you see that MyGMSA, the gMSA account does not have an entry attached to the http service for myhost1.example.com, which is the  container host the Docker container will run on.  Since you do not see a valid registration, you need to add your gMSA account to the http service for the container host machine myhost1.example.com

5.	Run the setspn -S command TWICE once for the container host common  name and once for the FQDN. 
 
NOTE: In order to update setspn successfully, you will need to run the command either with an elevated command prompt with an account with either Domain Admin or Account Operators permissions.

Syntax:
setspn -S http/<containerhost with FQDN> <gMSA-Account>
setspn -S http/myhost1.example.com MyGMSA
setspn -S http/myhost1 MyGMSA

6.	If successful you will see a message that the service principal name was updated.  If it fails, you will see an error.
7.	Run the setspn -L <gMSA-Account> command again to verify that the registration was successfully updated.

setspn -L MyGMSA

8.	You should see two listings for http with your account listed for the container host.
9.	Now include a reference to the credential spec file that points to your gMSA account credential spec file in the docker run command.  Please refer to the article, Run a container with a gMSA, https://learn.microsoft.com/en-us/virtualization/windowscontainers/manage-containers/gmsa-run-container.

docker run --security-opt "credentialspec=file://example_myhost1.json" --hostname myhost1

10.	Now exit from the command line and fire up the application again in a web browser.
11.	You should be able to successfully able to navigate within the web site without login prompts or 401 errors.
12.	You can confirm this by analyzing the request in Fiddler, noticing the WWW-Authenticate: Negotiate header.
