

ValidationEntry Struct
======================






Contains data needed for validating a child entry of a model object. See :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct ValidationEntry








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry.Key
    
        
    
        
        The model prefix associated with :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry.Model`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Key
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry.Metadata
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry.Model`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata Metadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry.Model
    
        
    
        
        The model object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Model
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry.ValidationEntry(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry`\.
    
        
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with <em>model</em>.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param key: The model prefix associated with <em>model</em>.
        
        :type key: System.String
    
        
        :param model: The model object.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            public ValidationEntry(ModelMetadata metadata, string key, object model)
    

