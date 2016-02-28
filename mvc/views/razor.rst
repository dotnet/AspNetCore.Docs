Razor Syntax In MVC 6
=====================
By `John Rowley`_

What is Razor?
---------------
The Razor syntax provides a fast, terse, clean and lightweight way to combine
server code with HTML to create dynamic web content.


Expressions
-----------
Expressions can be spit into two groups, implicit and explicit.


Implicit
~~~~~~~~
Implicit Expressions provide a simple mechanism to render data. They are simply
an ``@`` followed by a variable, or method. Razor renders the value to the
output at runtime. The following markup renders the variable ``guestName``
inside an H2 heading element.

.. code-block:: C#

  @{ var guestName = "John"; }

  <h2>@guestName</h2>

Razor automatically escapes the ``@`` used in an email address. To escape ``@``
use ``@@``

.. note:: The first line of code is a code block. How codeblocks work is detailed later on in this document but for now all we need to know is that it is setting the value of ``guestName`` to "John".
.. note:: Implicit expressions do not have trailing semicolons.


Explicit
~~~~~~~~
Sometimes you need to render variables without any space in between it and
surrounding text. This is where explicit expressions come in. With explicit
expressions you surround the variable name with parenthesis to explicitly
show that it is an expression instead of random text.

.. code-block:: C#

  <h2>@(MajorVersion)@(MinorVersion)</h2>

Explicit expressions are evaluated like regular C#, as such it is possible
to render math, and much more.

.. code-block:: C#

  <p>@(1 + 1) = 1 + 1</p>


Tag Helpers
-----------
A Tag Helper is server-sided code that helps in the construction of HTML.
Information on Tag Helpers can be found in the Tag Helper documentation.
:doc:`tag-helpers/index`


Encoding
--------
Rendered data is by default encoded so that any non-text characters will be
escaped. To render unencoded HTML use ``@Html.Raw``.

.. code-block:: C#

  @Html.Raw(SuperSpecialHTML)
  @(Html.Raw(SuperSpecialHTML))

``@Html.Raw`` is a Razor HTML Helper, for more information on them see
:doc:`html-helpers`.


Code Blocks
-----------
Code blocks are a fundamental element of Razor. A code block is a section where
C# code has been inserted directly into the HTML. It follows the same rules
that a normal C# block does, and in addition it can not contain any functions.

.. code-block:: C#

  @{
    var foo = 123;
  }

The combination of code blocks and implicit expressions allow variables to be
created and used.

.. code-block:: C#

  <div id="greeting">
    @{
      var guestName = "John";
    }

    <h2>Greetings @guestName</h2>
  </div>

You can mix plain text, and HTML inside of a code block by using HTML tags and
the ``<text>`` tag. The ``<text>`` tag is a placeholder tag that is used to
indicate that the enclosed content is text and should not be parsed as C# code.

.. code-block:: C#

  @{
    var title = "Hello!";
    <h1>@title</h1>

    var body = "some text not sitting inside of a tag";
    <text>@body</text>
  }


Control Structures
------------------
A lot of the power behind Razor comes from the ability to have control structures
inside of your markup. C# control structures such as ``foreach``, ``if``,
``using``, etc are available with Razor.

.. code-block:: C#

  @if(Model.IsRenderable){
    <ul>
    @foreach(var item in Model.Items){
      <li>@item.Name</li>
    }
    </ul>
  }


Comments
--------
The Razor ``@* *@`` comment block is analogous to the C# ``/* */`` comment
block:

.. code-block:: C#

  @*
    Some comment
  *@


Application Relative Paths
--------------------------
Razor has the ability to use application relative paths which are relative paths
starting at the project root. Razor will replace the relative paths inside of
HTML tag attributes and with the correct absolute path.

.. code-block:: C#

  <a href="~/Home">Home page</a>
  <script type='text/javascript' src="~/some.js">

This only works for attributes that are defined in HTML5 as urls. If you want
to resolve a path in an attribute not defined as a url you can use

.. code-block:: HTML

  <a cust-attr="@Url.Content("~/the-url")" href="#">Link</a>


Tag Attributes
--------------
Razor makes it easy to have programmatic classes and ids for you HTML tags.

.. code-block:: C#

  @{
    var anchorClass = "dark link";
    var anchorId = "main-link";
  }

  <a href="#" class="@anchorClass" id="@anchorId">Link</a>

The output for this markup is below.

.. code-block:: HTML

  <a href="#" class="dark link" id="main-link">Link</a>

.. note:: Variables can be used in any attribute not just class or id.

When the value you pass into an attribute is ``null`` or boolean ``false``, Razor will
remove that attribute completly.

.. code-block:: C#

  @{
    string classes = null;
  }

  <a href="#" class="@classes">Link</a>

.. code-block:: Html

  <a href="#">Link</a>

If a value is removed in this fashion, any space between the value and another
value will be removed.

.. code-block:: C#

  @{
    string classes = null;
  }

  <a href="#" class="bootstrap-anchor @classes">Link</a>

.. code-block:: Html

  <a href="#" class="bootstrap-anchor">Link</a>


If you want the attribute to exist, but to be empty then you use an empty string.

.. code-block:: C#

  @{
    string classes = "";
  }

  <a href="#" class="@classes">Link</a>

.. code-block:: Html

  <a href="#" class="">Link</a>

