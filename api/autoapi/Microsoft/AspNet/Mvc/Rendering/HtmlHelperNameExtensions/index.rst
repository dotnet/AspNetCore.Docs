

HtmlHelperNameExtensions Class
==============================



.. contents:: 
   :local:



Summary
-------

Name-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperNameExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperNameExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperNameExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperNameExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperNameExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperNameExtensions.IdForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Returns the HTML element Id for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the element Id.
    
        
        .. code-block:: csharp
    
           public static string IdForModel(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperNameExtensions.NameForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Returns the full HTML element name for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the element name.
    
        
        .. code-block:: csharp
    
           public static string NameForModel(IHtmlHelper htmlHelper)
    

