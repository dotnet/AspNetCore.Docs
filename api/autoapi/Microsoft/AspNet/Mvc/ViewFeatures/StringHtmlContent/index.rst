

StringHtmlContent Class
=======================



.. contents:: 
   :local:



Summary
-------

String content which gets encoded when written.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.StringHtmlContent`








Syntax
------

.. code-block:: csharp

   public class StringHtmlContent : IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/StringHtmlContent.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.StringHtmlContent

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.StringHtmlContent
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.StringHtmlContent.StringHtmlContent(System.String)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ViewFeatures.StringHtmlContent`
    
        
        
        
        :param input: to be HTML encoded when  is called.
        
        :type input: System.String
    
        
        .. code-block:: csharp
    
           public StringHtmlContent(string input)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.StringHtmlContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringHtmlContent.WriteTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public void WriteTo(TextWriter writer, IHtmlEncoder encoder)
    

