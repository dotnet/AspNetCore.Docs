

FeatureCollection Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.FeatureCollection`








Syntax
------

.. code-block:: csharp

    public class FeatureCollection : IFeatureCollection, IEnumerable<KeyValuePair<Type, object>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Http.Features.FeatureCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.FeatureCollection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FeatureCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.FeatureCollection.FeatureCollection()
    
        
    
        
        .. code-block:: csharp
    
            public FeatureCollection()
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.FeatureCollection.FeatureCollection(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type defaults: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public FeatureCollection(IFeatureCollection defaults)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FeatureCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.Type<System.Type>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureCollection.Get<TFeature>()
    
        
        :rtype: TFeature
    
        
        .. code-block:: csharp
    
            public TFeature Get<TFeature>()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureCollection.Set<TFeature>(TFeature)
    
        
    
        
        :type instance: TFeature
    
        
        .. code-block:: csharp
    
            public void Set<TFeature>(TFeature instance)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FeatureCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FeatureCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FeatureCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FeatureCollection.Item[System.Type]
    
        
    
        
        :type key: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object this[Type key] { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FeatureCollection.Revision
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int Revision { get; }
    

