

TemplateBuilder Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateBuilder`








Syntax
------

.. code-block:: csharp

   public class TemplateBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/TemplateBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateBuilder.TemplateBuilder(Microsoft.AspNet.Mvc.ViewEngines.IViewEngine, Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Boolean, System.Object)
    
        
        
        
        :type viewEngine: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type htmlFieldName: System.String
        
        
        :type templateName: System.String
        
        
        :type readOnly: System.Boolean
        
        
        :type additionalViewData: System.Object
    
        
        .. code-block:: csharp
    
           public TemplateBuilder(IViewEngine viewEngine, ViewContext viewContext, ViewDataDictionary viewData, ModelExplorer modelExplorer, string htmlFieldName, string templateName, bool readOnly, object additionalViewData)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateBuilder.Build()
    
        
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Build()
    

