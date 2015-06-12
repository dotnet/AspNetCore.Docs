Safe Storage of Application Secrets
===================================

By `Rick Anderson`_ and `Eilon Lipton`_

This tutorial shows how your application can securely store and access secrets. The most important point is you should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development and test mode.

In this article:
	- `Environment variables`_

Environment variables
^^^^^^^^^^^^^^^^^^^^^

`DNX <http://docs.asp.net/en/latest/dnx/overview.html>`_ reads environment variables, and if a key is found in a configuration file and the environment, the environment value takes precedence over the configuration file. The following code, taken from the *Startup.cs* file of a new ASP.NET MVC 6 web app, shows how to set up 

dnvm use default <-- necessary
For VS15 RC, you must edit C:\Users\<username>\.dnx\bin\packages\SecretManager\1.0.0-beta4\app\project.json and remove the "-10173" version from line containing  

``"SecretManager": "1.0.0-beta4-10173" ``

The completed markup is shown below:

{
  "version": "1.0.0-*",
  "description": "ASP.NET 5 tool to manage user secrets.",
  "dependencies": {
    "SecretManager": "1.0.0-beta4"
  },