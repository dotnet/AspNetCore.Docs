

ClientValidatorCache Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache`








Syntax
------

.. code-block:: csharp

    public class ClientValidatorCache








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache.GetValidators(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider)
    
        
    
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type validatorProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IClientModelValidator> GetValidators(ModelMetadata metadata, IClientModelValidatorProvider validatorProvider)
    

