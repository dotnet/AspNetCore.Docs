Authoring Tag Helpers
===========================================

.. TODO: Once we get the API reference docs, add mref links to all APIs. 

By `Rick Anderson`_

    - `Getting started with Tag Helpers`_ 
    - `Starting the email Tag Helper`_
    - `A working email Tag Helper`_
    - `The bold Tag Helper`_
    - `Web site information Tag Helper`_
    - `Condition Tag Helper`_
    - `Avoiding Tag Helper conflicts`_
    - `Inspecting and retrieving child content`_
    - `Wrap up and next steps`_
    - `Additional Resources`_

You can browse the source code for the sample app used in this document on `GitHub <https://github.com/aspnet/Docs/tree/master/mvc/views/tag-helpers/authoring/sample>`__. 

Getting started with Tag Helpers
------------------------------------

This tutorial provides an introduction to programming Tag Helpers. :doc:`intro` describes the benefits that Tag Helpers provide.

A tag helper is any class that implements the ``ITagHelper`` interface. However, when you author a tag helper, you generally derive from ``TagHelper``, doing so gives you access to the ``Process`` method. We will introduce the ``TagHelper`` methods and properties as we use them in this tutorial. 

#. Create a new ASP.NET MVC 6 project called **AuthoringTagHelpers**. You won't need authentication for this project.
#. Create a folder to hold the Tag Helpers called *TagHelpers*. The *TagHelpers* folder is *not* required, but it is a reasonable convention. Now let's get started writing some simple tag helpers.

Starting the email Tag Helper
--------------------------------

In this section we will write a tag helper that updates an email tag. For example:

.. code-block:: html

	<email>Support</email>

The server will use our email tag helper to convert that markup into the following:

.. code-block:: html

	<a href="mailto:Support@contoso.com">Support@contoso.com</a>

That is, an anchor tag that makes this an email link. You might want to do this if you are writing a blog engine and need it to send email for marketing, support, and other contacts, all to the same domain.

#. Add the following ``EmailTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z1EmailTagHelperCopy.cs
   :language: c#
   
**Notes:** 

- Tag helpers use a naming convention that targets elements of the root class name (minus the *TagHelper* portion of the class name). In this example, the root name of **Email**\TagHelper is *email*, so the ``<email>`` tag will be targeted. This naming convention should work for most tag helpers, later on I'll show how to override it.

- The ``EmailTagHelper`` class derives from ``TagHelper``. The ``TagHelper`` class provides the rich methods and properties we will examine in this tutorial.
- The  overridden ``Process`` method controls what the tag helper does when executed. The ``TagHelper`` class also provides an asynchronous version (``ProcessAsync``) with the same parameters.
- The context parameter to ``Process`` (and ``ProcessAsync``) contains information associated with the execution of the current HTML tag.
- The output parameter to ``Process`` (and ``ProcessAsync``) contains a stateful HTML element representative of the original source used to generate an HTML tag and content.
- Our class name has a suffix of **TagHelper**, which is *not* required, but it's considered a best practice convention. You could declare the class as:

.. code-block:: c#

	public class Email : TagHelper

2. To make the ``EmailTagHelper`` class available to all our Razor views, we will add the ``addTagHelper`` directive to the *Views/_ViewImports.cshtml* file:

.. wildcard syntax

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/_ViewImportsCopy.cshtml
   :language: html
   :emphasize-lines: 2,3

The code above uses the wildcard syntax to specify all the tag helpers in our assembly will be available. The first string after ``@addTagHelper`` specifies the tag helper to load (we are using "\*" for all tag helpers), and the second string "AuthoringTagHelpers" specifies the assembly the tag helper is in. Also, note that the second line brings in the ASP.NET 5 MVC 6 tag helpers using the wildcard syntax (those helpers are discussed in :doc:`intro`.) It's the ``@addTagHelper`` directive that makes the tag helper available to the Razor view. Alternatively, you can provide the fully qualified name (FQN) of a tag helper as shown below:

.. FQN syntax

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/_ViewImports.cshtml
   :language: html
   :lines: 1-3
   :emphasize-lines: 3

To add a tag helper to a view using a FQN, you first add the FQN (``AuthoringTagHelpers.TagHelpers.EmailTagHelper``), and then the assembly name (*AuthoringTagHelpers*). Most developers will prefer to use the wildcard syntax. :doc:`using` goes into detail on tag helper adding, removing, hierarchy, and wildcard syntax. 

3. Update the markup in the *Views/Home/Contact.cshtml* file with these changes:

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/Contact.cshtml
   :language: html
   :emphasize-lines: 15-16
   :lines: 1-17
   
4. Run the app and use your favorite browser to view the HTML source so you can verify that the email tags are replaced with anchor markup (For example, ``<a>Support</a>``). *Support* and *Marketing* are rendered as a links, but they don't have an ``href`` attribute to make them functional. We'll fix that in the next section.

