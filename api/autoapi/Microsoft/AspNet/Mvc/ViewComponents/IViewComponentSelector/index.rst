

IViewComponentSelector Interface
================================



.. contents:: 
   :local:



Summary
-------

Selects a View Component based on a View Component name.











Syntax
------

.. code-block:: csharp

   public interface IViewComponentSelector





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/IViewComponentSelector.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector.SelectComponent(System.String)
    
        
    
        Selects a View Component based on ``componentName``.
    
        
        
        
        :param componentName: The View Component name.
        
        :type componentName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor" />, or <c>null</c> if no match is found.
    
        
        .. code-block:: csharp
    
           ViewComponentDescriptor SelectComponent(string componentName)
    

