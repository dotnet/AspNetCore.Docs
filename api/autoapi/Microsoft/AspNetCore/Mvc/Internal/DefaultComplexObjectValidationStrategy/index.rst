

DefaultComplexObjectValidationStrategy Class
============================================






The default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy` for a complex object.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy`








Syntax
------

.. code-block:: csharp

    public class DefaultComplexObjectValidationStrategy : IValidationStrategy








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy.GetChildren(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type key: System.String
    
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy.Instance
    
        
    
        
        Gets an instance of :any:`Microsoft.AspNetCore.Mvc.Internal.DefaultComplexObjectValidationStrategy`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy
    
        
        .. code-block:: csharp
    
            public static readonly IValidationStrategy Instance
    

