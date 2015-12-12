

TemplateRenderer Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer`








Syntax
------

.. code-block:: csharp

   public class TemplateRenderer





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/TemplateRenderer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer.TemplateRenderer(Microsoft.AspNet.Mvc.ViewEngines.IViewEngine, Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.String, System.Boolean)
    
        
        
        
        :type viewEngine: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :type templateName: System.String
        
        
        :type readOnly: System.Boolean
    
        
        .. code-block:: csharp
    
           public TemplateRenderer(IViewEngine viewEngine, ViewContext viewContext, ViewDataDictionary viewData, string templateName, bool readOnly)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer.GetTypeNames(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.Type)
    
        
        
        
        :type modelMetadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :type fieldType: System.Type
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public static IEnumerable<string> GetTypeNames(ModelMetadata modelMetadata, Type fieldType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer.Render()
    
        
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Render()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.TemplateRenderer.IEnumerableOfIFormFileName
    
        
    
        
        .. code-block:: csharp
    
           public const string IEnumerableOfIFormFileName
    

