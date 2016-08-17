Razor Syntax Reference
===========================
`Taylor Mullen <https://twitter.com/ntaylormullen>`__ and `Rick Anderson`_

.. contents:: Sections
  :local:
  :depth: 1

What is Razor?
--------------
Razor is a markup syntax for embedding server based code into web pages. The Razor syntax consists of Razor markup, C# and HTML. Files containing Razor generally have a *.cshtml* file extension.

Rendering HTML
--------------

The default Razor language is HTML. Rendering HTML from Razor is no different than in an HTML file. A Razor file with the following markup:

.. code-block:: html

  <p>Hello World</p>

Is rendered unchanged as ``<p>Hello World</p>`` by the server.

Razor syntax
----------------------

Razor supports C# and uses the ``@`` symbol to transition from HTML to C#. Razor evaluates C# expressions and renders them in the HTML output. Razor can transition from HTML into C# or into Razor specific markup. When an ``@`` symbol is followed by a :ref:`Razor reserved keyword <razor-reserved-keywords-label>` it transitions into Razor specific markup, otherwise it transitions into plain C# .

.. _escape-at-label:

HTML containing ``@`` symbols may need to be escaped with a second ``@`` symbol. For example:

.. code-block:: html

 <p>@@Username</p>

would render the following HTML:

.. code-block:: html

 <p>@Username</p>

.. _razor-email-ref:

HTML attributes and content containing email addresses don’t treat the ``@`` symbol as a transition character.

 ``<a href="mailto:Support@contoso.com">Support@contoso.com</a>``

Implicit Razor expressions
---------------------------

Implicit Razor expressions start with ``@`` followed by C# code. For example:

.. code-block:: html

  <p>@DateTime.Now</p>
  <p>@DateTime.IsLeapYear(2016)</p>

With the exception of the C# ``await`` keyword implicit expressions must not contain spaces. For example, you can intermingle spaces as long as the C# statement has a clear ending:

.. code-block:: html

  <p>@await DoSomething("hello", "world")</p>

.. _explicit-razor-expressions:

Explicit Razor expressions
----------------------------

Explicit Razor expressions consists of an @ symbol with balanced parenthesis. For example, to render last weeks’ time:

.. code-block:: html

  <p>Last week this time: @(DateTime.Now - TimeSpan.FromDays(7))</p>

Any content within the @() parenthesis is evaluated and rendered to the output.

Implicit expressions generally cannot contain spaces. For example, in the code below, one week is not subtracted from the current time:

.. literalinclude:: razor/sample/Views/Home/Contact.cshtml
  :language: html
  :start-after: @* End of greeting *@
  :end-before: @*Add () to get correct time.*@

Which renders the following HTML:

.. code-block:: html

  <p>Last week: 7/7/2016 4:39:52 PM - TimeSpan.FromDays(7)</p>

You can use an explicit expression to concatenate text with an expression result:

.. code-block:: none
  :emphasize-lines: 5

  @{
      var joe = new Person("Joe", 33);
   }

  <p>Age@(joe.Age)</p>

Without the explicit expression, ``<p>Age@joe.Age</p>`` would be treated as an email address and ``<p>Age@joe.Age</p>`` would be rendered. When written as an explicit expression, ``<p>Age33</p>`` is rendered.

.. _expression-encoding-label:

Expression encoding
-------------------

C# expressions that evaluate to a string are HTML encoded. C# expressions that evaluate to :dn:iface:`~Microsoft.AspNetCore.Html.IHtmlContent` are rendered directly through `IHtmlContent.WriteTo`. C# expressions that don't evaluate to `IHtmlContent` are converted to a string (by `ToString`) and encoded before they are rendered. For example, the following Razor markup:

.. code-block:: html

  @("<span>Hello World</span>")

Renders this HTML:

.. code-block:: html

  &lt;span&gt;Hello World&lt;/span&gt;

Which the browser renders as:

``<span>Hello World</span>``

:dn:cls:`~Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper` :dn:method:`~Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.Raw` output is not encoded but rendered as HTML markup.

