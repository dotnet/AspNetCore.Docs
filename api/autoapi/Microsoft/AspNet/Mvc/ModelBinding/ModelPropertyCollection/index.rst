

ModelPropertyCollection Class
=============================



.. contents:: 
   :local:



Summary
-------

A read-only collection of :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` objects which represent model properties.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection`








Syntax
------

.. code-block:: csharp

   public class ModelPropertyCollection : ReadOnlyCollection<ModelMetadata>, IList<ModelMetadata>, ICollection<ModelMetadata>, IList, ICollection, IReadOnlyList<ModelMetadata>, IReadOnlyCollection<ModelMetadata>, IEnumerable<ModelMetadata>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelPropertyCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection.ModelPropertyCollection(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection`\.
    
        
        
        
        :param properties: The properties.
        
        :type properties: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata}
    
        
        .. code-block:: csharp
    
           public ModelPropertyCollection(IEnumerable<ModelMetadata> properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection.Item[System.String]
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` instance for the property corresponding to ``propertyName``.
    
        
        
        
        :param propertyName: The property name. Property names are compared using .
        
        :type propertyName: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        :return: The <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata" /> instance for the property specified by <paramref name="propertyName" />, or
            <c>null</c> if no match can be found.
    
        
        .. code-block:: csharp
    
           public ModelMetadata this[string propertyName] { get; }
    

