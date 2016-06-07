

IViewLocationExpander Interface
===============================






Specifies the contracts for a view location expander that is used by :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` instances to
determine search paths for a view.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewLocationExpander








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander.ExpandViewLocations(Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Invoked by a :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` to determine potential locations for a view.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext` for the current view location
            expansion operation.
        
        :type context: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext
    
        
        :param viewLocations: The sequence of view locations to expand.
        
        :type viewLocations: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :return: A list of expanded view locations.
    
        
        .. code-block:: csharp
    
            IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander.PopulateValues(Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext)
    
        
    
        
        Invoked by a :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` to determine the values that would be consumed by this instance
        of :any:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander`\. The calculated values are used to determine if the view location
        has changed since the last time it was located.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext` for the current view location
            expansion operation.
        
        :type context: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext
    
        
        .. code-block:: csharp
    
            void PopulateValues(ViewLocationExpanderContext context)
    

