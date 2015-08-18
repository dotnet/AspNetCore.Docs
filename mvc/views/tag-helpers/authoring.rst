Authoring Tag Helpers
===========================================

By `Rick Anderson`_

In this article:

    - `Getting started with Tag Helpers`_
    - `The email tag helper`_
    - `The bold tag helper`_
    - `The web site information tag helper`_
    - `The condition tag helper`_
    - `Auto linking tag helpers`_

You can browse the source code for the sample app on `GitHub <https://github.com/aspnet/Docs/tree/master/mvc/views/tag-helpers/authoring/sample>`__. 

Getting started with Tag Helpers
------------------------------------

#. Create new ASP.NET MVC 6 project called **TagHlp**. You won't need authentication for this project.
#. Create a folder to hold the tag helpers called *TagHelpers*.

The email tag helper
----------------------

In this section we will write a tag helper that will update the following email tag:

``<email>Support</email>``

with an anchor tag to a hard coded email domain. You might want to do this if you are writing a blog engine and need it to send email for marketing, support and other contacts, all to the same domain.

#. Add the following ``EmailTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/EmailTagHelper.cs
    :language: c#

2. Add the ``EmailTagHelper`` to the *Views/_ViewImports.cshtml* file so it will be available to all the views. 

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImports.cshtml
   :language: aspx-cs
   :lines: 1-3
   :emphasize-lines: 3
   
You first add the fully qualified name, then the DLL. 

3. Update the markup in the *Views/Home/Contact.cshtml* file with the changes shown below:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Contact.cshtml
   :language: aspx-cs
   :emphasize-lines: 15-16
   :lines: 1-17
   
4. Run the app and verify the email tag is replaced with the correct anchor markup.

Notes: 

- The ``TargetElement`` attribute identifies "email" as the element to target for processing. ASP.NET MVC 6 uses a naming convention, so you could comment out this attribute (because the class is named EmailTagHelper) and it would still target email tags. Using the attribute does make the intention explict. 
- The ``ProcessAsync`` method is the primary method we will use when authoring tag helpers, and as in this example, we'll generally be using the ``output`` parameter.
- Like  `HTML tags and attributes <http://www.w3.org/TR/html-markup/documents.html#case-insensitivity>`__, tags in you razor, c# or VB are not case-sensitive.

The bold tag helper
---------------------------

#. Add the following ``BoldTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/BoldTagHelper.cs
    :language: c#

The ``[TargetElement]`` attribute passes in an attribute parameter that specifies any HTML element that contains an HTML attribute value of "bold" will match, and the the ``Process`` override method in the class will run. In our sample,  the ``Process``  method removes the "bold" attribute value and surrounds the containing markup with ``<b></b>``.

4. Modify the *About.cshtml* view to contain a ``bold`` attribute value and add the bold tag helper. The completed code is shown below.

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/About.cshtml
   :language: aspx-cs
   :emphasize-lines: 1,8-11 
   :lines: 1-11   

Note the syntax of adding the tag helper you just authored. 

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/About.cshtml
   :language: aspx-cs
   :lines: 1
   :emphasize-lines: 1
   
You would generally bring in the tag helpers in the *Views/_ViewImports.cshtml* file (where the ASP.NET MVC 6 Tag Helpers are bought in by the the templates that created this project). Later in the tutorial I'll show how to use wildcards to bring in all the tag helpers. (2do don't forget to do this.)
  
5. Run the app. You can use your favorite browser to inspect the source and verify the markup has changed as promised.

The ``[TargetElement]`` attribute above only targets HTML markup that provides an attribute value of "bold". The ``<bold>`` element was not modifed by the tag helper.  

6. Comment out the ``[TargetElement]`` attribute line and it will default to to targeting ``<bold>`` tags, that is HTML markup of the form ``<bold>``.

7. Run the app and very the ``<bold>`` tag is replaced.

8. To target both attributes and elements, specify the element and the attrbutes as shown below:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/zBoldTagHelperCopy.cs
   :language: c#
   :lines: 3-16
   :emphasize-lines: 3-4

Notice the ``BoldTagHelper`` class derives from `TagHelper <https://github.com/aspnet/Razor/tree/dev/src/Microsoft.AspNet.Razor.Runtime/TagHelpers>`__.  The ``TagHelper`` class provides the default behavior (that is name matching, bold in our example above), the `TargetElement <https://github.com/aspnet/Razor/blob/dev/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TargetElementAttribute.cs>`__ attribue, the ``Process`` overload and many more feature we will cover in the following sections.

