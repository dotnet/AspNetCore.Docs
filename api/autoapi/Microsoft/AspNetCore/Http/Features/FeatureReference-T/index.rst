

FeatureReference<T> Struct
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct FeatureReference<T>








.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReference`1
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReference<T>

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReference<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureReference<T>.Fetch(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T Fetch(IFeatureCollection features)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureReference<T>.Update(Microsoft.AspNetCore.Http.Features.IFeatureCollection, T)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        :type feature: T
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T Update(IFeatureCollection features, T feature)
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReference<T>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.Features.FeatureReference<T>.Default
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.FeatureReference<Microsoft.AspNetCore.Http.Features.FeatureReference`1>{T}
    
        
        .. code-block:: csharp
    
            public static readonly FeatureReference<T> Default
    

