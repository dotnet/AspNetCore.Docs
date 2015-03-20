ASP.NET Docs
============

This project is part of ASP.NET 5. You can find samples, documentation and getting started instructions for ASP.NET 5 at the [Home](https://github.com/aspnet/home) repo.

This repo contains documentation for ASP.NET 5. The documentation is built using [Sphinx](http://sphinx-doc.org) and [reStructuredText](http://sphinx-doc.org/rest.html), and then hosted by [ReadTheDocs](http://aspnet.readthedocs.org).

## Building the Docs ##

To build the docs, you will need to install [python](https://www.python.org/downloads/) (version 2 or higher). If you are running Windows, you will want to add the Python install folder and the \Scripts\ folder to your PATH environment variable.

To install Sphinx, open a command prompt and run:

	pip install sphinx

This project is also using a custom theme from ReadTheDocs, which you can install with:

	pip install sphinx_rtd_theme

You should now be able to navigate to the docs folder and run

	make html

which should generate the documentation in the _build folder. Open the _build/html/index.html file to view the generated documentation.

You can also install sphinx-autobuild which will run a local webserver and automatically refresh whenever changes to docs files are detected. To do so, first install sphinx-autobuild:

	pip install sphinx-autobuild

Then run it from the root of the project with

	sphinx-autobuild docs docs/_build/html

Note that you may need to run 'make html' once before sphinx-autobuild will serve the docs correctly.

If contributing new documentation content, please review the [Sphinx Style Guide](http://documentation-style-guide-sphinx.readthedocs.org/en/latest/style-guide.html).

## Adding Content ##

In addition to the style guide, articles should be organized into logical groups or sections. Each section should be given a named folder (e.g. /yourfirst). Within each section, each article should also have its own folder, within which the article.rst file resides. Images and other static resources (code samples, etc.) should be placed in a _static folder within the article folder.

### Example Structure ###

	docs
		/yourfirst
			/fundamentalconcepts
				/_static
					about-page.png
					add-config.png
					...
				fundamentalconcepts.rst
			/yourfirstaspnetapplication
				/_static
					about-page.png
					add-api-controller.png
					...
				yourfirstaspnetapplication.rst

Author information should be placed in the _authors folder following the example of steve-smith.rst. Place photos in the photos folder - size them to be no more than 125px wide or tall.