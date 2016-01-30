

CorsAuthorizationFilterFactory Class
====================================



.. contents:: 
   :local:



Summary
-------

A filter factory which creates a new instance of :any:`Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory`








Syntax
------

.. code-block:: csharp

   public class CorsAuthorizationFilterFactory : IFilterFactory, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Cors/CorsAuthorizationFilterFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory.CorsAuthorizationFilterFactory(System.String)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory`\.
    
        
        
        
        :param policyName: Name used to fetch a CORS policy.
        
        :type policyName: System.String
    
        
        .. code-block:: csharp
    
           public CorsAuthorizationFilterFactory(string policyName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory.CreateInstance(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilterFactory.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

