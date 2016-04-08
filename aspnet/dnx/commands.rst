Using Commands
==============

DNX projects are used to build and run .NET applications for Windows, Mac and Linux. DNX provides a host process, CLR hosting logic and managed entry point discovery. You can use DNX to execute commands from a command prompt. 

What is a command?
------------------

A command is a named execution of a .NET entry point with specific arguments. Commands can be defined locally in your project or installed globally on your machine. The *project.json* file in your project allows you to define commands for your project. Commands that you define for your projects are understood by Visual Studio Code (VS Code) as well as Visual Studio. Global commands, which are not project specific, can be installed on a machine and run from a command prompt.

Using commands in your project
------------------------------

In the ``commands`` section of the below *project.json* example, four commands are listed:

.. code-block:: json

    {
      "webroot": "wwwroot",
      "version": "1.0.0-*",

      "dependencies": {
        "Kestrel": "1.0.0-beta7",
        "Microsoft.AspNet.Diagnostics": "1.0.0-beta7",
        "Microsoft.AspNet.Hosting": "1.0.0-beta7",
        "Microsoft.AspNet.Server.IIS": "1.0.0-beta7",
        "Microsoft.AspNet.Server.WebListener": "1.0.0-beta7",
        "Microsoft.AspNet.StaticFiles": "1.0.0-beta7"
      },
      "commands": {
        "web": "Microsoft.AspNet.Hosting --config hosting.ini",
        "kestrel": "Microsoft.AspNet.Hosting --config hosting.ini",
        "gen": "Microsoft.Framework.CodeGeneration",
        "ef": "EntityFramework.Commands"
      },
      "frameworks": {
        "dnx451": { },
        "dnxcore50": { }
      }
    }

A command can include a set of arguments that will be passed to the DNX. In the above example, the first part of a command statement is an assembly with an entry point that the DNX will try to execute. Notice that in the ``commands`` section shown above, the ``ef`` command is implemented by the ``EntityFramework.Commands`` assembly. This command doesn't require any extra argument, all that is needed to define the command is the name of the assembly. For the ``web`` command and the ``kestrel`` command, the arguments are contained in the referenced *hosting.ini* file. In the *hosting.ini* file you will see the ``server`` agrument and the the ``server.urls`` argument. The ``kestrel`` command, as well as the ``web`` command, will check the ``Microsoft.AspNet.Hosting`` assembly for an entry point, then it will pass the ``server`` and ``server.urls`` arguments to the entry point. Specifically, the arguments for each command are passed to the entry point throught the ``args`` argument of the ``main`` method.

.. note:: The assembly listed in the ``commands`` section should be pulled in by a package that your application depends on.

You can add a command package and its dependencies to your project using the `Package Manager Console <http://docs.nuget.org/consume/package-manager-console>`_. For example, to install the `SecretManager <http://www.nuget.org/packages/Microsoft.Framework.SecretManager>`_ package from the **Package Manager Console**, enter the following::

	Install-Package Microsoft.Framework.SecretManager -Pre
	
.. note:: The global *NuGet.config* file is used to find the correct NuGet feed when installing global command NuGet packages. Use ``Install-Package -?`` from the **Package Manager Console** to view help information related to the ``Install-Package`` command. 

Running commands using dnx.exe
------------------------------

You can use DNX to run the commands defined by your project by entering the following in the command prompt from your project's directory::

	dnx [command]

You can also run commands from VS Code or Visual Studio. From VS Code, open the **Command Palette** (Ctrl+Shift+P) and enter the name of the command you want to run. From Visual Studio, open the **Command Window** (Ctrl+Alt+A) and enter the name of the command you want to run.
	
For example, the following command is used to run a web application using the Kestrel web server::

    dnx kestrel

To run a console app, you can use the following command::

	dnx run
	
.. note:: Note that running a command is short-hand for specifying the command assembly and it's arguments directly to DNX. For example, ``dnx web`` is a short-hand alias for ``dnx Microsoft.AspNet.Hosting hosting.ini``, where the *hosting.ini* file contains the command parameters. 

Global commands
---------------
Global commands are DNX console applications (in a NuGet package) that are installed globally and runnable from your command line. The difference between global commands and commands that you add in the ``commands`` section of the *project.json* file of a project is that global commands are made available to everything that runs under a user profile. You can install, run, uninstall, build, and publish global commands. 

The ``dnu commands install`` command will use the NuGet sources contained in the local XML *NuGet.Config* file to determine where it looks for NuGet packages. The main sections for this file are ``packageRestore``, ``packageSources``, ``disabledPackageSources``, and ``activePackageSource``.

Installing global commands
^^^^^^^^^^^^^^^^^^^^^^^^^^

To add a global command (and package), you can use the .NET Development Utility (DNU) to download a NuGet package and install it.

For example, enter the following from the command prompt::

	dnu commands install Microsoft.Framework.SecretManager
	
.. note:: You can use the ``--overwrite`` option to overwrite conflicting commands. Use ``dnu commands install -?`` from the command prompt to view help information related to the ``install`` command.

Running global commands
^^^^^^^^^^^^^^^^^^^^^^^

You can run global commands from the command prompt after installing the related package. For example, if you have installed the SecretManager and have set the user secret for the application, from the application directory you can issue the following command to retrive all of the user secrets for your application::

	user-secret list
	
.. note:: To see a list of the available DNX runtimes, including the **active** DNX runtime, you can enter ``dnvm list`` from the command prompt. If you need to change the active DNX runtime, use ``dnvm use [version] -p``. For example, ``dnvm use 1.0.0-beta7 –p``. Global commands always run with the active DNX runtime. 
	
