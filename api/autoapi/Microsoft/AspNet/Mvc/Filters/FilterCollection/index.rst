

FilterCollection Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterCollection`








Syntax
------

.. code-block:: csharp

   public class FilterCollection : Collection<IFilterMetadata>, IList<IFilterMetadata>, ICollection<IFilterMetadata>, IList, ICollection, IReadOnlyList<IFilterMetadata>, IReadOnlyCollection<IFilterMetadata>, IEnumerable<IFilterMetadata>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Filters/FilterCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterCollection

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.FilterCollection.Add(System.Type)
    
        
    
        Adds a type representing an :any:`Microsoft.AspNet.Mvc.Filters.IFilterMetadata`\.
    
        
        
        
        :param filterType: Type representing an .
        
        :type filterType: System.Type
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Filters.IFilterMetadata" /> representing the added type.
    
        
        .. code-block:: csharp
    
           public IFilterMetadata Add(Type filterType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.FilterCollection.Add(System.Type, System.Int32)
    
        
    
        Adds a type representing an :any:`Microsoft.AspNet.Mvc.Filters.IFilterMetadata`\.
    
        
        
        
        :param filterType: Type representing an .
        
        :type filterType: System.Type
        
        
        :param order: The order of the added filter.
        
        :type order: System.Int32
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Filters.IFilterMetadata" /> representing the added type.
    
        
        .. code-block:: csharp
    
           public IFilterMetadata Add(Type filterType, int order)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.FilterCollection.AddService(System.Type)
    
        
    
        Adds a type representing an :any:`Microsoft.AspNet.Mvc.Filters.IFilterMetadata`\.
    
        
        
        
        :param filterType: Type representing an .
        
        :type filterType: System.Type
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Filters.IFilterMetadata" /> representing the added service type.
    
        
        .. code-block:: csharp
    
           public IFilterMetadata AddService(Type filterType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.FilterCollection.AddService(System.Type, System.Int32)
    
        
    
        Adds a type representing an :any:`Microsoft.AspNet.Mvc.Filters.IFilterMetadata`\.
    
        
        
        
        :param filterType: Type representing an .
        
        :type filterType: System.Type
        
        
        :param order: The order of the added filter.
        
        :type order: System.Int32
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Filters.IFilterMetadata" /> representing the added service type.
    
        
        .. code-block:: csharp
    
           public IFilterMetadata AddService(Type filterType, int order)
    

