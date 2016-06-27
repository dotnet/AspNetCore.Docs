

ModelPropertyCollection Class
=============================






A read-only collection of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` objects which represent model properties.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection`








Syntax
------

.. code-block:: csharp

    public class ModelPropertyCollection : ReadOnlyCollection<ModelMetadata>, IList<ModelMetadata>, ICollection<ModelMetadata>, IList, ICollection, IReadOnlyList<ModelMetadata>, IReadOnlyCollection<ModelMetadata>, IEnumerable<ModelMetadata>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection.ModelPropertyCollection(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection`\.
    
        
    
        
        :param properties: The properties.
        
        :type properties: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>}
    
        
        .. code-block:: csharp
    
            public ModelPropertyCollection(IEnumerable<ModelMetadata> properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection.Item[System.String]
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` instance for the property corresponding to <em>propertyName</em>.
    
        
    
        
        :param propertyName: 
            The property name. Property names are compared using :dn:field:`System.StringComparison.Ordinal`\.
        
        :type propertyName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :return: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` instance for the property specified by <em>propertyName</em>, or
            <code>null</code> if no match can be found.
    
        
        .. code-block:: csharp
    
            public ModelMetadata this[string propertyName] { get; }
    