It doesn't just work with strings, but boolean values as well. This is useful
for programatically disabling input fields, checking checkboxes, etc. When a
boolean value in an attribute is true, the variable will be replaced with the
name of the attribute. When false the attribute will be removed.

.. code-block:: C#

  @{
    bool agree = true;
    bool disabled = true;
  }

  <input type="checkbox" name="agree" value="agree" checked="@agree"/>
  <input type="checkbox" name="option" value="option" disabled="@disabled"/>

.. code-block:: HTML

  <input type="checkbox" name="agree" value="agree" checked="checked"/>
  <input type="checkbox" name="option" value="option" disabled="disabled"/>

This behavior with booleans only works when there is a single dynamic expression
inside of an attribute.



.. code-block:: C#

  <input custom="@true foo"/>
  <input custom="@null @null"/>

.. code-block:: HTML

  <input custom="True foo"/>
  <input custom=""/>

Layouts
-------
To get a consistent look on a page it is often desirable to reuse HTML. This can
be done through layouts. A layout is a template that Razor will use to construct
each page. A Layout contains ``@RenderBody()`` and markup.


Layout
~~~~~~
.. code-block:: HTML

  <html>
    <head>
      <title>title</title>
    </head>
    <body>
      @RenderBody()
    </body>
  </html>

To use the layout the views layout must be set to the specified layout. This is
done by setting the ``Layout`` variable in the view.

View
~~~~
.. code-block:: HTML

  @{Layout = "~/Views/SomeLayout.cshtml";}
  <h1>Some Title</h1>
  <p>Some Content</p>

When rendering the page Razor takes the layout and replaces ``@RenderBody()``
with the contents of the view. By default a view will attempt to use the layout
at ``~/Views/Shared/_Layout.cshmtl``.

Output
~~~~~~

.. code-block:: HTML

  <html>
    <head>
      <title>title</title>
    </head>
    <body>
      <h1>Some Title</h1>
      <p>Some Content</p>
    </body>
  </html>

Razor Directives
----------------
A Razor directive is a bit of code that isn't valid HTML or C# code, instead
it provides instruction to Razor on how to perform certain actions.


@model
~~~~~~
The ``@model`` directive is a way to indicate what model the view is using. Just
place it at the top of the view along with the type of the model.

.. code-block:: C#

  @model Example.Models.Book

Later on in the document you can use implicit and explicit expressions to render
properties and method of that model via ``@Model.SomeProperty`` or
``@Model.SomeMethod()``.

.. code-block:: C#

  ISBN: @Model.ISBN
  Author: @Model.AuthorName()


@using
~~~~~~
The ``@using`` directive is the Razor equivalent of the C# ``using`` statement.

.. code-block:: C#

  @using Example.Models


@functions
~~~~~~~~~~
A ``@function`` block is a specific type of code block, that unlike a normal
code block can contain functions. They are commonly used to contain
reusable display related code inside of the view.

.. code-block:: C#

  @functions {
    string doFoo(int times){
      string out = "";
      for(int i = 0; i < times; i++)
        out += "Foo ";

      return out;
    }
  }

  <p>@doFoo(1)</p>
  <h1>@doFoo(3)</h1>

.. code-block:: HTML

  <p>Foo </p>
  <h1>Foo Foo </h1>


@injects
~~~~~~~~
Razor now supports dependency injection. View specific services can be injected
independent of the controller.

.. code-block:: C#

  @inject IInjectedServiceInterface InjectedServiceName

A more in depth guide can be found here :doc:`dependency-injection`


@await
~~~~~~
Razor can render the results of an asynchronous method call through
the use of ``@await Awaitable``

.. code-block:: C#

  <p>@await GetNameAsync()</p>
  <p>@await Task.FromResult("Foo")</p>

In addition, inside of the layout file you can flush the page. The logic behind
this is so that while the main content of your page is being processed and built
by Razor, important sections containing css or your navbar can be sent out ahead
early.

.. code-block:: C#

  @await FlushAsync()


@inherits
~~~~~~~~~
``@inherits`` Allows you to override the class that view inherits from. By
default the view inherits from ``Microsoft.AspNet.Mvc.Razor.RazorPage``.

.. code-block:: C#

  @inherits MyCustomRazorPage

In addition, ``@inherits`` allows you to specify the model as well.

  @inherits MyCustomRazorPage<Model>


@section
~~~~~~~~
Sections are used in conjuction with layouts. In one view you might wish to add
a script to the master page. Sections are how this is achieved.

Layout
++++++
.. code-block:: C#

  <html>
    <head>
      @RenderSection("styles", false)
    </head>

    <body>
      @RenderBody()
    </body>

    @RenderSection("scripts", false)
  </html>

Inside of the layout, ``@RenderSection()`` must be used to tell razor to render
the specified section. The first parameter is the name of the section, and the
second parameter if true, requires all views to contain the specified section.

View
++++
.. code-block:: C#

  <h1>Hello</h1>
  <p>Text</p>
  @section scripts {
    <script>...</script>
  }

  @section styles {
    <style>...</style>
  }

A section is denoted by ``@section`` folowed by the name of the section, and an
open and close brace. Any code inside is rendered by the ``@RenderSection()``
call.

Output
++++++

.. code-block:: HTML

  <html>
    <head>
      <style>...</style>
    </head>

    <body>
      <h1>Hello</h1>
      <p>Text</p>
    </body>

    <script>...</script>
  </html>
