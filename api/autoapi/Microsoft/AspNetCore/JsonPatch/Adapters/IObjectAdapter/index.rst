

IObjectAdapter Interface
========================






Defines the operations that can be performed on a JSON patch document.


Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch.Adapters`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IObjectAdapter








.. dn:interface:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter.Add(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            void Add(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter.Copy(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            void Copy(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter.Move(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            void Move(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter.Remove(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            void Remove(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter.Replace(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            void Replace(Operation operation, object objectToApplyTo)
    

