

CompositeModelValidatorProvider Class
=====================================



.. contents:: 
   :local:



Summary
-------

Aggregate of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider`\s that delegates to its underlying providers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider`








Syntax
------

.. code-block:: csharp

   public class CompositeModelValidatorProvider : IModelValidatorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/CompositeModelValidatorProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider.CompositeModelValidatorProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider`\.
    
        
        
        
        :param providers: A collection of  instances.
        
        :type providers: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider}
    
        
        .. code-block:: csharp
    
           public CompositeModelValidatorProvider(IEnumerable<IModelValidatorProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    
        
        .. code-block:: csharp
    
           public void GetValidators(ModelValidatorProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider.ValidatorProviders
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider` instances.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<IModelValidatorProvider> ValidatorProviders { get; }
    

