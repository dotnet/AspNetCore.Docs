Building Projects with Yeoman
=============================
By `Scott Addie`_, `Rick Anderson`_ and `Noel Rice`_

`Yeoman <http://yeoman.io/>`_ generates complete projects for a given set of client tools. Yeoman is an open-source tool that works like a Visual Studio project template. The Yeoman command line tool `yo <https://github.com/yeoman/yo>`__ works alongside a Yeoman generator. Generators define the technologies that go into a project. 

.. contents:: Sections:
  :local:
  :depth: 1

Install Node.js, npm, and Yeoman
------------------------------------

- Install `Node.js <https://nodejs.org/en/>`__. The installer includes `Node.js <https://nodejs.org/en/>`__ and `npm <https://www.npmjs.com/>`__.
 
- Follow the instructions on http://yeoman.io/learning/ to install `yo <https://github.com/yeoman/yo>`__, bower, grunt, and gulp.

  - ``npm install -g yo bower grunt-cli gulp``
    
.. note:: If you get the error ``npm ERR! Please try running this command again as root/Administrator.``, run the following command using `sudo <https://developer.apple.com/library/mac/documentation/Darwin/Reference/ManPages/man8/sudo.8.html>`__: ``sudo npm install -g yo bower grunt-cli gulp``

- From the command line, install the ASP.NET generator: 

.. code-block:: console

  npm install -g generator-aspnet
 
.. note:: If you get a permission error, run the command under ``sudo`` as described above.

-  The ``–g`` flag installs the generator globally, so that it can be used from any path.

Create an ASP.NET app
-------------------------
 
- Create a directory for the project

.. code-block:: console

  mkdir C:\MyYo
  cd C:\MyYo

- Run the ASP.NET generator for ``yo``

.. code-block:: console 

  yo aspnet
 
- The generator displays a menu. Arrow down to the **Web Application** project and tap **Enter**:

.. image:: yeoman/_static/yeoman-yo-aspnet.png

- Use "MyWebApp" for the app name and then tap **Enter** :

  .. image:: yeoman/_static/yeoman-yo-aspnet-appname.png

Yeoman will scaffold the project and its supporting files. Suggested next steps are also provided in the form of commands. 

  .. image:: yeoman/_static/yeoman-yo-aspnet-created.png

The `ASP.NET generator <https://www.npmjs.com/package/generator-aspnet>`__ creates ASP.NET 5 DNX projects that can be loaded into Visual Studio 2015 or run from the command line. 

If you were redirected to this tutorial from :doc:`/tutorials/your-first-mac-aspnet`, you can return now.

Setting Grunt as the task runner
---------------------------------

:doc:`Grunt </client-side/using-grunt>`
:doc:`Gulp </client-side/using-gulp>`

The ASP.NET 5 Yeoman generator (``generator-aspnet``) uses Gulp out-of-the box. This is consistent with how the default ASP.NET web project template works in Visual Studio 2015. 

The `ASP.NET generator <https://www.npmjs.com/package/generator-aspnet>`_ creates supporting files to configure client-side build tools. A :doc:`Grunt </client-side/using-grunt>` or :doc:`Gulp </client-side/using-gulp>` task runner file is added to your project to automate build tasks for Web projects. The default generator creates *gulpfile.js* to run tasks. Running the generator with the ``--grunt`` argument generates *Gruntfile.js*:

.. code-block:: console 

  yo aspnet --grunt
 
The generator also configures *package.json* to load :doc:`Grunt </client-side/using-grunt>` or :doc:`Gulp </client-side/using-gulp>` dependencies. It also adds *bower.json* and *.bowerrc* files to restore client-side packages using the `Bower client-side package manager <http://docs.asp.net/en/latest/client-side/bower.html>`_. 

Building and Running from Visual Studio
---------------------------------------

You can load your generated ASP.NET 5 web project directly into Visual Studio 2015, then build and run your project from there.

1. Open Visual Studio 2015. From the File menu, select :menuselection:`Open --> Project/Solution`.

2. In the Open Project dialog, navigate to the ``project.json`` file, select it, and click the **Open** button. In the Solution Explorer, the project should look something like the screenshot below.

  .. image:: yeoman/_static/yeoman-solution.png
 
.. note:: Yeoman scaffolds a MVC web application, complete with both server- and client-side build support. Server-side dependencies are listed under the **References** node, and client-side dependencies in the **Dependencies** node of Solution Explorer. Dependencies are restored automatically when the project is loaded.

  .. image:: yeoman/_static/yeoman-loading-dependencies.png 

3. When all the dependencies are restored, press **F5** to run the project. The default home page displays in the browser.
 
  .. image:: yeoman/_static/yeoman-home-page.png 

Restoring, Building, and Hosting from the Command Line
------------------------------------------------------

You can prepare and host your web application using commands **dnu** (Microsoft .NET Development Utility) and **dnx** (Micorosft .NET Execution Environment). 

.. note:: For more information on DNX, see :doc:`/dnx/overview` 

1. From the command line, change the current directory to the folder containing the project (that is, the folder containing the `project.json` file):

.. code-block:: console

  cd C:\MyYo\MyWebApp 
 
2. From the command line, restore the project's NuGet package dependencies: 

.. code-block:: console

  dnu restore

3. Also from the command line, build the project assemblies: 

.. code-block:: console

  dnu build

4. To run the development web server, use this **dnx** command:

.. code-block:: console

  dnx web

This will execute the corresponding ``web`` command in the ``commands`` section of the project.json file:

.. code-block:: json
  :linenos:
  :emphasize-lines: 2

  "commands": {
    "web": "Microsoft.AspNet.Server.Kestrel",
    "ef": "EntityFramework.Commands"
  },

The cross-platform `Kestrel <https://docs.asp.net/en/latest/fundamentals/servers.html#kestrel>`__ web server will begin listening on port 5000:

.. image:: yeoman/_static/yeoman-web-server-started.png

5. Open a web browser, and navigate to http://localhost:5000. 

  .. image:: yeoman/_static/yeoman-home-page_5000.png 

Adding to Your Project with Sub Generators
------------------------------------------
You can add new generated files using Yeoman even after the project is created. Use `sub generators <https://www.npmjs.com/package/generator-aspnet#sub-generators>`_ to add any of the file types that make up your project. For example, to add a new class to your project, enter the ``yo aspnet:Class`` command followed by the name of the class. Execute the following command from the directory in which the file should be created: 

.. code-block:: console

  yo aspnet:Class Person

The result is a file named Person.cs with a class named ``Person``:

.. code-block:: c#

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  namespace MyNamespace
  {
      public class Person
      {
          public Person()
          {
          }
      }
  }
 
Related Resources
-----------------

- :doc:`Servers (HttpPlatformHandler, Kestrel and WebListener) </fundamentals/servers>`
- :doc:`/tutorials/your-first-mac-aspnet`
- :doc:`/fundamentals/index` 
