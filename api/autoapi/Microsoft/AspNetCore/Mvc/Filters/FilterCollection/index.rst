

FilterCollection Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.FilterCollection`








Syntax
------

.. code-block:: csharp

    public class FilterCollection : Collection<IFilterMetadata>, IList<IFilterMetadata>, ICollection<IFilterMetadata>, IList, ICollection, IReadOnlyList<IFilterMetadata>, IReadOnlyCollection<IFilterMetadata>, IEnumerable<IFilterMetadata>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterCollection

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.FilterCollection.Add(System.Type)
    
        
    
        
        Adds a type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
    
        
    
        
        :param filterType: Type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
        
        :type filterType: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
        :return: An :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` representing the added type.
    
        
        .. code-block:: csharp
    
            public IFilterMetadata Add(Type filterType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.FilterCollection.Add(System.Type, System.Int32)
    
        
    
        
        Adds a type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
    
        
    
        
        :param filterType: Type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
        
        :type filterType: System.Type
    
        
        :param order: The order of the added filter.
        
        :type order: System.Int32
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
        :return: An :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` representing the added type.
    
        
        .. code-block:: csharp
    
            public IFilterMetadata Add(Type filterType, int order)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.FilterCollection.AddService(System.Type)
    
        
    
        
        Adds a type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
    
        
    
        
        :param filterType: Type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
        
        :type filterType: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
        :return: An :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` representing the added service type.
    
        
        .. code-block:: csharp
    
            public IFilterMetadata AddService(Type filterType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.FilterCollection.AddService(System.Type, System.Int32)
    
        
    
        
        Adds a type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
    
        
    
        
        :param filterType: Type representing an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
        
        :type filterType: System.Type
    
        
        :param order: The order of the added filter.
        
        :type order: System.Int32
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
        :return: An :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` representing the added service type.
    
        
        .. code-block:: csharp
    
            public IFilterMetadata AddService(Type filterType, int order)
    

