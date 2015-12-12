

IFormFileCollection Interface
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IFormFileCollection : IReadOnlyList<IFormFile>, IReadOnlyCollection<IFormFile>, IEnumerable<IFormFile>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/IFormFileCollection.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.IFormFileCollection

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.IFormFileCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.IFormFileCollection.GetFile(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Http.IFormFile
    
        
        .. code-block:: csharp
    
           IFormFile GetFile(string name)
    
    .. dn:method:: Microsoft.AspNet.Http.IFormFileCollection.GetFiles(System.String)
    
        
        
        
        :type name: System.String
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Http.IFormFile}
    
        
        .. code-block:: csharp
    
           IReadOnlyList<IFormFile> GetFiles(string name)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.IFormFileCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.IFormFileCollection.Item[System.String]
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Http.IFormFile
    
        
        .. code-block:: csharp
    
           IFormFile this[string name] { get; }
    

