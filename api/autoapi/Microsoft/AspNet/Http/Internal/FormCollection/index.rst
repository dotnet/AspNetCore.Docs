

FormCollection Class
====================



.. contents:: 
   :local:



Summary
-------

Contains the parsed form values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.ReadableStringCollection`
* :dn:cls:`Microsoft.AspNet.Http.Internal.FormCollection`








Syntax
------

.. code-block:: csharp

   public class FormCollection : ReadableStringCollection, IFormCollection, IReadableStringCollection, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/FormCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.FormCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.FormCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.FormCollection.FormCollection(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
        
        
        :type store: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public FormCollection(IDictionary<string, StringValues> store)
    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.FormCollection.FormCollection(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>, Microsoft.AspNet.Http.IFormFileCollection)
    
        
        
        
        :type store: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
        
        
        :type files: Microsoft.AspNet.Http.IFormFileCollection
    
        
        .. code-block:: csharp
    
           public FormCollection(IDictionary<string, StringValues> store, IFormFileCollection files)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.FormCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.FormCollection.Files
    
        
        :rtype: Microsoft.AspNet.Http.IFormFileCollection
    
        
        .. code-block:: csharp
    
           public IFormFileCollection Files { get; }
    

