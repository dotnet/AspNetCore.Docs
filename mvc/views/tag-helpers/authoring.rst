Authoring Tag Helpers
===========================================

By `Rick Anderson`_

In this article:

    - `Getting started with Tag Helpers`_
    - `Starting the email tag helper`_
    - `A working email tag helper`_
    - `Inspecting and retrieving child content`_
    - `The bold tag helper`_
    - `The web site information tag helper`_
    - `The condition tag helper`_
    - `Avoiding tag helper conflicts`_
    - `Wrap up and next steps`_

You can browse the source code for the sample app used in this document on `GitHub <https://github.com/aspnet/Docs/tree/master/mvc/views/tag-helpers/authoring/sample>`__. 

Getting started with Tag Helpers
------------------------------------

This tutorial provides an introduction to programming tag helpers. See also :doc:`intro`.

A tag helper is any class that implements `ITagHelper <https://github.com/aspnet/Razor/blob/dev/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/ITagHelper.cs>`__. However, when you author a tag helper, you generally derive from `TagHelper <https://github.com/aspnet/Razor/tree/dev/src/Microsoft.AspNet.Razor.Runtime/TagHelpers>`__. When you derive a class from ``TagHelper``, you get the methods and properties you need to create a tag helper. We will introduce the ``TagHelper`` methods and properties as we use them in this tutorial.

#. Create new ASP.NET MVC 6 project called **TagHlp**. You won't need authentication for this project.
#. Create a folder to hold the tag helpers called *TagHelpers*. The *TagHelpers* folder is not required but is a reasonable convention. Now let's get started writing some simple tag helpers.

Starting the email tag helper
--------------------------------

In this section we will write a tag helper that will update an email tag, for example:

``<email>Support</email>``

and the server will user our email tag helper to convert that markup into the following:

.. code-block:: HTML

	<a href="mailto:Support@example.com">Support@example.com</a>

That is, an anchor tag making this an email link. You might want to do this if you are writing a blog engine and need it to send email for marketing, support and other contacts, all to the same domain.

#. Add the following ``EmailTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1EmailTagHelperCopy.cs
   :language: c#
   :lines: 2-16
   
Notes: 

- The ``TargetElement`` attribute identifies "email" as the element to target for processing. ASP.NET MVC 6 uses a naming convention, so you could comment out this attribute (because the class is named **Email**\TagHelper) and it would still target email tags. Using the attribute does make the intention explicit (that is, we are targeting **<email/>** tags.)
- The ``EmailTagHelper`` class derives from `TagHelper <https://github.com/aspnet/Razor/tree/dev/src/Microsoft.AspNet.Razor.Runtime/TagHelpers>`__. The ``TagHelper`` class provides the rich methods and properties we will examine in this tutorial.
- The ``ProcessAsync`` asynchronously executes the tag helper. The ``TagHelper`` class also provides a synchronous version with the same parameters named ``Process``, but in this tutorial we'll only be using the asynchronous version. Unless you have a specific reason to use the synchronous version, you should generally use ``ProcessAsync``.
- The context parameter to ``ProcessAsync`` contains information associated with the current HTML tag. We will use the context parameter to get the content of our target element.
- The output parameter to ``ProcessAsync`` contains a stateful HTML element used to generate an HTML tag and content.

2. Add the ``EmailTagHelper`` to the *Views/_ViewImports.cshtml* file so it will be available to all the views. 

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImports.cshtml
   :language: aspx-cs
   :lines: 1-3
   :emphasize-lines: 3

To add a tag helper to a view, you first add the fully qualified name (``TagHlp.TagHelpers.EmailTagHelper``), then the DLL name (*TagHlp*). You typically add tag helpers to the *Views/_ViewImports.cshtml* file as we've done here, but it's more common to use wildcard syntax to bring in all tag helpers with one line as the following shows:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImportsCopy.cshtml
   :language: aspx-cs
   :lines: 2-4
   :emphasize-lines: 2,3

.. This is a comment

