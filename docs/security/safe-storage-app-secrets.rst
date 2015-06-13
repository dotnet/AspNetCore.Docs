Safe Storage of Application Secrets
===================================

By `Rick Anderson`_ and `Eilon Lipton`_

This tutorial shows how your application can securely store and access secrets. The most important point is you should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development and test mode.

In this article:
    - `Environment variables`_
    - `Installing the SecretManager`_

Environment variables
^^^^^^^^^^^^^^^^^^^^^

Your `Startup`` class should call `AddEnvironmentVariables` as the last configuration method so when 
`DNX <http://docs.asp.net/en/latest/dnx/overview.html>`_ reads environment variables, and a key is found in a configuration file and the environment, the environment value takes precedence over the configuration file.(See :doc:`../fundamentals/configuration`.) For example, if you create a new ASP.NET web site app with individual user accounts, it will add a default connection string to the *config.json* file. The ``Data:DefaultConnection:ConnectionString`` key value in the *config.json* file uses LocalDB, which runs in user mode and doesn't require a password. When you deploy your application to a test or production server, you can override ``Data:DefaultConnection:ConnectionString`` key value with an environment setting that connects to a test or production SQL Server. That key value would also contain a password to connect to the SQL Server.

Apps frequently require passwords, such as a client ID for OAuth. These passwords and other sensitive data should never be added to *config* files inside your projects source tree, as configuration files can be accidentally checked into source code. The SecretManager provides a  mechanism to store sensitive data for development work outside your project tree. The SecretManager is a DNX console application that is used to store secrets used by ASP.NET applications in the development environment.

Installing the SecretManager
^^^^^^^^^^^^^^^^^^^^^^^^^^^^

- Create a new ASP.NET web app. We will use this to test secrets stored with the SecretManager tool.
- Open a command prompt and navigate to the solution folder (the folder with *config.json*).
- Set the runtime version using the .Net version manager(DNVM). DNVM is a tool that lets you list, install and switch DNX versions on your machine. Run the following command:

.. code-block:: none

    dnvm use 1.0.0-beta4
    
- Install the SecretManager tool using DNU (Microsoft .NET Development Utility). DNU is used to build, package and publish DNX projects.
 
.. code-block:: none
 
    dnu commands install SecretManager
    
With Visual Studio 2015 RC, you will get the following error:

.. code-block:: none

    Unable to locate SecretManager >= 1.0.0-beta4-10173

To get around this error, we will remove the "-10173" version number. Open  *C:\\Users\\<username>\\.dnx\\bin\\packages\\SecretManager\\1.0.0-beta4\\app\\project.json* and find the following line:

 **"SecretManager": "1.0.0-beta4-10173"**

Remove  "-10173". The completed markup is shown below.

.. code-block:: json

		{
		  "version": "1.0.0-*",
		  "description": "ASP.NET 5 tool to manage user secrets.",
		  "dependencies": {
			"SecretManager": "1.0.0-beta4"
		  },
  
Save the file and run the dnu command again, it should successfully install and report "The following commands were installed: user-secret". Close the command window.

- Open a new command window and enter the following:

.. code-block:: none

dnvm use default

**dnvm** is the .NET Version Manager, a set of command line utilities that are used to update and configure .NET Runtime. The command ``dnvm use default`` instructs the .NET Version Manager to add the ASP.NET 5 runtime to the ``PATH`` environment variable for the current shell. For Visual Studio 2015 RC, the following is displayed: 

.. code-block:: none

	Adding C:\\Users\\<user>\\.dnx\\runtimes\\dnx-clr-win-x86.1.0.0-beta4\\bin to process PATH 
	
- Test the secrets manager by running the following command:

.. code-block:: none

	user-secret -h

The secrets manager will display usage, options and command help.


