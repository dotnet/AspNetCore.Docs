Using Gulp
==========

By `Erik Reitan`_  

Modern web development has lots of moving parts. To build a typical web app, you might:

-	Bundle and minify your JS  and CSS files.
-	Run tools to that call your bundling and minifying tasks before each build.
-	Compile LESS or SASS files to CSS.
-	Compile CoffeeScript or TypeScript files to JS.

A *task runner* is an app that automates these routine development tasks. Visual Studio 2015 provides built-in support for two popular JavaScript-based task runners, `Gulp <http://gulpjs.com>`__ and `Grunt <http://gruntjs.com/>`_. 

Bundling and Minification in Visual Studio using Gulp
-----------------------------------------------------
You may be familiar with *runtime* bundling and minification using ASP.NET Web Optimization. In ASP.NET 5, you can bundle and minify your client-side resources during *design-time*. Using design-time bundling and minification, you build your minified files up front and then deploy them with your app as static files. By bundling and minifying up front, you have the advantage of fewer moving parts and reduced server load. However, it's important to recognize that design-time bundling and minification increases build complexity and only work with static files.

Gulp is a JavaScript-based streaming build toolkit for client-side code. It is commonly used to stream client-side files through a series of processes when a specific event occurs in a build environment. The advantages of using gulp include automating common development processes, simplifying repetitive tasks, and speeding up overall development. For instance, you can use gulp to automate your minification processes or clean your development environment before a new build.

The ASP.NET 5 Web Application project template is used to help you get started designing and coding a new Web application in Visual Studio. It contains default functionality that demonstrates many aspects of ASP.NET. The template also includes the Node Package Manager (`npm <https://www.npmjs.com/>`_) and gulp by default, which makes it easy to add bundling and minification to a project.

.. note:: You don't need ASP.NET 5 Web Application project template or Visual Studio to implement bundling and minification. For instance, you can create an ASP.NET project using Yeoman, push it to GitHub, clone it on a Mac, and then bundle and minify the project.

When you create a new web project using ASP.NET 5 Web Application template, Visual Studio includes the `Gulp.js NuGet package <https://github.com/koistya/nuget-gulp>`_, the *gulpfile.js* file, and a set of gulp dependencies. The NuGet package contains all that is needed to install, run, update, and uninstall gulp for your Visual Studio project. The *gulpfile.js* file contains JavaScript that defines a set of gulp tasks that you can run using the **Task Runner Explorer** in Visual Studio. The ```devDependencies`` in the *package.json* file specifies the build tools to download. You can add new packages to ``devDependencies`` and save the file:

.. code-block:: javascript

	{
	  "name": "ASP.NET",
	  "version": "0.0.0",
	  "devDependencies": {
		"gulp": "3.8.11",
		"gulp-concat": "2.5.2",
		"gulp-cssmin": "0.1.7",
		"gulp-uglify": "1.2.0",
		"rimraf": "2.2.8"
	  }
	}

Visual Studio will download any packages you add. In **Solution Explorer** you can find the gulp packages in **Dependencies** > **NPM**. 

Gulp Default Tasks in Visual Studio
-----------------------------------
A default set of gulp tasks are defined in *gulpfile.js*. These tasks allow you to clean and minimize CSS and JavaScript files. The following JavaScript, from the first half of *gulpfile.js*, includes gulp modules and also specify file paths:

.. code-block:: javascript

	var gulp = require("gulp"),
		rimraf = require("rimraf"),
		concat = require("gulp-concat"),
		cssmin = require("gulp-cssmin"),
		uglify = require("gulp-uglify"),
		project = require("./project.json");

	var paths = {
		webroot: "./" + project.webroot + "/"
	};

	paths.js = paths.webroot + "js/**/*.js";
	paths.minJs = paths.webroot + "js/**/*.min.js";
	paths.css = paths.webroot + "css/**/*.css";
	paths.minCss = paths.webroot + "css/**/*.min.css";
	paths.concatJsDest = paths.webroot + "js/site.min.js";
	paths.concatCssDest = paths.webroot + "css/site.min.css";

The above code specifies which Node modules are required. The ``require`` function registers each module so that the related tasks can be run. Then, each module is assigned to a variable. These modules can be specified by their name or their path. You’ll see that the modules named ``gulp``, ``rimraf``, ``gulp-concat``, ``gulp-cssmin``, and ``gulp-uglify`` are specified using their name. The variable project is assigned based on the module at the path *./project.json*. Additionally, a series of paths are created so that the locations of CSS and JavaScript files can be referenced. The following table provides a list of modules and descriptions included in *gulpfile.js*.

=============  ===============================================================================================================================  
Module Name	   Description    
=============  ===============================================================================================================================  
gulp	       The gulp streaming build system. For more information, see `gulp <https://www.npmjs.com/package/gulp>`__.
rimraf	       A Node deletion module. For more information, see `rimraf <https://www.npmjs.com/package/rimraf>`_.
gulp-concat	   A module that will concatenate files based on your operating systems newline character. For more information, see `gulp-concat <https://www.npmjs.com/package/gulp-concat>`_.
gulp-cssmin	   A module that will minify CSS files. For more information see `gulp-cssmin <https://www.npmjs.com/package/gulp-cssmin>`_.
gulp-uglify	   A module that minifies *.js* files using the `UglifyJS <https://www.npmjs.com/package/gulp-cssmin>`_ toolkit. For more information, see `gulp-uglify <https://www.npmjs.com/package/gulp-uglify>`_. 
=============  =============================================================================================================================== 

