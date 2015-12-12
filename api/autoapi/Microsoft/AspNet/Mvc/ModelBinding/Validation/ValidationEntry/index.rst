

ValidationEntry Struct
======================



.. contents:: 
   :local:



Summary
-------

Contains data needed for validating a child entry of a model object. See :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy`\.











Syntax
------

.. code-block:: csharp

   public struct ValidationEntry





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ValidationEntry.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry.ValidationEntry(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry`\.
    
        
        
        
        :param metadata: The  associated with .
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param key: The model prefix associated with .
        
        :type key: System.String
        
        
        :param model: The model object.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
           public ValidationEntry(ModelMetadata metadata, string key, object model)
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry.Key
    
        
    
        The model prefix associated with :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry.Model`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry.Metadata
    
        
    
        The :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` associated with :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry.Model`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata Metadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry.Model
    
        
    
        The model object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; }
    

