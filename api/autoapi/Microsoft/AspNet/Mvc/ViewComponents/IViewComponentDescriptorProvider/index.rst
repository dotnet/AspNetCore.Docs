

IViewComponentDescriptorProvider Interface
==========================================



.. contents:: 
   :local:



Summary
-------

Discovers the View Components in the application.











Syntax
------

.. code-block:: csharp

   public interface IViewComponentDescriptorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/IViewComponentDescriptorProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider.GetViewComponents()
    
        
    
        Gets the set of :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor}
        :return: A list of <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor" />.
    
        
        .. code-block:: csharp
    
           IEnumerable<ViewComponentDescriptor> GetViewComponents()
    

