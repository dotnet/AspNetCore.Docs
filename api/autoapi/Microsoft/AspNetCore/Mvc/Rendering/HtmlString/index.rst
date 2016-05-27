

HtmlString Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Html.HtmlEncodedString`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString`








Syntax
------

.. code-block:: csharp

    public class HtmlString : HtmlEncodedString, IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlString
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlString

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.HtmlString.HtmlString(System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString`\.
    
        
    
        
        :param input: The HTML encoded value.
        
        :type input: System.String
    
        
        .. code-block:: csharp
    
            public HtmlString(string input)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString` with empty content.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
            public static readonly HtmlString Empty
    