**Note:** Like `HTML tags and attributes <http://www.w3.org/TR/html-markup/documents.html#case-insensitivity>`__, tags, class names and attributes in Razor, and C# are not case-sensitive.

A working email Tag Helper
----------------------------------
In this section, we will update the ``EmailTagHelper`` so that it will create a valid anchor tag for email. We'll update our tag helper to take information from a Razor view (in the form of a ``mail-to`` attribute) and use that in generating the anchor.

Update the ``EmailTagHelper`` class with the following:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/EmailTagHelperMailTo.cs
   :lines: 5-24
   :dedent: 4 
   :language: c#

**Notes:**

-  Pascal-cased class and property names for tag helpers are translated into their `lower kebab case <http://stackoverflow.com/questions/11273282/whats-the-name-for-dash-separated-case/12273101#12273101>`__. Therefore, to use the ``MailTo`` attribute, you'll use ``<email mail-to="value"/>`` equivalent.
- The last line sets the completed content for our minimally functional tag helper.
- The following line shows the syntax for adding attributes:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/EmailTagHelperMailTo.cs
   :lines: 14-21
   :dedent: 8
   :emphasize-lines: 6
   :language: c#
   
That approach works for the attribute "href" as long as it doesn't currently exist in the attributes collection. You can also use the ``output.Attributes.Add`` method to add a tag helper attribute to the end of the collection of tag attributes.

3. Update the markup in the *Views/Home/Contact.cshtml* file with these changes:

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/ContactCopy.cshtml
   :language: html
   :emphasize-lines: 15-16 
   :lines: 1-17
 
4. Run the app and verify that it generates the correct links.

**Note:** If you were to write the email tag self-closing (``<email mail-to="Rick" />``), the final output would also be self-closing. To enable the ability to write the tag with only a start tag ``<email mail-to="Rick" />``) you must decorate the class with the following:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/EmailTagHelperMailVoid.cs
   :lines: 6
   :dedent: 4 
   :language: c#
   
With a self-closing email tag helper, the output would be ``<a href="mailto:Rick@contoso.com" />``. Self-closing anchor tags are not valid HTML, so you wouldn't want to create one, but you might want to create a tag helper that is self-closing. Tag helpers set the type of the ``TagMode`` property after reading a tag.

.. In this section we will update the ``EmailTagHelper`` so that it gets the target ``mail-to`` from the content. Need to revert the contact.cshtml file back.

An asynchronous email helper
_____________________________________

In this section we'll write an asynchronous email helper. 

#. Replace the ``EmailTagHelper`` class with the following code:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/EmailTagHelper.cs
   :lines: 6-17
   :dedent: 4
   :language: c#
   
**Notes:**

- This version uses the asynchronous ``ProcessAsync`` method. The asynchronous ``GetChildContentAsync`` returns a ``Task`` containing the ``TagHelperContent``. 
- We use the ``context`` parameter to get contents of the HTML element.

2. Make the following change to the *Views/Home/Contact.cshtml* file so the tag helper can get the target email.

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/Contact.cshtml
   :language: html
   :emphasize-lines: 15-16 
   :lines: 1-17

3. Run the app and verify that it generates valid email links.
    
The bold Tag Helper
---------------------------

#. Add the following ``BoldTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/BoldTagHelper.cs
    :language: c#

**Notes:** 

- The ``[TargetElement]`` attribute passes an attribute parameter that specifies that any HTML element that contains an HTML attribute named "bold" will match, and the ``Process`` override method in the class will run. In our sample, the ``Process``  method removes the "bold" attribute and surrounds the containing markup with ``<strong></strong>``.
-  Because we don't want to replace the existing tag content, we must write the opening ``<strong>`` tag with the ``PreContent.SetContent`` method and the closing ``</strong>`` tag with the ``PostContent.SetContent`` method.

2. Modify the *About.cshtml* view to contain a ``bold`` attribute value. The completed code is shown below.

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/AboutBoldOnly.cshtml
   :language: html
   :lines: 1-9
   :emphasize-lines: 7        
  
3. Run the app. You can use your favorite browser to inspect the source and verify that the markup has changed as promised.

The ``[TargetElement]`` attribute above only targets HTML markup that provides an attribute name of "bold". The ``<bold>`` element was not modified by the tag helper.  

4. Comment out the ``[TargetElement]`` attribute line and it will default to targeting ``<bold>`` tags, that is, HTML markup of the form ``<bold>``. Remember, the default naming convention will match the class name **Bold**\TagHelper to ``<bold>`` tags.

5. Run the app and verify that the ``<bold>`` tag is processed by the tag helper.

