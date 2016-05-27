

IViewComponentSelector Interface
================================






Selects a view component based on a view component name.


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

    public interface IViewComponentSelector








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector.SelectComponent(System.String)
    
        
    
        
        Selects a view component based on <em>componentName</em>.
    
        
    
        
        :param componentName: The view component name.
        
        :type componentName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\, or <code>null</code> if no match is found.
    
        
        .. code-block:: csharp
    
            ViewComponentDescriptor SelectComponent(string componentName)
    

