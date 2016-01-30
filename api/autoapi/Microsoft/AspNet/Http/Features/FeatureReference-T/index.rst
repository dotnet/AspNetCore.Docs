

FeatureReference<T> Struct
==========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct FeatureReference<T>





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/FeatureReference.cs>`_





.. dn:structure:: Microsoft.AspNet.Http.Features.FeatureReference<T>

Methods
-------

.. dn:structure:: Microsoft.AspNet.Http.Features.FeatureReference<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.FeatureReference<T>.Fetch(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T Fetch(IFeatureCollection features)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.FeatureReference<T>.Update(Microsoft.AspNet.Http.Features.IFeatureCollection, T)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
        
        
        :type feature: {T}
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T Update(IFeatureCollection features, T feature)
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Http.Features.FeatureReference<T>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Http.Features.FeatureReference<T>.Default
    
        
    
        
        .. code-block:: csharp
    
           public static readonly FeatureReference<T> Default
    

