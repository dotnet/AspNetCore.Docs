# Contributing #

Information on contributing to this repo is in the [Contributing Guide](https://github.com/aspnet/Home/blob/dev/CONTRIBUTING.md) in the Home repo.

The documentation is built using [Sphinx](http://sphinx-doc.org) and [reStructuredText](http://sphinx-doc.org/rest.html), and then hosted by [ReadTheDocs](http://aspnet.readthedocs.org).

## Video: Getting Started ##
[Watch a video](http://ardalis.com/contributing-to-asp-net-5-documentation) showing how to get started building the documentation locally.

## Building the Docs ##

Once you have cloned the Docs to your local machine, the following instructions will walk you through installing the tools necessary to build and test.

1. [Download python](https://www.python.org/downloads/) version 2.7.10 or higher (Version 3.4 is recommended).

2. If you are installing on Windows, ensure both the Python install directory and the Python scripts directory have been added to your `PATH` environment variable. For example, if you install Python into the c:\python34 directory, you would add `c:\python34;c:\python34\scripts` to your `PATH` environment variable.

3. Install Sphinx by opening a command prompt and running the following Python command. (Note that this operation might take a few minutes to complete.)

    ```pip install sphinx```

4. By default, when you install Sphinx, it will install the ReadTheDocs custom theme automatically. If you need to update the installed version of this theme, you should run:

    ```pip install -U sphinx_rtd_theme```

5. Navigate to one of the main project subdirectories in the Docs repo - such as `mvc`, `aspnet`, or `webhooks`.

6. Use the `make` build script appropriate for your system passing the `html` argument to build the stand-alone version of the project in question.

    ```make html```

7. Once make completes, the generated docs will be in the .../docs/<project>/_build/html directory. Simply open the `index.html` file in your browser to see the built docs for that project.

## Use autobuild to easily view site changes locally ##

You can also install [sphinx-autobuild](https://github.com/GaretJax/sphinx-autobuild) which will run a local web server and automatically refresh whenever changes to the source files are detected. To do so:
    
1. Install sphinx-autobuild

    ```pip install sphinx-autobuild```

2. Navigate to one of the main project subdirectories in the Docs repo - such as `mvc`, `aspnet`, or `webhooks`.

3. Use the `make` build script appropriate for your system passing the `livehtml` argument to automatically build and locally host the docs for the project in question.
 
    ```make livehtml```

4. Browse to `http://127.0.0.1:8000` to see the locally built documentation. 

5. Hit `^C` to stop the local server.

## Adding Content ##

Before adding content, submit an issue with a suggestion for your proposed article. Provide detail on what the article would discuss, and how it would relate to existing documentation.

Also, please review the following style guides:

- [Sphinx Style Guide](http://documentation-style-guide-sphinx.readthedocs.org/en/latest/style-guide.html)
- [ASP.NET Docs Style Guide](http://docs.asp.net/en/latest/contribute/style-guide.html)

Articles should be organized into logical groups or sections. Each section should be given a named folder (e.g. /yourfirst). That section contains the rst files for all articles in the section. For images and other static resources, create a subfolder that matches the name of the article. Within this subfolder, create a ``sample`` folder for code samples and a  ``_static`` folder for images and other static content.

### Example Structure ###

	docs
		/client-side
			/angular
				/_static
					controllers.png
					events.png
					...
				/sample
					(sample code)
			/bootstrap
				/_static
					about-page.png
					...
			angular.rst
			bootstrap.rst

**Note:** Sphinx will automatically fix duplicate image names, such as the about-page.png files shown above. There is no need to try to ensure uniqueness of static files beyond an individual article.

Author information should be placed in the _authors folder following the example of steve-smith.rst. Place photos in the photos folder - size them to be no more than 125px wide or tall.

## Process for Contributing ##

**Step 1:** Open an Issue describing the article you wish to write and how it relates to existing content. Get approval to write your article.

**Step 2:** Fork the `/aspnet/docs` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article, placing the article in its own folder and any needed images in a _static folder located in the same folder as the article. Be sure to follow the [ASP.NET Docs Style Guide](http://docs.asp.net/en/latest/contribute/style-guide.html). If you have code samples, place them in a folder within the `/samples/` folder.

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
