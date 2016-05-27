

FormatterCollection<TFormatter> Class
=====================================






Represents a collection of formatters.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{{TFormatter}}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection\<TFormatter>`








Syntax
------

.. code-block:: csharp

    public class FormatterCollection<TFormatter> : Collection<TFormatter>, IList<TFormatter>, ICollection<TFormatter>, IList, ICollection, IReadOnlyList<TFormatter>, IReadOnlyCollection<TFormatter>, IEnumerable<TFormatter>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<TFormatter>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<TFormatter>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<TFormatter>.FormatterCollection()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection\`1` class that is empty.
    
        
    
        
        .. code-block:: csharp
    
            public FormatterCollection()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<TFormatter>.FormatterCollection(System.Collections.Generic.IList<TFormatter>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection\`1` class
        as a wrapper for the specified list.
    
        
    
        
        :param list: The list that is wrapped by the new collection.
        
        :type list: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TFormatter}
    
        
        .. code-block:: csharp
    
            public FormatterCollection(IList<TFormatter> list)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<TFormatter>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<TFormatter>.RemoveType<T>()
    
        
    
        
        Removes all formatters of the specified type.
    
        
    
        
        .. code-block:: csharp
    
            public void RemoveType<T>()where T : TFormatter
    