Using the wildcard syntax, you don't need to use the fully qualified name. Also note the second line brings in the `ASP.NET 5 MVC 6 tag helpers <https://github.com/aspnet/Mvc/tree/dev/src/Microsoft.AspNet.Mvc.TagHelpers>`__ using the wild card syntax (Those helpers are discussed in :doc:`intro`). It's the ``@addTagHelper`` command that makes the tag helper available to the razor view.
   
3. Update the markup in the *Views/Home/Contact.cshtml* file with the changes shown below:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Contact.cshtml
   :language: aspx-cs
   :emphasize-lines: 15-16
   :lines: 1-17
   
4. Run the app and use your favorite browser to view the HTML source so you can verify the email tag is replaced with the correct anchor markup (``<a>Support</a>``). Support is rendered as a link, but it doesn't have an ``href`` attribute to make it functional. We'll fix that in the next section.

Note: Like `HTML tags and attributes <http://www.w3.org/TR/html-markup/documents.html#case-insensitivity>`__, tags, class names and attributes in razor, c# and VB are not case-sensitive.

A working email tag helper
----------------------------------

In this section we will update the ``EmailTagHelper`` so that it will create a valid anchor tag for email.

#. Update the ``EmailTagHelper`` class with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/EmailTagHelper.cs
   :emphasize-lines: 9,13-15
   
Notes:

- We use the ``context`` parameter to get contents of the HTML element.
- The following line shows the syntax for setting attribute values:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/EmailTagHelper.cs
   :lines: 14
   :dedent: 12

- The last line sets the completed content for our minimally functional tag helper.

2. Run the app and verify it generates  a valid email link.

Next we'll update our tag helper to take information from a razor view (in the form of a ``mail-to`` attribute) and use that in generating the anchor.

Update the ``EmailTagHelper`` class with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/EmailTagHelperMailTo.cs
   :lines: 7-24
   :emphasize-lines: 6-8, 14-16
   :dedent: 3

Notes:

- The ASP.NET 5 runtime translates c# and VB Pascal cased classes and property names for tag helpers into `lower kebab case <http://stackoverflow.com/questions/11273282/whats-the-name-for-dash-separated-case/12273101#12273101>`__. Therefore, to use the ``MailTo`` attribute, you'll use ``<email mail-to="value"/>``.

3. Update the markup in the *Views/Home/Contact.cshtml* file with the changes shown below:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/ContactCopy.cshtml
   :language: aspx-cs
   :emphasize-lines: 15-16
   :lines: 1-17
 
4. Run the app and verify it generates the correct links.

**Note:** If you were to write the email tag self-closing (``<email mail-to="Rick" />``) the final output would also be self-closing. In our example, the output would be ``<a href="mailto:Rick@contoso.com" />``. Self-closing anchor tags are not valid HTML, so you wouldn't want to create one. The ASP.NET 5 runtime sets the state of the ``SelfClosing`` property after reading a tag. 
   
Inspecting and retrieving child content
----------------------------------------

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/EmailTagHelper.cs
   :lines: 7-17
   :dedent: 4

.. This is a comment

TODO this section to showcase the ways you can interact with it and how context.GetChildcontentAsync plays a role. For example?

The bold tag helper
---------------------------

#. Add the following ``BoldTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/BoldTagHelper.cs
    :language: c#

Notes:

- The ``[TargetElement]`` attribute passes in an attribute parameter that specifies any HTML element that contains an HTML attribute value of "bold" will match, and the ``Process`` override method in the class will run. In our sample,  the ``Process``  method removes the "bold" attribute value and surrounds the containing markup with ``<strong></strong>``.
- Because we are keeping the tag content, we must write the opening tag with the ``PreContent.SetContent`` method and the closing tag with the ``PostContent.SetContent`` method.

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
   
You would generally bring in the tag helpers in the *Views/_ViewImports.cshtml* file as we did in the previous section. You might want to reference a tag helper in a view like this to limit the tag helper to only those views you explicitly opt in.
  
5. Run the app. You can use your favorite browser to inspect the source and verify the markup has changed as promised.