Once modules are registered from *gulpfile.js*, the tasks are specified. Visual Studio 2015 registers six tasks based on the following code contained in *gulpfile.js*:

.. code-block:: javascript
	:emphasize-lines: 1,5,9,11,18,25

	gulp.task("clean:js", function (cb) {
		rimraf(paths.concatJsDest, cb);
	});

	gulp.task("clean:css", function (cb) {
		rimraf(paths.concatCssDest, cb);
	});

	gulp.task("clean", ["clean:js", "clean:css"]);

	gulp.task("min:js", function () {
		gulp.src([paths.js, "!" + paths.minJs], { base: "." })
			.pipe(concat(paths.concatJsDest))
			.pipe(uglify())
			.pipe(gulp.dest("."));
	});

	gulp.task("min:css", function () {
		gulp.src([paths.css, "!" + paths.minCss])
			.pipe(concat(paths.concatCssDest))
			.pipe(cssmin())
			.pipe(gulp.dest("."));
	});

	gulp.task("min", ["min:js", "min:css"]);

The following table gives an explanation of the tasks specified in the code above:

=============  ===============================================================================================================================  
Task Name	   Description    
=============  ===============================================================================================================================  
clean:js	   A task that uses the rimraf Node deletion module to remove unneeded files and directories files.
clean:css	   A task that uses the rimraf Node deletion module to remove unneeded files and directories files.
clean	       A task that calls both the ``clean:js`` and ``clean:css`` tasks.
min:js	       A task that minifies and concatenates *.js* files.
min:css	       A task that minifies and concatenates *.css* files.
min	           A task that calls both the ``min:js`` and ``min:css`` tasks.
=============  =============================================================================================================================== 

Running Default Tasks
---------------------

If you haven’t already created a new Web app, create a new ASP.NET Web Application project in Visual Studio 2015.

1.	Select **File** > **New** > **Project** from the menu bar. The **New Project** dialog box is displayed.

	.. image:: using-gulp/_static/01-NewProjectDB.png
	
2.	Select the **ASP.NET Web Application** template, choose a project name and click **OK**.
3.	In the **New ASP.NET Project** dialog box select the **Web Application** template from the **ASP.NET 5 Templates** and click **OK**.
4.	In **Solution Explorer**, right-click *gulpfile.js* and select **Task Runner Explorer**. 

	.. image:: using-gulp/_static/02-SolutionExplorer-TaskRunnerExplorer.png
	
	**Task Runner Explorer** shows the list of gulp tasks. In the default ASP.NET 5 Web Application template in Visual Studio 2015 there are six tasks included from *gulpfile.js*.

	.. image:: using-gulp/_static/03-TaskRunnerExplorer.png 

