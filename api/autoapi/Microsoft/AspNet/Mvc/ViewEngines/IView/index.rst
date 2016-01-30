

IView Interface
===============



.. contents:: 
   :local:



Summary
-------

Specifies the contract for a view.











Syntax
------

.. code-block:: csharp

   public interface IView





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewEngines/IView.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewEngines.IView

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewEngines.IView
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.IView.RenderAsync(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
    
        Asynchronously renders the view using the specified ``context``.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion renders the view.
    
        
        .. code-block:: csharp
    
           Task RenderAsync(ViewContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewEngines.IView
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewEngines.IView.Path
    
        
    
        Gets the path of the view as resolved by the :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Path { get; }
    

