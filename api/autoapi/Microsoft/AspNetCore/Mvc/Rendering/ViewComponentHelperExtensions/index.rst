

ViewComponentHelperExtensions Class
===================================






Extension methods for :any:`Microsoft.AspNetCore.Mvc.IViewComponentHelper`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions`








Syntax
------

.. code-block:: csharp

    public class ViewComponentHelperExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions.InvokeAsync(Microsoft.AspNetCore.Mvc.IViewComponentHelper, System.String)
    
        
    
        
        Invokes a view component with the specified <em>name</em>.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.IViewComponentHelper`\.
        
        :type helper: Microsoft.AspNetCore.Mvc.IViewComponentHelper
    
        
        :param name: The name of the view component.
        
        :type name: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns the rendered :any:`Microsoft.AspNetCore.Html.IHtmlContent`\.
            
    
        
        .. code-block:: csharp
    
            public static Task<IHtmlContent> InvokeAsync(IViewComponentHelper helper, string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions.InvokeAsync(Microsoft.AspNetCore.Mvc.IViewComponentHelper, System.Type)
    
        
    
        
        Invokes a view component of type <em>componentType</em>.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.IViewComponentHelper`\.
        
        :type helper: Microsoft.AspNetCore.Mvc.IViewComponentHelper
    
        
        :param componentType: The view component :any:`System.Type`\.
        
        :type componentType: System.Type
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns the rendered :any:`Microsoft.AspNetCore.Html.IHtmlContent`\.
            
    
        
        .. code-block:: csharp
    
            public static Task<IHtmlContent> InvokeAsync(IViewComponentHelper helper, Type componentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions.InvokeAsync<TComponent>(Microsoft.AspNetCore.Mvc.IViewComponentHelper)
    
        
    
        
        Invokes a view component of type <em>TComponent</em>.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.IViewComponentHelper`\.
        
        :type helper: Microsoft.AspNetCore.Mvc.IViewComponentHelper
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns the rendered :any:`Microsoft.AspNetCore.Html.IHtmlContent`\.
            
    
        
        .. code-block:: csharp
    
            public static Task<IHtmlContent> InvokeAsync<TComponent>(IViewComponentHelper helper)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.ViewComponentHelperExtensions.InvokeAsync<TComponent>(Microsoft.AspNetCore.Mvc.IViewComponentHelper, System.Object)
    
        
    
        
        Invokes a view component of type <em>TComponent</em>.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.IViewComponentHelper`\.
        
        :type helper: Microsoft.AspNetCore.Mvc.IViewComponentHelper
    
        
        :param arguments: Arguments to be passed to the invoked view component method.
        
        :type arguments: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns the rendered :any:`Microsoft.AspNetCore.Html.IHtmlContent`\.
            
    
        
        .. code-block:: csharp
    
            public static Task<IHtmlContent> InvokeAsync<TComponent>(IViewComponentHelper helper, object arguments)
    

