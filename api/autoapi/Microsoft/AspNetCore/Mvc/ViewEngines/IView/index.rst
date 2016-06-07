

IView Interface
===============






Specifies the contract for a view.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewEngines`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IView








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.IView

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewEngines.IView.Path
    
        
    
        
        Gets the path of the view as resolved by the :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Path
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.IView.RenderAsync(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        Asynchronously renders the view using the specified <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that on completion renders the view.
    
        
        .. code-block:: csharp
    
            Task RenderAsync(ViewContext context)
    

