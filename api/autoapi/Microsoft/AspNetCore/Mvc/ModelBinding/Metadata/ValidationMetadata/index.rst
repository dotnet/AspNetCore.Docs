

ValidationMetadata Class
========================






Validation metadata details for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata`








Syntax
------

.. code-block:: csharp

    public class ValidationMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata.IsRequired
    
        
    
        
        Gets or sets a value indicating whether or not the model is a required value. Will be ignored
        if the model metadata being created is not a property. If <code>null</code> then 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsRequired` will be computed based on the model :any:`System.Type`\.
        See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsRequired`\.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public bool ? IsRequired { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata.ValidateChildren
    
        
    
        
        Gets or sets a value that indicates whether children of the model should be validated. If <code>null</code>
        then :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ValidateChildren` will be <code>true</code> if either of 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsComplexType` or :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsEnumerableType` is <code>true</code>;
        <code>false</code> otherwise.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public bool ? ValidateChildren { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata.ValidatorMetadata
    
        
    
        
        Gets a list of metadata items for validators.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IList<object> ValidatorMetadata { get; }
    

