

ICompositeViewEngine Interface
==============================






Represents an :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine` that delegates to one of a collection of view engines.


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

    public interface ICompositeViewEngine : IViewEngine








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine.ViewEngines
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine` this instance of :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine` delegates
        to.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine<Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine>}
    
        
        .. code-block:: csharp
    
            IReadOnlyList<IViewEngine> ViewEngines { get; }
    

