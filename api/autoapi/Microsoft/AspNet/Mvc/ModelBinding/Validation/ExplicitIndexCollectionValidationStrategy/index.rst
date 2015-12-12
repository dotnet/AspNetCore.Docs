

ExplicitIndexCollectionValidationStrategy Class
===============================================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy` for a collection bound using 'explict indexing'
style keys.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy`








Syntax
------

.. code-block:: csharp

   public class ExplicitIndexCollectionValidationStrategy : IValidationStrategy





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/ExplicitIndexCollectionValidationStrategy.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy.ExplicitIndexCollectionValidationStrategy(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy`\.
    
        
        
        
        :param elementKeys: The keys of collection elements that were used during model binding.
        
        :type elementKeys: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public ExplicitIndexCollectionValidationStrategy(IEnumerable<string> elementKeys)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy.GetChildren(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :type key: System.String
        
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator{Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry}
    
        
        .. code-block:: csharp
    
           public IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExplicitIndexCollectionValidationStrategy.ElementKeys
    
        
    
        Gets the keys of collection elements that were used during model binding.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> ElementKeys { get; }
    