5.	Underneath **Tasks** in **Task Runner Explorer** right-click **clean** and select **Run** from the pop-up menu.

	.. image:: using-gulp/_static/04-TaskRunner-clean.png 

**Task Runner Explorer** will create a new tab named **clean** and execute the related clean task as it is defined in *gulpfile.js*.

6.	Next, right-click the **clean** task, then select **Bindings** > **Before Build**.

 	.. image:: using-gulp/_static/05-TaskRunner-BeforeBuild.png 

	The **Before Build** binding option will allow the clean task to be automatically run before each time you build your project.

Defining and Running a New Task
-------------------------------

To define a new gulp task, you must modify *gulpfile.js*.
 
1.	Add the following JavaScript to the end of *gulpfile.js*:

.. code-block:: javascript

	gulp.task("first", function () {
		console.log('first task! <-----');
	});
	
This task is named ``first`` and simply displays a string. 

2.	Save *gulpfile.js*.
3.	In **Solution Explorer**, right-click *gulpfile.js** and select *Task Runner Explorer*. 
4.	In **Task Runner Explorer**, right-click **first** and select **Run**.

	.. image:: using-gulp/_static/06-TaskRunner-First.png 

	You’ll see that the output text is displayed. If you are interested in examples based on a common scenario, see Gulp Recipes.

Defining and Running Tasks in a Series
--------------------------------------
When you run multiple tasks, the tasks run concurrently by default. However, if you need to run tasks in a specific order, you must specify when each task is complete, as well as which tasks depend on the completion of another task. 

1.	To define a series of tasks to run in order, replace the ``first`` task that you added above in *gulpfile.js* with the following:

.. code-block:: javascript

	gulp.task("series:first", function () {
		console.log('first task! <-----');
	});
	gulp.task("series:second", ["series:first"], function () {
		console.log('second task! <-----');
	});
	gulp.task("series", ["series:first", "series:second"], function () {});

	You now have three tasks: ``series:first``, ``series:second``, and ``series``. The ``series:second`` task includes a second parameter that specifies an array of tasks that must be run and completed before the ``series:second`` task will run.  As specified in the code above, only the ``series:first`` task must be completed before the ``series:second`` task will run.	

2.	Save *gulpfile.js*.
3.	In **Solution Explorer**, right-click *gulpfile.js* and select **Task Runner Explorer** if it isn’t already open. 
4.	In **Task Runner Explorer**, right-click **series** and select **Run**.

	.. image:: using-gulp/_static/07-TaskRunner-Series.png 
 
IntelliSense
------------
IntelliSense provides code completion, parameter info and other features to help you author code more productively and with fewer errors. Gulp tasks are written in JavaScript, therefore you can use IntelliSense to help code. As you work with JavaScript, IntelliSense lists the objects, functions, properties, and parameters that are available based on your current context. You can select a coding option from the pop-up list provided by IntelliSense to complete the code.

	.. image:: using-gulp/_static/08-IntelliSense.png 

	For more information about IntelliSense, see `JavaScript IntelliSense <https://msdn.microsoft.com/en-us/library/bb385682.aspx>`_.
	
Development, Staging, and Production Environments
-------------------------------------------------

When you use gulp to optimize your client-side files for staging and production, the processed files are saved to a local staging and production location. The *_Layout.cshtml* file uses the **environment** tag to provide two different versions of CSS files. One version of CSS files is for development and the other version is for both staging and production. In Visual Studio 2015, when you change the **ASPNET_ENV** environment variable to ``Production``, Visual Studio will build the Web app and link to the minimized CSS files. The following markup shows the **environment** tags containing link tags to the ``Development`` CSS files and the minimized ``Staging, Production`` CSS files.

