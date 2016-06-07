

UriBuilderContextPooledObjectPolicy Class
=========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Internal`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy`








Syntax
------

.. code-block:: csharp

    public class UriBuilderContextPooledObjectPolicy : IPooledObjectPolicy<UriBuildingContext>








.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy.UriBuilderContextPooledObjectPolicy(System.Text.Encodings.Web.UrlEncoder)
    
        
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            public UriBuilderContextPooledObjectPolicy(UrlEncoder encoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy.Create()
    
        
        :rtype: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext
    
        
        .. code-block:: csharp
    
            public UriBuildingContext Create()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuilderContextPooledObjectPolicy.Return(Microsoft.AspNetCore.Routing.Internal.UriBuildingContext)
    
        
    
        
        :type obj: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Return(UriBuildingContext obj)
    

