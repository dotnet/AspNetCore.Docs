

ICompositeViewEngine Interface
==============================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine` that delegates to one of a collection of view engines.











Syntax
------

.. code-block:: csharp

   public interface ICompositeViewEngine : IViewEngine





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewEngines/ICompositeViewEngine.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine.ViewEngines
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine` this instance of :any:`Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine` delegates
        to.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ViewEngines.IViewEngine}
    
        
        .. code-block:: csharp
    
           IReadOnlyList<IViewEngine> ViewEngines { get; }
    

