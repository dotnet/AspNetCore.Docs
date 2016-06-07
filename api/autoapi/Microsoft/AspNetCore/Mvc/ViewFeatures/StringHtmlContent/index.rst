

StringHtmlContent Class
=======================






String content which gets encoded when written.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString()}")]
    public class StringHtmlContent : IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent.StringHtmlContent(System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent`
    
        
    
        
        :param input: :any:`System.String` to be HTML encoded when :dn:meth:`Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent.WriteTo(System.IO.TextWriter,System.Text.Encodings.Web.HtmlEncoder)` is called.
        
        :type input: System.String
    
        
        .. code-block:: csharp
    
            public StringHtmlContent(string input)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.StringHtmlContent.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

