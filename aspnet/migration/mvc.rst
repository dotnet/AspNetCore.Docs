Migrating From ASP.NET MVC to ASP.NET Core MVC
================================================

By `Rick Anderson`_, `Daniel Roth`_, `Steve Smith`_ and `Scott Addie`_ 

This article shows how to get started migrating an ASP.NET MVC project to :doc:`ASP.NET Core MVC </mvc/index>`. In the process, it highlights many of the things that have changed from ASP.NET MVC. Migrating from ASP.NET MVC is a multiple step process and this article covers the initial setup, basic controllers and views, static content, and client-side dependencies. Additional articles cover migrating configuration and identity code found in many ASP.NET MVC projects.

.. contents:: Sections:
  :local:
  :depth: 1

Create the starter ASP.NET MVC project
---------------------------------------

To demonstrate the upgrade, we'll start by creating a new ASP.NET MVC app. Create it with the name *WebApp1* so the namespace will match the ASP.NET Core project we create in the next step.

.. image:: mvc/_static/new-project.png

.. image:: mvc/_static/new-project-select-mvc-template.png

*Optional:* Change the name of the Solution from *WebApp1* to *Mvc5*. Visual Studio will display the new solution name (*Mvc5*), which will make it easier to tell this project from the next project. You might need to exit Visual Studio and then reload the project to see the new name.

Create the ASP.NET Core project
-----------------------------------

Create a new *empty* ASP.NET Core web app with the same name as the previous project (*WebApp1*) so the namespaces in the two projects match. Having the same namespace makes it easier to copy code between the two projects. You'll have to create this project in a different directory than the previous project to use the same name.

.. image:: mvc/_static/new-project-select-empty-aspnet5-template.png

- *Optional:* Create a new ASP.NET Core app named *WebApp1* with authentication set to **Individual User Accounts**. Rename this app *FullAspNetCore*.  Creating this project will save you time in the conversion. You can look at the template generated code to see the end result or to copy code to the conversion project. It's also helpful when you get stuck on a conversion step to compare with the template generated project.

Configure the site to use MVC
-----------------------------

- Open the *project.json* file and add ``Microsoft.AspNet.Mvc`` and ``Microsoft.AspNet.StaticFiles`` to the ``dependencies`` property and the ``scripts`` section as highlighted below:

.. literalinclude:: mvc/samples/WebApp1/src/WebApp1/project.json
  :language: json
  :emphasize-lines: 8-9, 30-33
  :linenos:
  
``Microsoft.AspNet.StaticFiles`` is the static file handler. The ASP.NET runtime is modular, and you must explicitly opt in to serve static files (see :doc:`/fundamentals/static-files`).

The ``scripts`` section is used to denote when specified build automation scripts should run. Visual Studio now has built-in support for running scripts before and after specific events. The ``scripts`` section above specifies `NPM <https://docs.npmjs.com/>`__, `Bower <http://bower.io/>`__ and `Gulp <http://gulpjs.com/>`__ scripts should run on the ``prepublish`` stage.  We'll talk about NPM, Bower, and Gulp later in the tutorial. Note the trailing "," added to the end of the ``publishExclude`` section.

- Open the *Startup.cs* file and change the code to match the following:

.. literalinclude:: mvc/samples/WebApp1/src/WebApp1/Startup.cs
  :language: c#
  :emphasize-lines: 7, 14-
  :linenos:  
  :lines: 11-34
  :dedent: 4

``UseStaticFiles`` adds the static file handler. As mentioned previously, the ASP.NET runtime is modular, and you must explicitly opt in to serve static files. For more information, see :doc:`/fundamentals/startup` and :doc:`/fundamentals/routing`.

Add a controller and view
-------------------------

In this section, you'll add a minimal controller and view to serve as placeholders for the ASP.NET MVC controller and views you'll migrate in the next section.

- Add a *Controllers* folder.
- Add an **MVC controller class** with the name *HomeController.cs* to the *Controllers* folder.

.. image:: mvc/_static/add_mvc_ctl.png

- Add a *Views* folder. 
- Add a *Views/Home* folder.
- Add an *Index.cshtml* MVC view page to the *Views/Home* folder. 

.. image:: mvc/_static/view.png

