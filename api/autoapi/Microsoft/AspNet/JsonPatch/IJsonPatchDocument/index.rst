

IJsonPatchDocument Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IJsonPatchDocument





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/IJsonPatchDocument.cs>`_





.. dn:interface:: Microsoft.AspNet.JsonPatch.IJsonPatchDocument

Methods
-------

.. dn:interface:: Microsoft.AspNet.JsonPatch.IJsonPatchDocument
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.JsonPatch.IJsonPatchDocument.GetOperations()
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.JsonPatch.Operations.Operation}
    
        
        .. code-block:: csharp
    
           IList<Operation> GetOperations()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.JsonPatch.IJsonPatchDocument
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.JsonPatch.IJsonPatchDocument.ContractResolver
    
        
        :rtype: Newtonsoft.Json.Serialization.IContractResolver
    
        
        .. code-block:: csharp
    
           IContractResolver ContractResolver { get; set; }
    

