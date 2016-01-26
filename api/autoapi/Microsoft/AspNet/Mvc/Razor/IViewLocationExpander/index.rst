

IViewLocationExpander Interface
===============================



.. contents:: 
   :local:



Summary
-------

Specifies the contracts for a view location expander that is used by :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine` instances to
determine search paths for a view.











Syntax
------

.. code-block:: csharp

   public interface IViewLocationExpander





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/IViewLocationExpander.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IViewLocationExpander

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IViewLocationExpander
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IViewLocationExpander.ExpandViewLocations(Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Invoked by a :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine` to determine potential locations for a view.
    
        
        
        
        :param context: The  for the current view location
            expansion operation.
        
        :type context: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
        
        
        :param viewLocations: The sequence of view locations to expand.
        
        :type viewLocations: System.Collections.Generic.IEnumerable{System.String}
        :rtype: System.Collections.Generic.IEnumerable{System.String}
        :return: A list of expanded view locations.
    
        
        .. code-block:: csharp
    
           IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IViewLocationExpander.PopulateValues(Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext)
    
        
    
        Invoked by a :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine` to determine the values that would be consumed by this instance
        of :any:`Microsoft.AspNet.Mvc.Razor.IViewLocationExpander`\. The calculated values are used to determine if the view location
        has changed since the last time it was located.
    
        
        
        
        :param context: The  for the current view location
            expansion operation.
        
        :type context: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
    
        
        .. code-block:: csharp
    
           void PopulateValues(ViewLocationExpanderContext context)
    

