

CorsApplicationModelProvider Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Cors.CorsApplicationModelProvider`








Syntax
------

.. code-block:: csharp

   public class CorsApplicationModelProvider : IApplicationModelProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Cors/CorsApplicationModelProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsApplicationModelProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Cors.CorsApplicationModelProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuted(ApplicationModelProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Cors.CorsApplicationModelProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuting(ApplicationModelProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Cors.CorsApplicationModelProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

