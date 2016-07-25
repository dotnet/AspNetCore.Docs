

HtmlString Class
================






An :any:`Microsoft.AspNetCore.Html.IHtmlContent` implementation that wraps an HTML encoded :any:`System.String`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Html`
Assemblies
    * Microsoft.AspNetCore.Html.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Html.HtmlString`








Syntax
------

.. code-block:: csharp

    public class HtmlString : IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Html.HtmlString
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Html.HtmlString

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Html.HtmlString.HtmlString(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Html.HtmlString`\.
    
        
    
        
        :param value: The HTML encoded value.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public HtmlString(string value)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlString.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlString.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Html.HtmlString.Empty
    
        
    
        
        An :any:`Microsoft.AspNetCore.Html.HtmlString` instance for :dn:field:`System.String.Empty`\.
    
        
        :rtype: Microsoft.AspNetCore.Html.HtmlString
    
        
        .. code-block:: csharp
    
            public static readonly HtmlString Empty
    
    .. dn:field:: Microsoft.AspNetCore.Html.HtmlString.NewLine
    
        
    
        
        An :any:`Microsoft.AspNetCore.Html.HtmlString` instance for :dn:prop:`System.Environment.NewLine`\.
    
        
        :rtype: Microsoft.AspNetCore.Html.HtmlString
    
        
        .. code-block:: csharp
    
            public static readonly HtmlString NewLine
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Html.HtmlString.Value
    
        
    
        
        Gets the HTML encoded value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; }
    

