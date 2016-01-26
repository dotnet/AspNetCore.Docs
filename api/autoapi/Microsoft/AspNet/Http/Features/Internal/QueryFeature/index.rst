

QueryFeature Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.QueryFeature`








Syntax
------

.. code-block:: csharp

   public class QueryFeature : IQueryFeature, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/QueryFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.QueryFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.QueryFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.QueryFeature.QueryFeature(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public QueryFeature(IFeatureCollection features)
    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.QueryFeature.QueryFeature(Microsoft.AspNet.Http.IReadableStringCollection)
    
        
        
        
        :type query: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public QueryFeature(IReadableStringCollection query)
    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.QueryFeature.QueryFeature(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
        
        
        :type query: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public QueryFeature(IDictionary<string, StringValues> query)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.QueryFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.QueryFeature.Query
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public IReadableStringCollection Query { get; set; }
    

