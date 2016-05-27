

IRazorPageActivator Interface
=============================






Provides methods to activate properties on a :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instance.


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

    public interface IRazorPageActivator








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator.Activate(Microsoft.AspNetCore.Mvc.Razor.IRazorPage, Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        When implemented in a type, activates an instantiated page.
    
        
    
        
        :param page: The page to activate.
        
        :type page: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` for the executing view.
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            void Activate(IRazorPage page, ViewContext context)
    

