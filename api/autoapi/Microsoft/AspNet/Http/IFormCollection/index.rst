

IFormCollection Interface
=========================



.. contents:: 
   :local:



Summary
-------

Contains the parsed form values.











Syntax
------

.. code-block:: csharp

   public interface IFormCollection : IReadableStringCollection, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/IFormCollection.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.IFormCollection

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.IFormCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.IFormCollection.Files
    
        
        :rtype: Microsoft.AspNet.Http.IFormFileCollection
    
        
        .. code-block:: csharp
    
           IFormFileCollection Files { get; }
    

