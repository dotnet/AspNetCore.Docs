

QueryFeature Class
==================





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
* :dn:cls:`Microsoft.AspNetCore.Http.Features.QueryFeature`








Syntax
------

.. code-block:: csharp

    public class QueryFeature : IQueryFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.QueryFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.QueryFeature

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.QueryFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.QueryFeature.QueryFeature(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public QueryFeature(IFeatureCollection features)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.QueryFeature.QueryFeature(Microsoft.AspNetCore.Http.IQueryCollection)
    
        
    
        
        :type query: Microsoft.AspNetCore.Http.IQueryCollection
    
        
        .. code-block:: csharp
    
            public QueryFeature(IQueryCollection query)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.QueryFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.QueryFeature.Query
    
        
        :rtype: Microsoft.AspNetCore.Http.IQueryCollection
    
        
        .. code-block:: csharp
    
            public IQueryCollection Query { get; set; }
    