Uninstalling global commands
^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To uninstall global commands you can use the following DNU command::

	dnu commands uninstall [arguments] [options]
	
The [arguments] is the name of the command to uninstall. For example::

	dnu commands uninstall user-secret
	
For additional details about the uninstall command, enter ``dnu commands uninstall -?`` from the command prompt.	

Built-in global commands
^^^^^^^^^^^^^^^^^^^^^^^^

The following built-in global commands are available: 

	1. user-secret
	2. sqlservercache

These commands have specific NuGet packages that are installed. When you install a global command, the related NuGet package is also installed. 

Building and publishing global command
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You can use the .NET Development Utility (DNU) to build, package and publish a global command. A global command is contained as a console app project. Building a project produces the binary outputs for the project. Packaging produces a NuGet package that can be uploaded to a package feed (such as http://nuget.org)) and then consumed. Publishing collects all required runtime artifacts (the required DNX and packages) into a single folder so that it can be deployed as an application.

When you generate a console app using the console app template, it includes a *program.cs* file containing a ``Main`` entry point to the app. After you create a console app, you can build and run the app by issuing the following DNX command::

	dnx run

In the console app, the *project.json* file contains the ``run`` command in the ``commands`` section. The ``dnx`` command is used to execute a managed entry point (a ``Program.Main`` function) in the assembly. When you issue the above ``dnx run`` command, DNX finds the command based on the name used for the project, then finds the ``Main`` entry point that you see in the *program.cs* file. 
	
For details about creating a console app with DNX, see :doc:`Creating a Cross-Platform Console App with DNX </dnx/console>`.
	
.. note:: The ``dnx run`` command is a shorthand for executing the entry point in the current project. It is equivalent to ``dnx [project_name]``. 

When you are ready to build your console app containing your global command, use the following command to produce assemblies for the project in the given directory::

	dnu build
	
Once the console app has been built, you can package it using the following command to create NuGet packages for the project in the given directory::

	dnu pack
	
To publish the NuGet packages you can use the following command::

	dnu publish
	
The ``publish`` command will package your application into a self-contained directory that can be launched. It will create the following directory structure:

	- output/
	- output/packages
	- output/appName
	- output/commandName.cmd

The packages directory contains all the packages your command needs to run. The *appName* directory will contain all of your applications code. If you have project references, they will appear as their own directory with code at this level as well. 

There are 3 commands that are skipped for global install, those are ``run``, ``test`` and ``web``. You can build a NuGet package with those commands, but they cannot be installed globally. So, for the default console application template, you must rename the ``run`` command to something else, such as ``my-cmd``, if you want to make the command globally installable.

Also, the following command names cannot be used: ``dnx``, ``dnvm``, ``nuget``, ``dnu``. You will get a build error if you use those names.

Global commands details
-----------------------

Global commands are DNX console applications (in a NuGet package) that are installed globally and runnable from your command line. 
	
.. note:: If you are using Visual Studio, then  both ``SecretManager`` and ``SqlConfig`` should already be installed for you. If you not using Visual Studio, first install the DNX, then run ``dnu commands install [namespace.command]``. When a command is finished installing, the output will specifically show the name of the commands that have been installed.

SecretManager
^^^^^^^^^^^^^
This ASP.NET package contains commands to manage application secrets. When developing modern web applications developers often want to leverage authentication systems such as OAuth. One of the defining features of these authentication schemes is shared secrets that your application and the authenticating server must know. 

**Assembly**: ``Microsoft.Framework``
 
**Usage**: ``user-secret [command] [options]``
 
**Options**:
 
+---------------------+-----------------------------------------------+
| Option              | Description                                   |
+=====================+===============================================+
| -?|-h|--help        | Show help information.                        |
+---------------------+-----------------------------------------------+
| -v|--verbose        | Verbose output.                               |
+---------------------+-----------------------------------------------+
 
**Commands**:
 
+---------------------+-----------------------------------------------+
| Command             | Description                                   |
+=====================+===============================================+
| set                 | Sets the user secret to the specified value.  |
+---------------------+-----------------------------------------------+
| help                | Show help information.                        |
+---------------------+-----------------------------------------------+
| remove              | Removes the specified user secret.            |
+---------------------+-----------------------------------------------+
| list                | Lists all the application secrets.            |
+---------------------+-----------------------------------------------+
| clear               | Deletes all the application secrets.          |
+---------------------+-----------------------------------------------+

.. note:: For more information about a command, use ``user-secret [command] --help`` from the command prompt.

SqlConfig
^^^^^^^^^
The ``Microsoft.Framework.Caching.SqlConfig`` package contains commands for creating table and indexes in Microsoft SQL Server database to be used for ASP.NET 5 distributed caching. 

**Assembly**: ``Microsoft.Framework.Caching`` 

**Usage**: ``sqlservercache [options] [command]``

+---------------------+-----------------------------------------------+
| Option              | Description                                   |
+=====================+===============================================+
| -?|-h|--help        | Show help information.                        |
+---------------------+-----------------------------------------------+
| -v|--verbose        | Verbose output.                               |
+---------------------+-----------------------------------------------+
 
**Commands**:
 
+---------------------+-----------------------------------------------+
| Command             | Description                                   |
+=====================+===============================================+
| set                 | Sets the user secret to the specified value.  |
+---------------------+-----------------------------------------------+
| help                | Show help information.                        |
+---------------------+-----------------------------------------------+
| remove              | Removes the specified user secret.            |
+---------------------+-----------------------------------------------+
| list                | Lists all the application secrets.            |
+---------------------+-----------------------------------------------+
| clear               | Deletes all the application secrets.          |
+---------------------+-----------------------------------------------+

.. note:: For more information about a command, use ``user-secret [command] --help`` from the command prompt.
