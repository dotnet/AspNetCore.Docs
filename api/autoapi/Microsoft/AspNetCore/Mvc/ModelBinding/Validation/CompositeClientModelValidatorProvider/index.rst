

CompositeClientModelValidatorProvider Class
===========================================






Aggregate of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`\s that delegates to its underlying providers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider`








Syntax
------

.. code-block:: csharp

    public class CompositeClientModelValidatorProvider : IClientModelValidatorProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider.CompositeClientModelValidatorProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider`\.
    
        
    
        
        :param providers: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` instances.
        
        :type providers: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider>}
    
        
        .. code-block:: csharp
    
            public CompositeClientModelValidatorProvider(IEnumerable<IClientModelValidatorProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateValidators(ClientValidatorProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider.ValidatorProviders
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` instances.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IClientModelValidatorProvider> ValidatorProviders { get; }
    

