

IFeatureCollection Interface
============================






Represents a collection of HTTP features.


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

    public interface IFeatureCollection : IEnumerable<KeyValuePair<Type, object>>, IEnumerable








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFeatureCollection

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IFeatureCollection.IsReadOnly
    
        
    
        
        Indicates if the collection can be modified.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsReadOnly
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IFeatureCollection.Item[System.Type]
    
        
    
        
        Gets or sets a given feature. Setting a null value removes the feature.
    
        
    
        
        :type key: System.Type
        :rtype: System.Object
        :return: The requested feature, or null if it is not present.
    
        
        .. code-block:: csharp
    
            object this[Type key]
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IFeatureCollection.Revision
    
        
    
        
        Incremented for each modification and can be used to verify cached results.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Revision
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IFeatureCollection.Get<TFeature>()
    
        
    
        
        Retrieves the requested feature from the collection.
    
        
        :rtype: TFeature
        :return: The requested feature, or null if it is not present.
    
        
        .. code-block:: csharp
    
            TFeature Get<TFeature>()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IFeatureCollection.Set<TFeature>(TFeature)
    
        
    
        
        Sets the given feature in the collection.
    
        
    
        
        :param instance: The feature value.
        
        :type instance: TFeature
    
        
        .. code-block:: csharp
    
            void Set<TFeature>(TFeature instance)
    