The web site information tag helper
------------------------------------
#. Add a *Models* folder.
#. Add the following ``WebsiteContext`` class to the models folder:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Models/WebsiteContext.cs
    :language: c#

3. Add the following ``WebsiteInformationTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/WebsiteInformationTagHelper.cs
    :language: c#

4. Add the ``WebsiteInformationTagHelper`` to the *Views/_ViewImports.cshtml* file so it will be available to all the views. 

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImports.cshtml
   :language: aspx-cs
   :emphasize-lines: 4
   
5. Add the following markup to the *About.cshtml* view. The highlighted markup displays the web site information.

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/About.cshtml
   :language: aspx-cs
   :emphasize-lines: 13-17  
   :lines: 1-17

6. Run the app, navigate to the about view to see the web site information.   

The condition tag helper
---------------------------------

The condition tag helper renders output when passed a true value.

#. Add the following ``ConditionTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/ConditionTagHelper.cs
    :language: c#

Note: We have arbitrarly chosen to target div, style and p HTML elements, so this tag helper will run on each of these elements.
 
2. Add the ``ConditionTagHelper`` to the *Views/_ViewImports.cshtml* file so it will be available to all the views. 

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImports.cshtml
   :language: aspx-cs
   :emphasize-lines: 5
   
3. Replace the contents of the *Views/Home/Index.cshtml* file with the following markup:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Index.cshtml
   :language: aspx-cs
   :lines: 1-13

4. Replace the ``Index`` method in the ``Home`` controller with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Controllers/HomeController.cs
   :language: c#
   :lines: 9-18
   :emphasize-lines: 9
   
5. Run the app and browse to the home page. The markup in the conditional div will not be rendered. Append  the query string ``?approved=true`` to the URL (for example, http://localhost:1235/?approved=true) and the condition will be true.

Auto linking tag helpers
______________________________

In this section we will write a pair of auto linking tag helpers. The first will replace markup containing a URL starting with HTTP to an HTML anchor tag containing the same URL (and thus yielding a link to the URL), the second will do the same for a URL starting with www.

Because these two helpers are closely related and we may refactor them in the future, we'll keep them in the same file. 

#. Add the following ``AutoLinker`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 2-22

Notes: The ``AutoLinkerHttpTagHelper`` class targets ``p`` elements and uses `Regex <https://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx>`__ to create the anchor.

2. Add the WWW and HTTP tag helpers to the *Views/_ViewImports.cshtml* file so they will be available to all the views. 

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImports.cshtml
   :language: aspx-cs
   :lines:1-6
   :emphasize-lines: 6

3. Add the following markup to the end of the *Views/Home/Contact.cshtml* file:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Contact.cshtml
   :language: aspx-cs
   :lines: 1-20
   :emphasize-lines: 20

4. Verify the tag helper renders the anchor correctly.

5. Update the ``AutoLinker`` class to include the ``AutoLinkerWWWTagHelper`` which will convert www text to an anchor tag which also contains the original www text. The updated code is highlighted below:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 2-39
   :emphasize-lines: 23-38
   
6. Update the markup at the end of the *Views/Home/Contact.cshtml* file to include a www link text:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Contact.cshtml
   :language: aspx-cs
   :lines: 1-22
   :emphasize-lines: 21

7. Run the app. Notice the www text is rendered as a link but the HTTP text is not. If you put a break point in both classes you can see the HTTP tag helper class runs first (this is subject to change). The problem is that the tag helper output is cached, and when the WWW tag helper is run, it overwrites the cached output from the HTTP tag helper. We'll fix that with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1AutoLinkerCopy.cs
   :language: c#
   :lines: 2-46
   :emphasize-lines: 12,13,18,28,29,33
   
8. Run the app and verify the two links work as expected. While it might appear our auto linker tag helper is correct and complete, it has a suble problem. If the WWW tag helper runs first, the the www links will not be correct. Update the the code by addding the following code which adds the ``Order`` overload to control the order the tag runs in. The default order value is zero and lower values run first.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z2AutoLinkerCopy.cs
   :language: c#
   :lines: 9-16
   :emphasize-lines: 5-8

The above code will guarantee the WWW tag helper runs before the HTTP tag helper. 
