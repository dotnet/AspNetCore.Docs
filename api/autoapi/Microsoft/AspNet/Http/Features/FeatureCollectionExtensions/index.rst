

FeatureCollectionExtensions Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.FeatureCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class FeatureCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/FeatureCollectionExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.FeatureCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.FeatureCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.FeatureCollectionExtensions.Get<TFeature>(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
    
        Retrieves the requested feature from the collection.
    
        
        
        
        :param features: The collection.
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
        :rtype: {TFeature}
        :return: The requested feature, or null if it is not present.
    
        
        .. code-block:: csharp
    
           public static TFeature Get<TFeature>(IFeatureCollection features)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.FeatureCollectionExtensions.Set<TFeature>(Microsoft.AspNet.Http.Features.IFeatureCollection, TFeature)
    
        
    
        Sets the given feature in the collection.
    
        
        
        
        :param features: The collection.
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
        
        
        :param instance: The feature value.
        
        :type instance: {TFeature}
    
        
        .. code-block:: csharp
    
           public static void Set<TFeature>(IFeatureCollection features, TFeature instance)
    