The ``[TargetElement]`` attribute above only targets HTML markup that provides an attribute value of "bold". The ``<bold>`` element was not modified by the tag helper.  

6. Comment out the ``[TargetElement]`` attribute line and it will default to targeting ``<bold>`` tags, that is HTML markup of the form ``<bold>``. (Remember the default naming convention will match the class name **Bold**\TagHelper to ``<bold>`` tags.)

7. Run the app and very the ``<bold>`` tag is processed by the tag helper.

Decorating a class with multiple ``TargetElement`` statements results in a logical-OR of the targets. For example using the code below, a bold tag or a bold attribute will match.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/zBoldTagHelperCopy.cs
   :language: c#
   :lines: 5-6
 
When multiple attributes are added to the same statement, the runtime treats them as a logical-AND. For example in the code below, an HTML element must contain both a bold tag and a bold attribute to match.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/zBoldTagHelperCopy2.cs
   :language: c#
   :lines: 5

The web site information tag helper
------------------------------------

#. Add a *Models* folder.
#. Add the following ``WebsiteContext`` class to the models folder:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Models/WebsiteContext.cs
    :language: c#

3. Add the following ``WebsiteInformationTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/WebsiteInformationTagHelper.cs
    :language: c#

Notes: 

- As mentioned previously, the ASP.NET 5 runtime translates Pascal cased c# class names for tag helpers into `lower kebab case <http://c2.com/cgi/wiki?KebabCase>`__. Therefore, to use the ``WebsiteInformationTagHelper`` in razor, you'll write ``<website-information />``.
- We are not explicitly identifying the target element with the ``TargetElement`` attribute, so the default of ``website-information`` will be targeted. If you applied the following attribute (note it's not kebab case but matches the class name):

.. code-block:: c#

	    [TargetElement("WebsiteInformation")]

The lower kebab case tag ``<website-information />`` would not match. If you want use the attribute, you would use kebab case as shown below:

.. code-block:: c#

	    [TargetElement("Website-Information")]

- `Void elements <http://www.w3.org/TR/html5/syntax.html#void-elements>`_ (that is, an element with a self-closing tag) have no content. For this example, the Razor markup will use a self-closing tag, but the tag helper will be creating a section element (which is not self-closing and we are writing content), therefore we need to set self-closing to false so we have output. Alternatively, you can comment out the line setting self-closing to false and write markup with a closing tag.

4. Update the *Views/_ViewImports.cshtml* file to use wildcard importing of tag helpers so all our tag helpers will be imported.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImportsCopy.cshtml
   :language: aspx-cs
   :lines: 2-4
   :emphasize-lines: 3

5. Add the following markup to the *About.cshtml* view. The highlighted markup displays the web site information.

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/About.cshtml
   :language: aspx-cs
   :emphasize-lines: 13-20  
   :lines: 1-20

Note: In the razor markup shown below:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/About.cshtml
   :language: aspx-cs
   :lines: 15-20
   
the ASP.NET 5 runtime knows the ``info`` attribute is a class, not a string and you want to write c# code, therefore it doesn't require the razor ``@`` character.

6. Run the app, navigate to the about view to see the web site information.   

Notes:

- You can use the following markup with a closing tag and remove the line  setting self-closing to false in the tag helper:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/AboutNotSelfClosing.cshtml
   :language: aspx-cs
   :lines: 15-20

The condition tag helper
---------------------------------

The condition tag helper renders output when passed a true value.

#. Add the following ``ConditionTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/ConditionTagHelper.cs
    :language: c#
    
2. Replace the contents of the *Views/Home/Index.cshtml* file with the following markup:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Index.cshtml
   :language: aspx-cs
   :lines: 1-13

3. Replace the ``Index`` method in the ``Home`` controller with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Controllers/HomeController.cs
   :language: c#
   :lines: 9-18
   
4. Run the app and browse to the home page. The markup in the conditional ``div`` will not be rendered. Append  the query string ``?approved=true`` to the URL (for example, http://localhost:1235/Home/Index?approved=true) the condition will be true and the conditional markup will be displayed.

Note: We use the `nameof <https://msdn.microsoft.com/en-us/library/dn986596.aspx>`_ operator to specify the attribute to target rather than specifying a string as we did with the bold tag helper:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/zConditionTagHelperCopy.cs
    :language: c#
    :lines: 7-21
    :emphasize-lines: 1,2,6

The `nameof <https://msdn.microsoft.com/en-us/library/dn986596.aspx>`_ operator will protect the code should it ever be refactored (we might want to change the name to RedCondition).

Avoiding tag helper conflicts
______________________________

In this section we will write a pair of auto linking tag helpers. The first will replace markup containing a URL starting with HTTP to an HTML anchor tag containing the same URL (and thus yielding a link to the URL), the second will do the same for a URL starting with WWW.

Because these two helpers are closely related and we may refactor them in the future, we'll keep them in the same file. 

#. Add the following ``AutoLinker`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 2-22

Notes: The ``AutoLinkerHttpTagHelper`` class targets ``p`` elements and uses `Regex <https://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx>`__ to create the anchor.


2. Add the following markup to the end of the *Views/Home/Contact.cshtml* file:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Contact.cshtml
   :language: aspx-cs
   :lines: 1-20
   :emphasize-lines: 20

3. Run the app and verify the tag helper renders the anchor correctly.

4. Update the ``AutoLinker`` class to include the ``AutoLinkerWWWTagHelper`` which will convert www text to an anchor tag which also contains the original www text. The updated code is highlighted below:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 2-39
   :emphasize-lines: 23-38
   
5. Update the markup at the end of the *Views/Home/Contact.cshtml* file to include a www link text:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Contact.cshtml
   :language: aspx-cs
   :lines: 1-22
   :emphasize-lines: 21

6. Run the app. Notice the www text is rendered as a link but the HTTP text is not. If you put a break point in both classes you can see the HTTP tag helper class runs first (this is subject to change). The problem is that the tag helper output is cached, and when the WWW tag helper is run, it overwrites the cached output from the HTTP tag helper. We'll fix that with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1AutoLinkerCopy.cs
   :language: c#
   :lines: 2-46
   :emphasize-lines: 12,13,17,28,29,33
   
Note: In the first edition of the auto linking tag helpers, we got the content of the target with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 13-14
   :dedent: 12
   
That is, we call  `GetChildContentAsync <https://github.com/aspnet/Razor/blob/dev/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelperContext.cs#L65-L79>`__ using the `TagHelperContext <https://github.com/aspnet/Razor/blob/dev/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelperContext.cs>`__ passed into the ``ProcessAsync`` method. As mentioned previously, because the output is cached, the last tag helper to run wins. We fixed that problem with the following code:

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z2AutoLinkerCopy.cs
   :language: c#
   :lines: 19-20
   :dedent: 12
   
The code above checks to see if the content has been modified, and if it has, it gets the content from the output buffer.
   
7. Run the app and verify the two links work as expected. While it might appear our auto linker tag helper is correct and complete, it has a subtle problem. If the WWW tag helper runs first, the www links will not be correct. Update the code by adding the  ``Order`` overload to control the order the tag runs in. The ``Order`` property determines the execution order relative to other tag helpers targeting the same element. The default order value is zero and instances with lower values are executed first.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/z2AutoLinkerCopy.cs
   :language: c#
   :lines: 9-16
   :emphasize-lines: 5-8

The above code will guarantee the WWW tag helper runs before the HTTP tag helper. Change ``Order`` to ``MaxValue`` and verify the code WWW tag is incorrect.

Wrap up and next steps
-----------------------

This was an introduction to authoring tag helpers and should not be considered a guide to best practices. For example a real app would probably use a more elegant regular expression to replace both HTTP and WWW links in one expression. The `ASP.NET 5 MVC 6 tag helpers <https://github.com/aspnet/Mvc/tree/dev/src/Microsoft.AspNet.Mvc.TagHelpers>`__ provide the best examples of well written tag helpers.