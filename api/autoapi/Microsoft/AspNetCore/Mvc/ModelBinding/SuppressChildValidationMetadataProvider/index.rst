

SuppressChildValidationMetadataProvider Class
=============================================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider` which configures :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ValidateChildren` to
<code>false</code> for matching types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider`








Syntax
------

.. code-block:: csharp

    public class SuppressChildValidationMetadataProvider : IValidationMetadataProvider, IMetadataDetailsProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.SuppressChildValidationMetadataProvider(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider` for the given <em>fullTypeName</em>.
    
        
    
        
        :param fullTypeName: 
            The type full name. This type and all of its subclasses will have 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ValidateChildren` set to <code>false</code>.
        
        :type fullTypeName: System.String
    
        
        .. code-block:: csharp
    
            public SuppressChildValidationMetadataProvider(string fullTypeName)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.SuppressChildValidationMetadataProvider(System.Type)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider` for the given <em>type</em>.
    
        
    
        
        :param type: 
            The :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.Type`\. This :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.Type` and all assignable values will have 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ValidateChildren` set to <code>false</code>.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public SuppressChildValidationMetadataProvider(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.CreateValidationMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateValidationMetadata(ValidationMetadataProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.FullTypeName
    
        
    
        
        Gets the full name of a type for which to suppress validation of children.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FullTypeName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.Type
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider.Type` for which to suppress validation of children.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type Type { get; }
    

