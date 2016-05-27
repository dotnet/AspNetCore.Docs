

ValidatorCache Class
====================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ValidatorCache`








Syntax
------

.. code-block:: csharp

    public class ValidatorCache








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ValidatorCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ValidatorCache

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ValidatorCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ValidatorCache.GetValidators(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider)
    
        
    
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type validatorProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IModelValidator> GetValidators(ModelMetadata metadata, IModelValidatorProvider validatorProvider)
    

