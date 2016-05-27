

ModelErrorCollection Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{Microsoft.AspNetCore.Mvc.ModelBinding.ModelError}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection`








Syntax
------

.. code-block:: csharp

    public class ModelErrorCollection : Collection<ModelError>, IList<ModelError>, ICollection<ModelError>, IList, ICollection, IReadOnlyList<ModelError>, IReadOnlyCollection<ModelError>, IEnumerable<ModelError>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection.Add(System.Exception)
    
        
    
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
            public void Add(Exception exception)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection.Add(System.String)
    
        
    
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
            public void Add(string errorMessage)
    

