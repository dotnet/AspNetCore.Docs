

ValidationMetadataProviderContext Class
=======================================






A context for an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext`








Syntax
------

.. code-block:: csharp

    public class ValidationMetadataProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.Attributes
    
        
    
        
        Gets the attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.Key
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
            public ModelMetadataIdentity Key
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.PropertyAttributes
    
        
    
        
        Gets the property attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> PropertyAttributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.TypeAttributes
    
        
    
        
        Gets the type attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> TypeAttributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.ValidationMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata
    
        
        .. code-block:: csharp
    
            public ValidationMetadata ValidationMetadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.ValidationMetadataProviderContext(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity, Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext`\.
    
        
    
        
        :param key: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type key: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        :param attributes: The attributes for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type attributes: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
            public ValidationMetadataProviderContext(ModelMetadataIdentity key, ModelAttributes attributes)
    

