

ModelErrorCollection Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{Microsoft.AspNet.Mvc.ModelBinding.ModelError}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelErrorCollection`








Syntax
------

.. code-block:: csharp

   public class ModelErrorCollection : Collection<ModelError>, IList<ModelError>, ICollection<ModelError>, IList, ICollection, IReadOnlyList<ModelError>, IReadOnlyCollection<ModelError>, IEnumerable<ModelError>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelErrorCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelErrorCollection

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelErrorCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelErrorCollection.Add(System.Exception)
    
        
        
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
           public void Add(Exception exception)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelErrorCollection.Add(System.String)
    
        
        
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public void Add(string errorMessage)
    