The project structure is shown below:

.. image:: mvc/_static/project-structure-controller-view.png

Replace the contents of the *Views/Home/Index.cshtml* file with the following:

.. code-block:: html

  <h1>Hello world!</h1>

Run the app.

.. image:: mvc/_static/hello-world.png

See :doc:`/mvc/controllers/index` and :doc:`/mvc/views/index` for more information.

Now that we have a minimal working ASP.NET Core project, we can start migrating functionality from the ASP.NET MVC project. We will need to move the following:

- client-side content (CSS, fonts, and scripts)
- controllers
- views
- models
- bundling 
- filters
- Log in/out, identity (This will be done in the next tutorial.)

Controllers and views
---------------------

- Copy each of the methods from the ASP.NET MVC ``HomeController`` to the new ``HomeController``. Note that in ASP.NET MVC, the built-in template's controller action method return type is `ActionResult <https://msdn.microsoft.com/en-us/library/system.web.mvc.actionresult(v=vs.118).aspx>`__; in ASP.NET Core MVC the actions return `IActionResult <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Mvc/IActionResult/index.html>`__ instead. ``ActionResult`` implements ``IActionResult``, so there is no need to change the return type of your action methods.
- Copy the *About.cshtml*, *Contact.cshtml*, and *Index.cshtml* Razor view files from the ASP.NET MVC project to the ASP.NET Core project. 
- Run the ASP.NET Core app and test each method. We haven't migrated the layout file or styles yet, so the rendered views will only contain the content in the view files. You won't have the layout file generated links for the ``About`` and ``Contact`` views, so you'll have to invoke them from the browser (replace **2468** with the port number used in your project).

  - http://localhost:2468/home/about
  - http://localhost:2468/home/contact

.. image:: mvc/_static/contact-page.png

Note the lack of styling and menu items. We'll fix that in the next section.

Static content
--------------

In previous versions of MVC (including ASP.NET MVC), static content was hosted from the root of the web project and was intermixed with server-side files. In ASP.NET Core, static content is hosted in the *wwwroot* folder. You'll want to copy the static content from your ASP.NET MVC app to the *wwwroot* folder in your ASP.NET Core project. In this sample conversion:

- Copy the *favicon.ico* file from the ASP.NET MVC project to the *wwwroot* folder in the ASP.NET Core project.

The ASP.NET MVC project uses `Bootstrap <http://getbootstrap.com/>`__ for its styling and stores the Bootstrap files in the *Content* and *Scripts* folders. The template-generated ASP.NET MVC project references Bootstrap in the layout file (*Views/Shared/_Layout.cshtml*). You could copy the *bootstrap.js* and *bootstrap.css* files from the ASP.NET MVC project to the *wwwroot* folder in the new project, but that approach doesn't use the improved mechanism for managing client-side dependencies in ASP.NET Core.

In the new project, we'll add support for Bootstrap (and other client-side libraries) using `Bower <http://bower.io/>`__: 

- Add a `Bower <http://bower.io/>`__ configuration file named *bower.json* to the project root (Right-click on the project, and then **Add > New Item > Bower Configuration File**). Add `Bootstrap <http://getbootstrap.com/>`__ and jquery to the file (see the highlighted lines below).

.. literalinclude:: mvc/samples/WebApp1/src/WebApp1/bower.json
  :language: json
  :emphasize-lines: 5-6

Upon saving the file, Bower will automatically download the dependencies to the *wwwroot/lib* folder. You can use the **Search Solution Explorer** box to find the path of the assets.

.. image:: mvc/_static/search.png

See :doc:`/client-side/bower` for more information.

Gulp
----

When you create a new web app using the ASP.NET Core Web Application template, the project is setup to use `Gulp <http://gulpjs.com>`__. Gulp is a streaming build system for client-side code (HTML, LESS, SASS, etc.). The included *gulpfile.js* in the project contains JavaScript that defines a set of gulp tasks that you can set to run automatically on build events or you can run manually using the **Task Runner Explorer** in Visual Studio. In this section, we'll show how to use the generated *gulpfile.js* file to bundle and minify the JavaScript and CSS files in the project. 

