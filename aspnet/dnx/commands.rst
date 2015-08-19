Using Commands
==============

DNX projects are used to build and run .NET applications for Windows, Mac and Linux. DNX provides a host process, CLR hosting logic and managed entry point discovery. You can use DNX to execute commands from a command prompt. 

What is a command?
------------------

A command is a named execution of a .NET entry point with specific arguments. The *project.json* file allows you to define commands for your projects. Those commands are understood by Visual Studio Code (VS Code) and they will show up in VS Code's **Command Palette**.

Using commands in your project
------------------------------

In the ``commands`` section of the below *project.json* example, four commands are listed:

.. code-block:: json

    {
      "version": "1.0.0",
      "webroot": "wwwroot",
      "exclude": [
        "wwwroot"
      ],
      "dependencies": {
        "Kestrel": "1.0.0-beta4",
        "Microsoft.AspNet.Diagnostics": "1.0.0-beta4",
        "Microsoft.AspNet.Hosting": "1.0.0-beta4",
        "Microsoft.AspNet.Server.IIS": "1.0.0-beta4",
        "Microsoft.AspNet.Server.WebListener": "1.0.0-beta4",
        "Microsoft.AspNet.StaticFiles": "1.0.0-beta4"
      },
      "commands": {
		"web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://localhost:5000",
		"kestrel": "Microsoft.AspNet.Hosting --server Kestrel --server.urls http://localhost:5001",
		"gen": "Microsoft.Framework.CodeGeneration",
		"ef": "EntityFramework.Commands"
      },
      "frameworks": {
        "dnx451": { },
        "dnxcore50": { }
      }
    }

The commands can include a set of arguments that will be passed to the DNX. In the above example, the first part of a command statement is an assembly with an entry point that the DNX will try to execute. Notice that in the ``commands`` section shown above, the ``ef`` assembly doesn't require any extra arguments, so all that is needed to define the command is the name of the assembly. For the ``kestrel`` command, there are three arguments. The first is the needed assembly, the second is the ``server`` agrument, and the third is the ``server.urls`` argument. The ``kestrel`` command will check the ``Microsoft.AspNet.Hosting`` assembly for an entry point, then it will pass the ``server`` and ``serveral.urls`` parameters to the entry point. 

.. note:: The assembly listed in the ``commands`` section should be pulled in by a package that your application depends on.

Installing and creating commands
--------------------------------

You can add additional commands to your project by modifying the *project.json* file. Additionally, you can use the DNU to install commands globally on a machine using the following syntax::

    dnu commands install MyCommand
	
For more details about installing commands, see `DNX Utility <https://github.com/aspnet/Home/wiki/DNX-utility>`_.	

Executing commands
------------------

To execute commands, you could run them from the command prompt, but a faster way when working with VS Code is to open the **Command Palette** (Ctrl+Shift+P), start typing the name of the command you want to run, and press **Enter**.

You can use DNX to execute the commands defined by your project by entering the following in the command prompt from your project's directory::

    dnx . kestrel

In VS Code, the same command would appear as follows::	

	dnx: kestrel - (SampleWebApp, Microsoft.AspNet.Hosting --server Kestrel --server.urls http://localhost:5001
	
.. note:: Command execution from the **Command Palette** doesn’t work yet on Linux. To run commands manually on Linux, start a console and type: dnx . <command_name>.

Additionally, you can run a set of standard DNX commands from the command prompt. For example::

	``dnx --appbase c:\myPath\myDirectory``

Building and publishing a command
---------------------------------
When you generate a console app using the console app template, it includes a *program.cs* file containing a ``Main`` entry point to the app. After you create a console app, you can build and run the app by issuing the following DNX command::

	dnx . run

In the console app, the *project.json* file contains the ``run`` command in the ``commands`` section. The ``dnx`` command is used to execute a managed entry point (a ``Program.Main`` function) in the assembly. When you issue the above ``dnx . run`` command, DNX finds the command included by the *project.json* file, then finds the ``Main`` entry point that you see in the *program.cs* file. 
	
For details about creating a console app with DNX, see :doc:`Creating a Cross-Platform Console App with DNX </dnx/console>`.
	
.. note:: The ``dnx . run`` command is a shorthand for executing the entry point in the current project. It is equivalent to ``dnx . [project_name]``. In addition, you can execute any of the commands listed in the *project.json* file from the command window::

	``dnx . (command)``
	
To publish commands from your *project.json* file, you can use the ``publish`` command from the DNX Utility. For more details about publishing commands, see `DNX Utility <https://github.com/aspnet/Home/wiki/DNX-utility>`_.

Default commands 
---------------- 

**Usage**: ``dnx --[options]``

**Options**:

+---------------------+--------------------------------------+---------------------------------------+
| Option              | Parameter                            | Details                               |
+=====================+======================================+=======================================+
| appbase             |  PATH                                |  Application base directory path.     |
+---------------------+--------------------------------------+---------------------------------------+
| lib                 |  LIB_PATHS                           |  Paths used for library look-up.      |
+---------------------+--------------------------------------+---------------------------------------+
| debug               |                                      |  Waits for the debugger to attach     | 
|                     |                                      |  before beginning execution.          |
+---------------------+--------------------------------------+---------------------------------------+
| help                |                                      |  Shows help information. Alternative  |
|                     |                                      |  options: -? and -h.                  |
+---------------------+--------------------------------------+---------------------------------------+
| version             |                                      |  Show version information.            |
+---------------------+--------------------------------------+---------------------------------------+
| watch               |                                      |  Watch file changes.                  |
+---------------------+--------------------------------------+---------------------------------------+
| packages            |  PACKAGE_DIR                         |  Directory containing packages.       |
+---------------------+--------------------------------------+---------------------------------------+
| configuration       |  CONFIGURATION                       |  The configuration to run under.      |
+---------------------+--------------------------------------+---------------------------------------+
| port                |  PORT                                |  The port to the compilation server.  |
+---------------------+--------------------------------------+---------------------------------------+