.. warning:: Using ``HtmlHelper.Raw`` on unsanitized user input is a security risk. User input might contain malicious JavaScript or other exploits. Sanitizing user input is difficult, avoid using ``HtmlHelper.Raw`` on user input.

The following Razor markup:

.. code-block:: html

  @Html.Raw("<span>Hello World</span>")

Renders this HTML:

.. code-block:: html

  <span>Hello World</span>

.. _razor-code-blocks-label:

Razor code blocks
------------------

Razor code blocks start with ``@`` and are enclosed by ``{}``. Unlike expressions, C# code inside code blocks is not rendered. Code blocks and expressions in a Razor page share the same scope and are defined in order (that is, declarations in a code block will be in scope for later code blocks and expressions).

.. code-block:: none

  @{
      var output = "Hello World";
  }

  <p>The rendered result: @output</p>

Would render:

.. code-block:: html

  <p>The rendered result: Hello World</p>

.. _implicit-transitions-label:

Implicit transitions
^^^^^^^^^^^^^^^^^^^^^

The default language in a code block is C#, but you can transition back to HTML. HTML within a code block will transition back into rendering HTML:

.. code-block:: none

  @{
      var inCSharp = true;
      <p>Now in HTML, was in C# @inCSharp</p>
  }

.. _explicit-delimited-transition-label:

Explicit delimited transition
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To define a sub-section of a code block that should render HTML, surround the characters to be rendered with the Razor ``<text>`` tag:

.. code-block:: none
  :emphasize-lines: 4

  @for (var i = 0; i < people.Length; i++)
  {
      var person = people[i];
      <text>Name: @person.Name</text>
  }

You generally use this approach when you want to render HTML that is not surrounded by an HTML tag. Without an HTML or Razor tag, you get a Razor runtime error.

.. _explicit-line-transition-with-label:

Explicit Line Transition with ``@:``
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To render the rest of an entire line as HTML inside a code block, use the ``@:`` syntax:

.. code-block:: none
  :emphasize-lines: 4

  @for (var i = 0; i < people.Length; i++)
  {
      var person = people[i];
      @:Name: @person.Name
  }

Without the ``@:`` in the code above, you'd get a Razor run time error.

.. _control-structures-razor-label:

Control Structures
------------------

