

FeatureReferences<TCache> Struct
================================





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

    public struct FeatureReferences<TCache>








.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReferences`1
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>.Fetch<TFeature>(ref TFeature, System.Func<Microsoft.AspNetCore.Http.Features.IFeatureCollection, TFeature>)
    
        
    
        
        :type cached: TFeature
    
        
        :type factory: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.Features.IFeatureCollection<Microsoft.AspNetCore.Http.Features.IFeatureCollection>, TFeature}
        :rtype: TFeature
    
        
        .. code-block:: csharp
    
            public TFeature Fetch<TFeature>(ref TFeature cached, Func<IFeatureCollection, TFeature> factory)where TFeature : class
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>.Fetch<TFeature, TState>(ref TFeature, TState, System.Func<TState, TFeature>)
    
        
    
        
        :type cached: TFeature
    
        
        :type state: TState
    
        
        :type factory: System.Func<System.Func`2>{TState, TFeature}
        :rtype: TFeature
    
        
        .. code-block:: csharp
    
            public TFeature Fetch<TFeature, TState>(ref TFeature cached, TState state, Func<TState, TFeature> factory)where TFeature : class
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>.FeatureReferences(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type collection: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public FeatureReferences(IFeatureCollection collection)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>.Collection
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public IFeatureCollection Collection { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>.Revision
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Revision { get; }
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.Features.FeatureReferences<TCache>.Cache
    
        
        :rtype: TCache
    
        
        .. code-block:: csharp
    
            public TCache Cache
    