.. code-block:: javascript

	<environment names="Development">
		<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
		<link rel="stylesheet" href="~/lib/bootstrap-touch-carousel/dist/css/bootstrap-touch-carousel.css" />
		<link rel="stylesheet" href="~/css/site.css" />
	</environment>
	<environment names="Staging,Production">
		<link rel="stylesheet" href="//ajax.aspnetcdn.com/ajax/bootstrap/3.0.0/css/bootstrap.min.css"
				asp-fallback-href="~/lib/bootstrap/css/bootstrap.min.css"
				asp-fallback-test-class="hidden" asp-fallback-test-property="visibility" asp-fallback-test-value="hidden" />
		<link rel="stylesheet" href="//ajax.aspnetcdn.com/ajax/bootstrap-touch-carousel/0.8.0/css/bootstrap-touch-carousel.css"
				asp-fallback-href="~/lib/bootstrap-touch-carousel/css/bootstrap-touch-carousel.css"
				asp-fallback-test-class="carousel-caption" asp-fallback-test-property="display" asp-fallback-test-value="none" />
		<link rel="stylesheet" href="~/css/site.min.css" asp-file-version="true" />
	</environment>
	
Switching Between Environments
------------------------------

To switch between compiling for different environments, you can change the ``ASPNET_ENV`` environment variable.

1.	In **Task Runner Explorer**, verify that the **min** task has been set to occur **Before Build**.
2.	In **Solution Explorer**, right-click the project name and select **Properties**.

	The property sheet for the Web app is displayed.
	
3.	Set the value of the **ASPNET_ENV** environment variable to ``Production``.
4.	Press **F5** to run the application in a browser.
5.	In the browser window, right-click the page and select **View Source** to see the html for the page.

	You will notice that the stylesheet links point to the minified CSS files.

6.	Close the browser to stop the Web app.
7.	In Visual Studio, return to the property sheet for the Web app and change the **ASPNET_ENV** environment variable back to ``Development``.
8.	Press **F5** to run the application in a browser again.
9.	In the browser window, right-click the page and select **View Source** to see the html for the page.

	You will notice that the stylesheet links point to the full version of the CSS files.
	
For more information related to Visual Studio 2015 environments, see `Working with Multiple Environments <http://docs.asp.net/en/latest/fundamentals/environments.html>`_.
	
Task and Module Details
-----------------------
A gulp task is registered with a function name.  You can specify dependencies if other tasks must run before the current task. Additional functions allow you to run and watch the gulp tasks, as well as set the source (src) and destination (dest) of the files that you are modifying. The following are the primary gulp functions:

===============  ==========================================  =================================================================================================================  
Gulp Function	 Syntax                                      Description
===============  ==========================================  =================================================================================================================  
task             ``gulp.task(name[, deps], fn) { }``         The ``task`` function is used to define a ``task``. The ``name`` parameters sets the name of the task. The ``deps`` parameter sets an array of tasks to be completed before this task runs. The ``fn`` parameter sets a function that performs the opterations of the task. 
run              ``gulp.run(tasks) { }``                     The ``run`` function runs one or more tasks.
watch            ``gulp.watch(glob [, opts], tasks) { }``    The ``watch`` function monitors files and runs tasks when a file change occurs. The ``glob`` parameter is a ``string`` or ``array`` that determines which files to watch. The ``opts`` parameter provides additional file watching options.
src  	         ``gulp.src(globs[, options]) { }``          The ``src`` function provides files that match the ``glob`` value(s). The ``glob`` parameter is a ``string`` or ``array`` that determines which files to read. The ``options`` parameter provides additional file options.
dest             ``gulp.dest(path[, options]) { }``          The ``dest`` function provides a destination of where files can be written. The ``path`` parameter is a string or function that determines the destination folder. The ``options`` parameter is an object that specifies output folder options.
===============  ==========================================  =================================================================================================================  

For additional gulp API reference information, see `Gulp Docs API <https://github.com/gulpjs/gulp/blob/master/docs/API.md>`_. 

Gulp Recipes
------------
The gulp community provides gulp `recipes <https://github.com/gulpjs/gulp/blob/master/docs/recipes/README.md>`_. These recipes are common scenarios to accomplish gulp tasks. 

Summary
-------
Gulp is a JavaScript-based streaming build toolkit that can be used for bundling and minification. Visual Studio 2015 automatically installs gulp along with a set of gulp tasks. Gulp is maintained on `GitHub <https://github.com/gulpjs/gulp>`_. For additional information about gulp, see the `Gulp Documentation <https://github.com/gulpjs/gulp/blob/master/docs/README.md>`_ on GitHub.

See Also
--------

	- :doc:`bundling-and-minification`
	- :doc:`using-grunt`