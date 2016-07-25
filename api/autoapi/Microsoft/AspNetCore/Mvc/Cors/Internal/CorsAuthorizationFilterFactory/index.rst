

CorsAuthorizationFilterFactory Class
====================================






A filter factory which creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Cors.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory`








Syntax
------

.. code-block:: csharp

    public class CorsAuthorizationFilterFactory : IFilterFactory, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory.CorsAuthorizationFilterFactory(System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory`\.
    
        
    
        
        :param policyName: Name used to fetch a CORS policy.
        
        :type policyName: System.String
    
        
        .. code-block:: csharp
    
            public CorsAuthorizationFilterFactory(string policyName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory.CreateInstance(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

