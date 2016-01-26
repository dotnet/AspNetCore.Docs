

CompositeClientModelValidatorProvider Class
===========================================



.. contents:: 
   :local:



Summary
-------

Aggregate of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`\s that delegates to its underlying providers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider`








Syntax
------

.. code-block:: csharp

   public class CompositeClientModelValidatorProvider : IClientModelValidatorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/CompositeClientModelValidatorProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider.CompositeClientModelValidatorProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider`\.
    
        
        
        
        :param providers: A collection of  instances.
        
        :type providers: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider}
    
        
        .. code-block:: csharp
    
           public CompositeClientModelValidatorProvider(IEnumerable<IClientModelValidatorProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    
        
        .. code-block:: csharp
    
           public void GetValidators(ClientValidatorProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider.ValidatorProviders
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` instances.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<IClientModelValidatorProvider> ValidatorProviders { get; }
    