Control structures are an extension of code blocks. All aspects of code blocks (transitioning to markup, inline C#) also apply to the following structures.

Conditionals ``@if``, ``else if``, ``else`` and ``@switch``
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The ``@if`` family controls when code runs:

.. code-block:: none

  @if (value % 2 == 0)
  {
      <p>The value was even</p>
  }

``else`` and ``else if`` don't require the ``@`` symbol:

.. code-block:: none

 @if (value % 2 == 0)
 {
     <p>The value was even</p>
 }
 else if (value >= 1337)
 {
     <p>The value is large.</p>
 }
 else
 {
     <p>The value was not large and is odd.</p>
 }

You can use a switch statement like this:

.. code-block:: none

 @switch (value)
 {
     case 1:
         <p>The value is 1!</p>
         break;
     case 1337:
         <p>Your number is 1337!</p>
         break;
     default:
         <p>Your number was not 1 or 1337.</p>
         break;
 }

Looping ``@for``, ``@foreach``, ``@while``, and ``@do while``
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You can render templated HTML with looping control statements. For example, to render a list of people:

.. code-block:: none

  @{
      var people = new Person[]
      {
            new Person("John", 33),
            new Person("Doe", 41),
      };
  }

You can use any of the following looping statements:

``@for``

.. code-block:: none

  @for (var i = 0; i < people.Length; i++)
  {
      var person = people[i];
      <p>Name: @person.Name</p>
      <p>Age: @person.Age</p>
  }

``@foreach``

.. code-block:: none

  @foreach (var person in people)
  {
      <p>Name: @person.Name</p>
      <p>Age: @person.Age</p>
  }

``@while``

.. code-block:: none

  @{ var i = 0; }
  @while (i < people.Length)
  {
      var person = people[i];
      <p>Name: @person.Name</p>
      <p>Age: @person.Age</p>

      i++;
  }

``@do while``

.. code-block:: none

  @{ var i = 0; }
  @do
  {
      var person = people[i];
      <p>Name: @person.Name</p>
      <p>Age: @person.Age</p>

      i++;
  } while (i < people.Length);

Compound ``@using``
^^^^^^^^^^^^^^^^^^^^

In C# a using statement is used to ensure an object is disposed. In Razor this same mechanism can be used to create :doc:`HTML helpers </mvc/views/html-helpers>` that contain additional content. For instance, we can utilize :doc:`/mvc/views/html-helpers` to render a form tag with the ``@using`` statement:

.. code-block:: none

  @using (Html.BeginForm())
  {
      <div>
          email:
          <input type="email" id="Email" name="Email" value="" />
          <button type="submit"> Register </button>
      </div>
  }

You can also perform scope level actions like the above with :doc:`/mvc/views/tag-helpers/index`.

``@try``, ``catch``, ``finally``
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Exception handling is similar to  C#:

.. literalinclude:: razor/sample/Views/Home/Contact7.cshtml
  :language: html

``@lock``
^^^^^^^^^

Razor has the capability to protect critical sections with lock statements:

.. code-block:: none

  @lock (SomeLock)
  {
      // Do critical section work
  }

Comments
^^^^^^^^^^

Razor supports C# and HTML comments. The following markup:

.. code-block:: none

  @{
      /* C# comment. */
      // Another C# comment.
  }
  <!-- HTML comment -->

Is rendered by the server as:

.. code-block:: none

  <!-- HTML comment -->

Razor comments are removed by the server before the page is rendered. Razor uses ``@*  *@`` to delimit comments. The following code is commented out, so the server will not render any markup:

.. code-block:: none

    @*
    @{
        /* C# comment. */
        // Another C# comment.
    }
    <!-- HTML comment -->
   *@

.. _razor-directives-label:

Directives
-----------
Razor directives are represented by implicit expressions with reserved keywords following the ``@`` symbol. A directive will typically change the way a page is parsed or enable different functionality within your Razor page.

Understanding how Razor generates code for a view will make it easier to understand how directives work. A Razor page is used to generate a C# file. For example, this Razor page:

.. literalinclude:: razor/sample/Views/Home/Contact8.cshtml
  :language: html

Generates a class similar to the following:

.. code-block:: c#

  public class _Views_Something_cshtml : RazorPage<dynamic>
  {
      public override async Task ExecuteAsync()
      {
          var output = "Hello World";

          WriteLiteral("/r/n<div>Output: ");
          Write(output);
          WriteLiteral("</div>");
      }
  }

:ref:`razor-customcompilationservice-label` explains how to view this generated class.

``@using``
^^^^^^^^^^^^^

The ``@using`` directive will add the c# ``using`` directive to the generated razor page:

.. literalinclude:: razor/sample/Views/Home/Contact9.cshtml
  :language: html

``@model``
^^^^^^^^^^^^

The ``@model`` directive allows you to specify the type of the model passed to your Razor page. It uses the following syntax:

.. code-block:: none

  @model TypeNameOfModel

For example, if you create an ASP.NET Core MVC app with individual user accounts, the *Views/Account/Login.cshtml* Razor view contains the following model declaration:

.. code-block:: c#

  @model LoginViewModel

In the class example in :ref:`razor-directives-label`, the class generated inherits from ``RazorPage<dynamic>``. By adding an ``@model`` you control what’s inherited. For example

.. code-block:: c#

  @model LoginViewModel

Generates the following class

.. code-block:: c#

 public class _Views_Account_Login_cshtml : RazorPage<LoginViewModel>

Razor pages expose a ``Model`` property for accessing the model passed to the page.

.. code-block:: html

  <div>The Login Email: @Model.Email</div>

The ``@model`` directive specified the type of this property (by specifying the ``T`` in ``RazorPage<T>`` that the generated class for your page derives from). If you don't specify the ``@model`` directive the ``Model`` property will be of type ``dynamic``. The value of the model is passed from the controller to the view. See :ref:`strongly-typed-models-keyword-label` for more information.

``@inherits``
^^^^^^^^^^^^^^^

The ``@inherits`` directive gives you full control of the class your Razor page inherits:

.. code-block:: none

 @inherits TypeNameOfClassToInheritFrom

For instance, let’s say we had the following custom Razor page type:

.. literalinclude:: razor/sample/Classes/CustomRazorPage.cs
  :language: c#

The following Razor would generate ``<div>Custom text: Hello World</div>``.

.. literalinclude:: razor/sample/Views/Home/Contact10.cshtml
  :language: html

You can't use ``@model`` and ``@inherits`` on the same page. You can have ``@inherits`` in a *_ViewImports.cshtml* file that the Razor page imports. For example, if your Razor view imported the following *_ViewImports.cshtml* file:

.. literalinclude:: razor/sample/Views/_ViewImportsModel.cshtml
  :language: html

The following strongly typed Razor page

.. literalinclude:: razor/sample/Views/Home/Login1.cshtml
  :language: html

Generates this HTML markup:

.. code-block:: none

  <div>The Login Email: Rick@contoso.com</div>
  <div>Custom text: Hello World</div>

When passed "Rick@contoso.com" in the model:

 See :doc:`/mvc/views/layout` for more information.

``@inject``
^^^^^^^^^^^^^^
The ``@inject`` directive enables you to inject a service from your :doc:`service container </fundamentals/dependency-injection>`  into your Razor page for use. See :doc:`/mvc/views/dependency-injection`.

``@functions``
^^^^^^^^^^^^^^

The ``@functions`` directive enables you to add function level content to your Razor page. The syntax is:

.. code-block:: none

  @functions { // C# Code }

For example:

.. literalinclude:: razor/sample/Views/Home/Contact6.cshtml
  :language: html

Generates the following HTML markup:

.. code-block:: none

  <div>From method: Hello</div>

The generated Razor C# looks like:

.. literalinclude:: razor/sample/Classes/Views_Home_Test_cshtml.cs
  :language: c#
  :lines: 1-19

``@section``
^^^^^^^^^^^^^^

The ``@section`` directive is used in conjunction with the :doc:`layout page </mvc/views/layout>` to enable views to render content in different parts of the rendered HTML page. See :ref:`layout-sections-label` for more information.


TagHelpers
-----------

The following :doc:`/mvc/views/tag-helpers/index` directives are detailed in the links provided.

- :ref:`@addTagHelper <add-helper-label>`
- :ref:`@removeTagHelper <remove-razor-directives-label>`
- :ref:`@tagHelperPrefix <prefix-razor-directives-label>`

.. _razor-reserved-keywords-label:

Razor reserved keywords
------------------------

Razor keywords
^^^^^^^^^^^^^^^

- functions
- inherits
- model
- section
- helper   (Not supported by ASP.NET Core.)

Razor keywords can be escaped with ``@(Razor Keyword)``, for example ``@(functions)``. See the complete sample below.

C# Razor keywords
^^^^^^^^^^^^^^^^^^

- case
- do
- default
- for
- foreach
- if
- lock
- switch
- try
- using
- while

C# Razor keywords need to be double escaped with ``@(@C# Razor Keyword)``, for example ``@(@case)``. The first ``@`` escapes the Razor parser, the second ``@`` escapes the C# parser. See the complete sample below.

Reserved keywords not used by Razor
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

- namespace
- class

.. _razor-customcompilationservice-label:

Viewing the Razor C# class generated for a view
------------------------------------------------

Add the following class to your ASP.NET Core MVC project:

.. literalinclude:: razor/sample/Services/CustomCompilationService.cs

Override the :dn:iface:`~Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService` added by MVC with the above class;

.. literalinclude:: razor/sample/Startup.cs
  :start-after:  Use this method to add services to the container.
  :end-before:  // This method gets called by the runtime.
  :dedent: 8
  :emphasize-lines: 4

Set a break point on the ``Compile`` method of ``CustomCompilationService`` and view ``compilationContent``.

.. image:: razor/_static/tvr.png
  :scale: 100
  :alt: Text Visualizer view of compilationContent
