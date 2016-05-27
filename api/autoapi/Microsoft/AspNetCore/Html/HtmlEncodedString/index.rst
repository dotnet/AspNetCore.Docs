

HtmlEncodedString Class
=======================






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
* :dn:cls:`Microsoft.AspNetCore.Html.HtmlEncodedString`








Syntax
------

.. code-block:: csharp

    public class HtmlEncodedString : IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Html.HtmlEncodedString
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Html.HtmlEncodedString

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlEncodedString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Html.HtmlEncodedString.Value
    
        
    
        
        Gets the HTML encoded value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlEncodedString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Html.HtmlEncodedString.HtmlEncodedString(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Html.HtmlEncodedString`\.
    
        
    
        
        :param value: The HTML encoded value.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public HtmlEncodedString(string value)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlEncodedString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Html.HtmlEncodedString.NewLine
    
        
    
        
        An :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance for :dn:prop:`System.Environment.NewLine`\.
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public static readonly IHtmlContent NewLine
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlEncodedString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlEncodedString.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlEncodedString.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