If you created the optional *FullAspNetCore* project (a new ASP.NET Core web app with Individual User Accounts), add *gulpfile.js* from that project to the project we are updating. In Solution Explorer, right-click the web app project and choose **Add > Existing Item**. 

.. image:: mvc/_static/addExisting.png

Navigate to *gulpfile.js* from the new ASP.NET Core web app with Individual User Accounts and add the add *gulpfile.js* file. Alternatively, right-click the web app project and choose **Add > New Item**. Select **Gulp Configuration File**, and name the file *gulpfile.js*. Replace the contents of the gulp file with the following:

.. literalinclude:: mvc/samples/WebApp1/src/WebApp1/gulpfile.js
  :language: javascript

The code above performs these functions:

- Cleans (deletes) the target files.
- Minifies the JavaScript and CSS files.
- Bundles (concatenates) the JavaScript and CSS files.

See :doc:`/client-side/using-gulp`.

NPM
---

`NPM <https://docs.npmjs.com/>`__ (Node Package Manager) is a package manager which is used to acquire tooling such as `Bower <http://bower.io/>`__ and `Gulp <http://gulpjs.com/>`__; and, it is fully supported in Visual Studio. We'll use NPM to manage Gulp dependencies.

If you created the optional *FullAspNetCore* project, add the *package.json* NPM file from that project to the project we are updating. The *package.json* NPM file lists the dependencies for the client-side build processes defined in `gulpfile.js`. Right-click the web app project, choose **Add > Existing Item**, and add the *package.json* NPM file. Alternatively, you can add a new NPM configuration file as follows:

1. In Solution Explorer, right-click the project.

#. Select **Add** > **New Item**.

#. Select **NPM Configuration File**.

#. Leave the default name: *package.json*.

#. Click **Add**.

Open the *package.json* file, and replace the contents with the following:

.. literalinclude:: mvc/samples/WebApp1/src/WebApp1/package.json
  :language: json

Right-click on *gulpfile.js* and select **Task Runner Explorer**. Double-click on a task to run it.

For more information, see :doc:`/client-side/index`.

.. _migrate-layout-file:

Migrate the layout file
-----------------------

- Copy the *_ViewStart.cshtml* file from the ASP.NET MVC project's *Views* folder into the ASP.NET Core project's *Views* folder. The *_ViewStart.cshtml* file has not changed in ASP.NET Core MVC. 
- Create a *Views/Shared* folder. 
- Copy the *_Layout.cshtml* file from the ASP.NET MVC project's *Views/Shared* folder into the ASP.NET Core project's *Views/Shared* folder. 

 Open *_Layout.cshtml* file and make the following changes (the completed code is shown below):

  - Replace @Styles.Render("~/Content/css") with a <link> element to load *bootstrap.css* (see below)
  - Remove @Scripts.Render("~/bundles/modernizr")
  - Comment out the @Html.Partial("_LoginPartial") line (surround the line with @*...*@) - we'll return to it in a future tutorial 
  - Replace @Scripts.Render("~/bundles/jquery") with a <script> element (see below)
  - Replace @Scripts.Render("~/bundles/bootstrap") with a <script> element (see below)

The replacement CSS link:

.. code-block:: html

  <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />

The replacement script tags:

.. code-block:: html

  <script src="~/lib/jquery/dist/jquery.js"></script>
  <script src="~/lib/bootstrap/dist/js/bootstrap.js"></script>

The updated _Layout.cshtml file is shown below:

.. literalinclude:: mvc/samples/WebApp1/src/WebApp1/Views/Shared/_Layout.cshtml
  :language: html
  :emphasize-lines: 7,26,38-39

View the site in the browser. It should now load correctly, with the expected styles in place.

Configure Bundling
------------------

The ASP.NET MVC starter web template utilized the ASP.NET Web Optimization for bundling. In ASP.NET Core, this functionality is performed as part of the build process using `Gulp <http://gulpjs.com/>`__. We've previously configured bundling and minification; all that's left is to change the references to Bootstrap, jQuery and other assets to use the bundled and minified versions. You can see how this is done in the layout file (*Views/Shared/_Layout.cshtml*) of the full template project. See :doc:`/client-side/bundling-and-minification` for more information.

Additional Resources
--------------------

- :doc:`/client-side/index`
