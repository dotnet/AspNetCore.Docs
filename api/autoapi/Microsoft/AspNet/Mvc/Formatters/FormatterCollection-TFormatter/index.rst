

FormatterCollection<TFormatter> Class
=====================================



.. contents:: 
   :local:



Summary
-------

Represents a collection of formatters.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{{TFormatter}}`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.FormatterCollection\<TFormatter>`








Syntax
------

.. code-block:: csharp

   public class FormatterCollection<TFormatter> : Collection<TFormatter>, IList<TFormatter>, ICollection<TFormatter>, IList, ICollection, IReadOnlyList<TFormatter>, IReadOnlyCollection<TFormatter>, IEnumerable<TFormatter>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Formatters/FormatterCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatterCollection<TFormatter>

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatterCollection<TFormatter>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatterCollection<TFormatter>.RemoveType<T>()
    
        
    
        Removes all formatters of the specified type.
    
        
    
        
        .. code-block:: csharp
    
           public void RemoveType<T>()where T : TFormatter
    

