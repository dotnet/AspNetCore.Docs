

IViewComponentDescriptorProvider Interface
==========================================






Discovers the view components in the application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewComponentDescriptorProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider.GetViewComponents()
    
        
    
        
        Gets the set of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor<Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor>}
        :return: A list of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.
    
        
        .. code-block:: csharp
    
            IEnumerable<ViewComponentDescriptor> GetViewComponents()
    

