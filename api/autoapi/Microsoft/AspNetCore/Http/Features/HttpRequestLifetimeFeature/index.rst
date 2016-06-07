

HttpRequestLifetimeFeature Class
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature`








Syntax
------

.. code-block:: csharp

    public class HttpRequestLifetimeFeature : IHttpRequestLifetimeFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationToken RequestAborted
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public void Abort()
    

