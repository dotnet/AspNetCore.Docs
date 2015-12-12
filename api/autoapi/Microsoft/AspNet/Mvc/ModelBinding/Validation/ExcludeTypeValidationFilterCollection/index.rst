

ExcludeTypeValidationFilterCollection Class
===========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ExcludeTypeValidationFilterCollection`








Syntax
------

.. code-block:: csharp

   public class ExcludeTypeValidationFilterCollection : Collection<IExcludeTypeValidationFilter>, IList<IExcludeTypeValidationFilter>, ICollection<IExcludeTypeValidationFilter>, IList, ICollection, IReadOnlyList<IExcludeTypeValidationFilter>, IReadOnlyCollection<IExcludeTypeValidationFilter>, IEnumerable<IExcludeTypeValidationFilter>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/ExcludeTypeValidationFilterCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExcludeTypeValidationFilterCollection

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExcludeTypeValidationFilterCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExcludeTypeValidationFilterCollection.Add(System.String)
    
        
    
        Adds an :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter` that excludes the properties of
        the :any:`System.Type` specified and its derived types from validaton.
    
        
        
        
        :param typeFullName: Full name of the type which should be excluded from validation.
        
        :type typeFullName: System.String
    
        
        .. code-block:: csharp
    
           public void Add(string typeFullName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExcludeTypeValidationFilterCollection.Add(System.Type)
    
        
    
        Adds an :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter` that excludes the properties of
        the :any:`System.Type` specified and its derived types from validaton.
    
        
        
        
        :param type: which should be excluded from validation.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
           public void Add(Type type)
    

