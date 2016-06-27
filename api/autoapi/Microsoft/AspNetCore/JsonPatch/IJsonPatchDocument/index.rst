

IJsonPatchDocument Interface
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IJsonPatchDocument








.. dn:interface:: Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument.ContractResolver
    
        
        :rtype: Newtonsoft.Json.Serialization.IContractResolver
    
        
        .. code-block:: csharp
    
            IContractResolver ContractResolver { get; set; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument.GetOperations()
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.JsonPatch.Operations.Operation<Microsoft.AspNetCore.JsonPatch.Operations.Operation>}
    
        
        .. code-block:: csharp
    
            IList<Operation> GetOperations()
    

