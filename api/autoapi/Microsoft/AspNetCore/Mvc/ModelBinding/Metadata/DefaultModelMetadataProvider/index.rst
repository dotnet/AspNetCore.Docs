

DefaultModelMetadataProvider Class
==================================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` based on reflection.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultModelMetadataProvider : IModelMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.DefaultModelMetadataProvider(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider`\.
    
        
    
        
        :param detailsProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`\.
        
        :type detailsProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider
    
        
        .. code-block:: csharp
    
            public DefaultModelMetadataProvider(ICompositeMetadataDetailsProvider detailsProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.CreateModelMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` from a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails`\.
    
        
    
        
        :param entry: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails` entry with cached data.
        
        :type entry: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :return: A new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` instance.
    
        
        .. code-block:: csharp
    
            protected virtual ModelMetadata CreateModelMetadata(DefaultMetadataDetails entry)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.CreatePropertyDetails(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity)
    
        
    
        
        Creates the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails` entries for the properties of a model 
        :any:`System.Type`\.
    
        
    
        
        :param key: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` identifying the model :any:`System.Type`\.
        
        :type key: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails<Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails>[]
        :return: A details object for each property of the model :any:`System.Type`\.
    
        
        .. code-block:: csharp
    
            protected virtual DefaultMetadataDetails[] CreatePropertyDetails(ModelMetadataIdentity key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.CreateTypeDetails(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity)
    
        
    
        
        Creates the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails` entry for a model :any:`System.Type`\.
    
        
    
        
        :param key: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` identifying the model :any:`System.Type`\.
        
        :type key: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
        :return: A details object for the model :any:`System.Type`\.
    
        
        .. code-block:: csharp
    
            protected virtual DefaultMetadataDetails CreateTypeDetails(ModelMetadataIdentity key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.GetMetadataForProperties(System.Type)
    
        
    
        
        :type modelType: System.Type
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<ModelMetadata> GetMetadataForProperties(Type modelType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.GetMetadataForType(System.Type)
    
        
    
        
        :type modelType: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public virtual ModelMetadata GetMetadataForType(Type modelType)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider.DetailsProvider
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider
    
        
        .. code-block:: csharp
    
            protected ICompositeMetadataDetailsProvider DetailsProvider { get; }
    

