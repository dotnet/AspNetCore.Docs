

IFilterFactory Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IFilterFactory : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IFilterFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IFilterFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IFilterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IFilterFactory.CreateInstance(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