Decorating a class with multiple ``[TargetElement]`` attributes results in a logical-OR of the targets. For example, using the code below, a bold tag or a bold attribute will match.

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/zBoldTagHelperCopy.cs
   :language: c#
   :lines: 5-6
 
When multiple attributes are added to the same statement, the runtime treats them as a logical-AND. For example, in the code below, an HTML element must be named "bold" with an attribute named "bold" ( <bold bold /> ) to match.

.. code-block:: c#

        [TargetElement("bold", Attributes = "bold")]

For a good example of a bootstrap progress bar that targets a tag and an attribute, see `Creating custom MVC 6 Tag Helpers <http://www.davepaquette.com/archive/2015/06/22/creating-custom-mvc-6-tag-helpers.aspx>`__.

You can also use the ``[TargetElement]`` to change the name of the targeted element. For example if you wanted the ``BoldTagHelper`` to target ``<MyBold>`` tags, you would use the following attribute:

.. code-block:: c#

	    [TargetElement("MyBold")]

Web site information Tag Helper
------------------------------------

#. Add a *Models* folder.
#. Add the following ``WebsiteContext`` class to the *Models* folder:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Models/WebsiteContext.cs
    :language: c#

3. Add the following ``WebsiteInformationTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/WebsiteInformationTagHelper.cs
    :language: c#

**Notes:** 

