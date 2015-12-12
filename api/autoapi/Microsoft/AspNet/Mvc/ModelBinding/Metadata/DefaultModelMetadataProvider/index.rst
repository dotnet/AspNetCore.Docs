

DefaultModelMetadataProvider Class
==================================



.. contents:: 
   :local:



Summary
-------

A default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider` based on reflection.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultModelMetadataProvider : IModelMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/DefaultModelMetadataProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.DefaultModelMetadataProvider(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider`\.
    
        
        
        
        :param detailsProvider: The .
        
        :type detailsProvider: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider
    
        
        .. code-block:: csharp
    
           public DefaultModelMetadataProvider(ICompositeMetadataDetailsProvider detailsProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.CreateModelMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` from a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails`\.
    
        
        
        
        :param entry: The  entry with cached data.
        
        :type entry: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        :return: A new <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata" /> instance.
    
        
        .. code-block:: csharp
    
           protected virtual ModelMetadata CreateModelMetadata(DefaultMetadataDetails entry)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.CreatePropertyDetails(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity)
    
        
    
        Creates the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails` entries for the properties of a model 
        :any:`System.Type`\.
    
        
        
        
        :param key: The  identifying the model .
        
        :type key: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails[]
        :return: A details object for each property of the model <see cref="T:System.Type" />.
    
        
        .. code-block:: csharp
    
           protected virtual DefaultMetadataDetails[] CreatePropertyDetails(ModelMetadataIdentity key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.CreateTypeDetails(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity)
    
        
    
        Creates the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails` entry for a model :any:`System.Type`\.
    
        
        
        
        :param key: The  identifying the model .
        
        :type key: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
        :return: A details object for the model <see cref="T:System.Type" />.
    
        
        .. code-block:: csharp
    
           protected virtual DefaultMetadataDetails CreateTypeDetails(ModelMetadataIdentity key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.GetMetadataForProperties(System.Type)
    
        
        
        
        :type modelType: System.Type
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<ModelMetadata> GetMetadataForProperties(Type modelType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.GetMetadataForType(System.Type)
    
        
        
        
        :type modelType: System.Type
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public virtual ModelMetadata GetMetadataForType(Type modelType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.DetailsProvider
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider
    
        
        .. code-block:: csharp
    
           protected ICompositeMetadataDetailsProvider DetailsProvider { get; }
    

