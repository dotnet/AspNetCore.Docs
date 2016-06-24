

FormFileCollection Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.Generic.List{Microsoft.AspNetCore.Http.IFormFile}`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.FormFileCollection`








Syntax
------

.. code-block:: csharp

    public class FormFileCollection : List<IFormFile>, IList<IFormFile>, ICollection<IFormFile>, IList, ICollection, IFormFileCollection, IReadOnlyList<IFormFile>, IReadOnlyCollection<IFormFile>, IEnumerable<IFormFile>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFileCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFileCollection

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFileCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.FormFileCollection.GetFile(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Http.IFormFile
    
        
        .. code-block:: csharp
    
            public IFormFile GetFile(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.FormFileCollection.GetFiles(System.String)
    
        
    
        
        :type name: System.String
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Http.IFormFile<Microsoft.AspNetCore.Http.IFormFile>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IFormFile> GetFiles(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFileCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.FormFileCollection.Item[System.String]
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Http.IFormFile
    
        
        .. code-block:: csharp
    
            public IFormFile this[string name] { get; }
    

