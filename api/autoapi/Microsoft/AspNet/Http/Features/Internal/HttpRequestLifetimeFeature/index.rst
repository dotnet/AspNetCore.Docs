

HttpRequestLifetimeFeature Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.HttpRequestLifetimeFeature`








Syntax
------

.. code-block:: csharp

   public class HttpRequestLifetimeFeature : IHttpRequestLifetimeFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/HttpRequestLifetimeFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpRequestLifetimeFeature

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.HttpRequestLifetimeFeature.Abort()
    
        
    
        
        .. code-block:: csharp
    
           public void Abort()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestLifetimeFeature.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public CancellationToken RequestAborted { get; set; }
    

