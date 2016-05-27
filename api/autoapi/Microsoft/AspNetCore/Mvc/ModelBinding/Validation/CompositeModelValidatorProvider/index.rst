

CompositeModelValidatorProvider Class
=====================================






Aggregate of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider`\s that delegates to its underlying providers.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider`








Syntax
------

.. code-block:: csharp

    public class CompositeModelValidatorProvider : IModelValidatorProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider.ValidatorProviders
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider` instances.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IModelValidatorProvider> ValidatorProviders
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider.CompositeModelValidatorProvider(System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider`\.
    
        
    
        
        :param providers: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider` instances.
        
        :type providers: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>}
    
        
        .. code-block:: csharp
    
            public CompositeModelValidatorProvider(IList<IModelValidatorProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateValidators(ModelValidatorProviderContext context)
    