- As mentioned previously, tag helpers translates Pascal-cased C# class names and properties for tag helpers into `lower kebab case <http://c2.com/cgi/wiki?KebabCase>`__. Therefore, to use the ``WebsiteInformationTagHelper`` in Razor, you'll write ``<website-information />``.
- We are not explicitly identifying the target element with the ``[TargetElement]`` attribute, so the default of ``website-information`` will be targeted. If you applied the following attribute (note it's not kebab case but matches the class name):

.. code-block:: c#

	    [TargetElement("WebsiteInformation")]

The lower kebab case tag ``<website-information />`` would not match. If you want use the ``[TargetElement]`` attribute, you would use kebab case as shown below:

.. code-block:: c#

	    [TargetElement("Website-Information")]

- Elements that are self-closing have no content. For this example, the Razor markup will use a self-closing tag, but the tag helper will be creating a `section <http://www.w3.org/TR/html5/sections.html#the-section-element>`__ element (which is not self-closing and we are writing content inside the ``section`` element). Therefore, we need to set ``TagMode`` to ``StartTagAndEndTag`` to write output. Alternatively, you can comment out the line setting ``TagMode`` and write markup with a closing tag. (Example markup is provided later in this tutorial.)
- The ``$`` (dollar sign) in the following line uses an `interpolated string <https://msdn.microsoft.com/en-us/library/Dn961160.aspx>`__:

.. code-block:: c#

	$@"<ul><li><strong>Version:</strong> {Info.Version}</li>

5. Add the following markup to the *About.cshtml* view. The highlighted markup displays the web site information.

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/About.cshtml
   :language: html
   :emphasize-lines: 1,12-20  
   :lines: 1-20

**Note:** In the Razor markup shown below:

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/About.cshtml
   :language: html
   :lines: 13-17
   
Razor knows the ``info`` attribute is a class, not a string, and you want to write C# code. Any non-string tag helper attribute should be written without the ``@`` character.

6. Run the app, and navigate to the About view to see the web site information.   

**Note:**

- You can use the following markup with a closing tag and remove the line with ``TagMode.StartTagAndEndTag`` in the tag helper:

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/AboutNotSelfClosing.cshtml
   :language: html
   :lines: 13-18

Condition Tag Helper
---------------------------------

The condition tag helper renders output when passed a true value.

#. Add the following ``ConditionTagHelper`` class to the *TagHelpers* folder.

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/ConditionTagHelper.cs
    :language: c#
    
2. Replace the contents of the *Views/Home/Index.cshtml* file with the following markup:

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/Index.cshtml
   :language: html

3. Replace the ``Index`` method in the ``Home`` controller with the following code:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Controllers/HomeController.cs
   :language: c#
   :lines: 9-18
   :dedent: 6

4. Run the app and browse to the home page. The markup in the conditional ``div`` will not be rendered. Append the query string ``?approved=true`` to the URL (for example, http://localhost:1235/Home/Index?approved=true). The approved is set to true and the conditional markup will be displayed.

**Note:** We use the `nameof <https://msdn.microsoft.com/en-us/library/dn986596.aspx>`_ operator to specify the attribute to target rather than specifying a string as we did with the bold tag helper:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/zConditionTagHelperCopy.cs
    :language: c#
    :lines: 5-18
    :emphasize-lines: 1,2,5
    :dedent: 3
   
The `nameof <https://msdn.microsoft.com/en-us/library/dn986596.aspx>`_ operator will protect the code should it ever be refactored (we might want to change the name to RedCondition).

Avoiding Tag Helper conflicts
______________________________

In this section, we will write a pair of auto-linking tag helpers. The first will replace markup containing a URL starting with HTTP to an HTML anchor tag containing the same URL (and thus yielding a link to the URL). The second will do the same for a URL starting with WWW.

Because these two helpers are closely related and we may refactor them in the future, we'll keep them in the same file.

#. Add the following ``AutoLinker`` class to the *TagHelpers* folder. 

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 7-20
   :dedent: 4

**Notes:** The ``AutoLinkerHttpTagHelper`` class targets ``p`` elements and uses `Regex <https://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx>`__ to create the anchor.

2. Add the following markup to the end of the *Views/Home/Contact.cshtml* file:

.. literalinclude::  authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/Views/Home/Contact.cshtml
   :language: html
   :lines: 1-19
   :emphasize-lines: 19

3. Run the app and verify that the tag helper renders the anchor correctly.

4. Update the ``AutoLinker`` class to include the ``AutoLinkerWwwTagHelper`` which will convert www text to an anchor tag that also contains the original www text. The updated code is highlighted below:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 7-34
   :emphasize-lines: 15-34
   :dedent: 4
   
5. Run the app. Notice the www text is rendered as a link but the HTTP text is not. If you put a break point in both classes, you can see that the HTTP tag helper class runs first. Later in the tutorial we'll see how to control the order that tag helpers run in. The problem is that the tag helper output is cached, and when the WWW tag helper is run, it overwrites the cached output from the HTTP tag helper. We'll fix that with the following code:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z1AutoLinkerCopy.cs
   :language: c#
   :lines: 8-38
   :emphasize-lines: 5,6,10,21,22,26
   
**Note:** In the first edition of the auto-linking tag helpers, we got the content of the target with the following code:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z1AutoLinker.cs
   :language: c#
   :lines: 12
   :dedent: 12
   
That is, we call ``GetChildContentAsync`` using the ``TagHelperContext`` passed into the ``ProcessAsync`` method. As mentioned previously, because the output is cached, the last tag helper to run wins. We fixed that problem with the following code:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z2AutoLinkerCopy.cs
   :language: c#
   :lines: 18-19
   :dedent: 12
   
The code above checks to see if the content has been modified, and if it has, it gets the content from the output buffer.
   
7. Run the app and verify that the two links work as expected. While it might appear our auto linker tag helper is correct and complete, it has a subtle problem. If the WWW tag helper runs first, the www links will not be correct. Update the code by adding the ``Order`` overload to control the order that the tag runs in. The ``Order`` property determines the execution order relative to other tag helpers targeting the same element. The default order value is zero and instances with lower values are executed first.

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z2AutoLinkerCopy.cs
   :language: c#
   :lines: 8-15
   :emphasize-lines: 5-8
   :dedent: 4

The above code will guarantee that the WWW tag helper runs before the HTTP tag helper. Change ``Order`` to ``MaxValue`` and verify that the markup generated for the  WWW tag is incorrect.

Inspecting and retrieving child content
----------------------------------------

The tag-helpers provide several properties to retrieve content.

- The result of ``GetChildContentAsync`` can be appended to ``output.Content``. 
- You can inspect the result of ``GetChildContentAsync`` with ``GetContent``.
- If you modify ``output.Content``, the TagHelper body will not be executed or rendered unless you call ``GetChildContentAsync`` as in our auto-linker sample:

.. literalinclude:: authoring/sample/AuthoringTagHelpers/src/AuthoringTagHelpers/TagHelpers/z1AutoLinkerCopy.cs
   :language: c#
   :lines: 8-21
   :emphasize-lines: 5,6,10
   :dedent: 4
   
- Multiple calls to ``GetChildContentAsync`` will return the same value and will not re-execute the ``TagHelper`` body unless you pass in a false parameter indicating  not use the cached result.
   
Wrap up and next steps
-----------------------

This tutorial was an introduction to authoring tag helpers and *the code samples* should not be considered a guide to best practices. For example, a real app would probably use a more elegant regular expression to replace both HTTP and WWW links in one expression. The ASP.NET 5 MVC 6 tag helpers provide the best examples of well-written tag helpers. 

Additional Resources
----------------------
 
- `TagHelperSamples on GitHub <https://github.com/dpaquette/TagHelperSamples>`__ contains tag helper samples for working with `Bootstrap <http://getbootstrap.com/>`__. 
- `Channel 9 video on advanced tag helpers <https://channel9.msdn.com/Shows/Web+Camps+TV/Update-on-TagHelpers-with-Taylor-Mullen>`_. This is a great video on more advanced features. It's a couple versions out of date but the comments contain a list of changes to the current version and the updated code can be found `here <https://github.com/NTaylorMullen/WebCampsTV_TagHelpers1>`__.