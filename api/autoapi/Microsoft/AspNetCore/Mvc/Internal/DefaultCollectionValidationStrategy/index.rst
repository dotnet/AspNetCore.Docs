

DefaultCollectionValidationStrategy Class
=========================================






The default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy` for a collection.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy`








Syntax
------

.. code-block:: csharp

    public class DefaultCollectionValidationStrategy : IValidationStrategy








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy.GetChildren(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type key: System.String
    
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy.GetEnumeratorForElementType(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Object)
    
        
    
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type model: System.Object
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            public static IEnumerator GetEnumeratorForElementType(ModelMetadata metadata, object model)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy.Instance
    
        
    
        
        Gets an instance of :any:`Microsoft.AspNetCore.Mvc.Internal.DefaultCollectionValidationStrategy`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy
    
        
        .. code-block:: csharp
    
            public static readonly IValidationStrategy Instance
    

