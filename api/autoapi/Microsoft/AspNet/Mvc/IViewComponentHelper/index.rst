

IViewComponentHelper Interface
==============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IViewComponentHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/IViewComponentHelper.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.IViewComponentHelper

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.IViewComponentHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.Invoke(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           HtmlString Invoke(string name, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.Invoke(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           HtmlString Invoke(Type componentType, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.InvokeAsync(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type args: System.Object[]
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
    
        
        .. code-block:: csharp
    
           Task<HtmlString> InvokeAsync(string name, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.InvokeAsync(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type args: System.Object[]
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
    
        
        .. code-block:: csharp
    
           Task<HtmlString> InvokeAsync(Type componentType, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.RenderInvoke(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           void RenderInvoke(string name, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.RenderInvoke(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           void RenderInvoke(Type componentType, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.RenderInvokeAsync(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type args: System.Object[]
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RenderInvokeAsync(string name, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentHelper.RenderInvokeAsync(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type args: System.Object[]
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RenderInvokeAsync(Type componentType, params object[] args)
    

