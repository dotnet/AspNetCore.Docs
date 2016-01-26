

ViewComponentHelperExtensions Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.ViewComponentHelperExtensions`








Syntax
------

.. code-block:: csharp

   public class ViewComponentHelperExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/ViewComponentHelperExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ViewComponentHelperExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ViewComponentHelperExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.ViewComponentHelperExtensions.InvokeAsync<TComponent>(Microsoft.AspNet.Mvc.IViewComponentHelper, System.Object[])
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IViewComponentHelper
        
        
        :type args: System.Object[]
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
    
        
        .. code-block:: csharp
    
           public static Task<HtmlString> InvokeAsync<TComponent>(IViewComponentHelper helper, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.ViewComponentHelperExtensions.Invoke<TComponent>(Microsoft.AspNet.Mvc.IViewComponentHelper, System.Object[])
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IViewComponentHelper
        
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           public static HtmlString Invoke<TComponent>(IViewComponentHelper helper, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.ViewComponentHelperExtensions.RenderInvokeAsync<TComponent>(Microsoft.AspNet.Mvc.IViewComponentHelper, System.Object[])
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IViewComponentHelper
        
        
        :type args: System.Object[]
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public static Task RenderInvokeAsync<TComponent>(IViewComponentHelper helper, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.ViewComponentHelperExtensions.RenderInvoke<TComponent>(Microsoft.AspNet.Mvc.IViewComponentHelper, System.Object[])
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IViewComponentHelper
        
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void RenderInvoke<TComponent>(IViewComponentHelper helper, params object[] args)
    

