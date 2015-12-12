

IFeatureCollection Interface
============================



.. contents:: 
   :local:



Summary
-------

Represents a collection of HTTP features.











Syntax
------

.. code-block:: csharp

   public interface IFeatureCollection : IEnumerable<KeyValuePair<Type, object>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/IFeatureCollection.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IFeatureCollection

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IFeatureCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IFeatureCollection.IsReadOnly
    
        
    
        Indicates if the collection can be modified.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IFeatureCollection.Item[System.Type]
    
        
    
        Gets or sets a given feature. Setting a null value removes the feature.
    
        
        
        
        :type key: System.Type
        :rtype: System.Object
        :return: The requested feature, or null if it is not present.
    
        
        .. code-block:: csharp
    
           object this[Type key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IFeatureCollection.Revision
    
        
    
        Incremented for each modification and can be used to verify cached results.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Revision { get; }
    

