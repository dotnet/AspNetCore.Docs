

IFormFileCollection Interface
=============================






Represents the collection of files sent with the HttpRequest.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFormFileCollection : IReadOnlyList<IFormFile>, IReadOnlyCollection<IFormFile>, IEnumerable<IFormFile>, IEnumerable








.. dn:interface:: Microsoft.AspNetCore.Http.IFormFileCollection
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IFormFileCollection

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.IFormFileCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.IFormFileCollection.GetFile(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Http.IFormFile
    
        
        .. code-block:: csharp
    
            IFormFile GetFile(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IFormFileCollection.GetFiles(System.String)
    
        
    
        
        :type name: System.String
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Http.IFormFile<Microsoft.AspNetCore.Http.IFormFile>}
    
        
        .. code-block:: csharp
    
            IReadOnlyList<IFormFile> GetFiles(string name)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.IFormFileCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormFileCollection.Item[System.String]
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Http.IFormFile
    
        
        .. code-block:: csharp
    
            IFormFile this[string name] { get; }
    

