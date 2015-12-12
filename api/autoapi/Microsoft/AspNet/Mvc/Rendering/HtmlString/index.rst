

HtmlString Class
================



.. contents:: 
   :local:



Summary
-------

String content which knows how to write itself.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlString`








Syntax
------

.. code-block:: csharp

   public class HtmlString : IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlString.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlString

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.HtmlString.HtmlString(System.String)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Rendering.HtmlString`\.
    
        
        
        
        :param input: string to initialize .
        
        :type input: System.String
    
        
        .. code-block:: csharp
    
           public HtmlString(string input)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlString.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlString.WriteTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public void WriteTo(TextWriter writer, IHtmlEncoder encoder)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty
    
        
    
        Returns an :any:`Microsoft.AspNet.Mvc.Rendering.HtmlString` with empty content.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly HtmlString Empty
    
    .. dn:field:: Microsoft.AspNet.Mvc.Rendering.HtmlString.NewLine
    
        
    
        Returns an :any:`Microsoft.AspNet.Mvc.Rendering.HtmlString` containing :dn:prop:`System.Environment.NewLine`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly HtmlString NewLine
    

