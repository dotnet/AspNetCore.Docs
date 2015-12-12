

FormFileCollection Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.Generic.List{Microsoft.AspNet.Http.IFormFile}`
* :dn:cls:`Microsoft.AspNet.Http.Internal.FormFileCollection`








Syntax
------

.. code-block:: csharp

   public class FormFileCollection : List<IFormFile>, IList<IFormFile>, ICollection<IFormFile>, IList, ICollection, IFormFileCollection, IReadOnlyList<IFormFile>, IReadOnlyCollection<IFormFile>, IEnumerable<IFormFile>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/FormFileCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.FormFileCollection

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.FormFileCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.FormFileCollection.GetFile(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Http.IFormFile
    
        
        .. code-block:: csharp
    
           public IFormFile GetFile(string name)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.FormFileCollection.GetFiles(System.String)
    
        
        
        
        :type name: System.String
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Http.IFormFile}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<IFormFile> GetFiles(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.FormFileCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.FormFileCollection.Item[System.String]
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Http.IFormFile
    
        
        .. code-block:: csharp
    
           public IFormFile this[string name] { get; }
    

