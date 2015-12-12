

IRazorPageActivator Interface
=============================



.. contents:: 
   :local:



Summary
-------

Provides methods to activate properties on a :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` instance.











Syntax
------

.. code-block:: csharp

   public interface IRazorPageActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/IRazorPageActivator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorPageActivator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorPageActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IRazorPageActivator.Activate(Microsoft.AspNet.Mvc.Razor.IRazorPage, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
    
        When implemented in a type, activates an instantiated page.
    
        
        
        
        :param page: The page to activate.
        
        :type page: Microsoft.AspNet.Mvc.Razor.IRazorPage
        
        
        :param context: The  for the executing view.
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           void Activate(IRazorPage page, ViewContext context)
    

