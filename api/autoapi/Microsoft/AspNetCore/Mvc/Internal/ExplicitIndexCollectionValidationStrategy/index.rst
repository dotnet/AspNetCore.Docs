

ExplicitIndexCollectionValidationStrategy Class
===============================================






An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy` for a collection bound using 'explict indexing'
style keys.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy`








Syntax
------

.. code-block:: csharp

    public class ExplicitIndexCollectionValidationStrategy : IValidationStrategy








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy.ExplicitIndexCollectionValidationStrategy(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy`\.
    
        
    
        
        :param elementKeys: The keys of collection elements that were used during model binding.
        
        :type elementKeys: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ExplicitIndexCollectionValidationStrategy(IEnumerable<string> elementKeys)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy.ElementKeys
    
        
    
        
        Gets the keys of collection elements that were used during model binding.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> ElementKeys { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ExplicitIndexCollectionValidationStrategy.GetChildren(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type key: System.String
    
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

