Contributing
======

Information on contributing to this repo is in the [Contributing Guide](https://github.com/aspnet/Home/blob/dev/CONTRIBUTING.md) in the Home repo.

The documentation is built using [Sphinx](http://sphinx-doc.org) and [reStructuredText](http://sphinx-doc.org/rest.html), and then hosted by [ReadTheDocs](http://aspnet.readthedocs.org).

## Building the Docs ##

To build the docs, you will need to install [python](https://www.python.org/downloads/) (version 2 or higher). If you are running Windows, you will want to add the Python install folder and the \Scripts\ folder to your `PATH` environment variable (C:\Python34;C:\Python34\Scripts).

To install Sphinx, open a command prompt and run:

	pip install sphinx

This may take a few minutes.

This project is also using a custom theme from ReadTheDocs, which you can install with:

	pip install sphinx_rtd_theme

Note that later if you wish to update your current, installed version of this theme, you should run:

	pip install -U sphinx_rtd_theme

You should now be able to navigate to the `docs` folder and run

	make html

which should generate the documentation in the _build folder. Open the _build/html/index.html file to view the generated documentation.

You can also install sphinx-autobuild which will run a local web server and automatically refresh whenever changes to docs files are detected. To do so, first install sphinx-autobuild:

	pip install sphinx-autobuild

Then run it from the root of the project with

	sphinx-autobuild docs docs/_build/html

Note that you may need to run 'make html' once before sphinx-autobuild will serve the docs correctly. Also, there seems to be an encoding issue in one of the CSS files in the theme that may cause Python to throw an exception when trying to serve the file. You can work around this issue by editing the cp1252.py file (most likely in C:\Python34\Lib\encodings\ on Windows). Modify the IncrementalDecoder as follows:

	class IncrementalDecoder(codecs.IncrementalDecoder):
    		def decode(self, input, final=False):
        		return codecs.charmap_decode(input,'ignore',decoding_table)[0]

This should allow the CSS file to be loaded, but may result in icons being rendered improperly. A proper fix will likely involve confirming and correcting the encoding used by the CSS file for the RTD theme. Note that you may need to re-apply this fix after making updates to packages on your machine.

If contributing new documentation content, please review:

- the [Sphinx Style Guide](http://documentation-style-guide-sphinx.readthedocs.org/en/latest/style-guide.html)
- [ASP.NET Docs Style Guide](http://docs.asp.net/en/latest/contribute/style-guide.html)

## Adding Content ##

Before adding content, submit an issue with a suggestion for your proposed article. Provide detail on what the article would discuss, and how it would relate to existing documentation.

Articles should be organized into logical groups or sections. Each section should be given a named folder (e.g. /yourfirst). Within each section, each article should also have its own folder, within which the article.rst file resides. Images and other static resources (code samples, etc.) should be placed in a _static folder within the article folder.

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

**Note:** Sphinx will automatically fix duplicate image names, such as the about-page.png files shown above. There is no need to try to ensure uniqueness of static files beyond an individual article.

Author information should be placed in the _authors folder following the example of steve-smith.rst. Place photos in the photos folder - size them to be no more than 125px wide or tall.

## Process for Contributing ##

**Step 1:** Open an Issue describing the article you wish to write and how it relates to existing content. Get approval to write your article.

**Step 2:** Fork the `/aspnet/docs` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article, placing the article in its own folder and any needed images in a _static folder located in the same folder as the article. Be sure to follow the [ASP.NET Docs Style Guide](http://docs.asp.net/en/lastest/contribute/style-guide.html). If you have code samples, place them in a folder within the `/samples/` folder.

**Step 5:** Submit a Pull Request from your branch to `aspnet/docs/master`.

**Step 6:** Discuss the Pull Request with the ASP.NET team; make any requested updates to your branch. When they are ready to accept the PR, they will add a :shipit: (`:shipit:`) comment.

**Step 7:** The last step before your Pull Request is accepted is to [squash all commits](http://stackoverflow.com/questions/14534397/squash-all-my-commits-into-one-for-github-pull-request) into a single commit message. Do this in your branch, using the `rebase` git command. For example, if you want to squash the last 4 commits into a single commit, you would use:

	git rebase -i HEAD~4

The `-i` option stands for "interactive" and should open a text editor showing the last N commits, preceded with "pick ".  Change all but the first instance of "pick " to "squash " and save the file and exit the editor. A more detailed answer is [available here](http://stackoverflow.com/a/6934882).

## Common Pitfalls ##

Below are some common pitfalls you should try to avoid:

- Don't forget to submit an issue before starting work on an article
- Don't forget to create a separate branch before working on your article
- Don't update or `merge` your branch after you submit your pull request
- Don't forget to squash your commits once your pull request is ready to be accepted
- If updating code samples in `/samples/`, be sure any line number references in your article remain correct

