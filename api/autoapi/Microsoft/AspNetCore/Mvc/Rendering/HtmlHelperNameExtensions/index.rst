

HtmlHelperNameExtensions Class
==============================






Name-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperNameExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperNameExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperNameExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperNameExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperNameExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperNameExtensions.IdForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper)
    
        
    
        
        Returns the HTML element Id for the current model.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
        :rtype: System.String
        :return: A :any:`System.String` containing the element Id.
    
        
        .. code-block:: csharp
    
            public static string IdForModel(this IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperNameExtensions.NameForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper)
    
        
    
        
        Returns the full HTML element name for the current model.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
        :rtype: System.String
        :return: A :any:`System.String` containing the element name.
    
        
        .. code-block:: csharp
    
            public static string NameForModel(this IHtmlHelper htmlHelper)
    

