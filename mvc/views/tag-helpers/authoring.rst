Authoring Tag Helpers
===========================================

By `Rick Anderson`_

In this article:

    - `Getting started with Tag Helpers`_
    - `The email tag helper`_
    - `The web site information tag helper`_

You can browse the source code for the sample app on `GitHub <https://github.com/aspnet/Docs/tree/master/mvc/views/tag-helpers/authoring/sample>`__. 


Getting started with Tag Helpers
------------------------------------

#. Create new ASP.NET MVC 6 project called **TagHlp**. You won't need authentication for this project.
#. Create a folder to hold the tag helpers called *TagHelpers*.
#. Add the following ``BoldTagHelper`` class in the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/BoldTagHelper.cs
    :language: c#

The ``[TargetElement]`` attribute passes in an attribute parameter that specifies any HTML element that contains an HTML attribute value of "bold" will match, and the the ``Process`` override method in the class will run. In our sample,  the ``Process``  method removes the "bold" attribute value and surrounds the containing markup with ``<b></b>``.

4. Modify the *About.cshtml* view to contain a ``bold`` attribute value and add the bold tag helper. The completed code is shown below with the changes highlighted.

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/About.cshtml
   :language: aspx-cs
   :emphasize-lines: 8,11   

Note the syntax of adding the tag helper you just authored. 

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/About.cshtml
   :language: aspx-cs
   :lines: 8
   :emphasize-lines: 1
   
You first add the fully qualified name, then the DLL. You would generally bring in the tag helpers in the *Views//_ViewImports.cshtml* file (where the ASP.NET MVC 6 Tag Helpers are bought in by the the templates that created this project). Later in the tutorial I'll show how to use wildcards to bring in all the tag helpers.
  
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

The email tag helper
----------------------

In this section we will write a tag helper that will update the following markup:

``<email>Support</email>``

with an anchor tag to a hard coded domain. You might want to do this if you are writing a blog engine and need to have write markup for support, marketing and other contacts, all to the same domain. 

#. Add the following ``EmailTagHelper`` class in the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/EmailTagHelper.cs
    :language: c#

2. Add the ``EmailTagHelper`` to the *Views//_ViewImports.cshtml* file so it will be available to all our views. This is the pattern we'll follow for the rest of the tutorial.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImports.cshtml
   :language: aspx-cs
   :lines: 1-3
   :emphasize-lines: 3

3. Update the markup in the *Views//Home//Contact.cshtml* file with the changes shown below:

.. literalinclude::  authoring/sample/TagHlp/src/TagHlp/Views/Home/Contact.cshtml
   :language: aspx-cs
   :emphasize-lines: 15-16
   
4. Run the app and verify the email tag is replaced with the correct anchor markup.

Notes: 

#. Like  `HTML tags and attributes <http://www.w3.org/TR/html-markup/documents.html#case-insensitivity>`__, tags in you razor, c# or VB are not case-sensitive.
#. You can comment out the ``[TargetElement("email")]`` attribute, it will still target the email element by naming convention. Using the attribute does make the intention explict. 

The web site information tag helper
------------------------------------


#. Add the following ``WebsiteInformationTagHelper`` class in the *TagHelpers* folder.

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/TagHelpers/WebsiteInformationTagHelper.cs
    :language: c#

2. Add the ``WebsiteInformationTagHelper`` to the *Views//_ViewImports.cshtml* file so it will be available to all our views. 

.. literalinclude:: authoring/sample/TagHlp/src/TagHlp/Views/_ViewImports.cshtml
   :language: aspx-cs
   :emphasize-lines: 4