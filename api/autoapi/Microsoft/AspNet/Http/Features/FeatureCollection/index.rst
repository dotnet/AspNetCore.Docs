

FeatureCollection Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.FeatureCollection`








Syntax
------

.. code-block:: csharp

   public class FeatureCollection : IFeatureCollection, IEnumerable<KeyValuePair<Type, object>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/FeatureCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.FeatureCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.FeatureCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.FeatureCollection.FeatureCollection()
    
        
    
        
        .. code-block:: csharp
    
           public FeatureCollection()
    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.FeatureCollection.FeatureCollection(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type defaults: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public FeatureCollection(IFeatureCollection defaults)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.FeatureCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.FeatureCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.Type,System.Object}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Features.FeatureCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.FeatureCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.FeatureCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.FeatureCollection.Item[System.Type]
    
        
        
        
        :type key: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object this[Type key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.FeatureCollection.Revision
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual int Revision { get; }
    

