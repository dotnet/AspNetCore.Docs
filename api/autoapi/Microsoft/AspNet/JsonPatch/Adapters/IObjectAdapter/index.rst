

IObjectAdapter Interface
========================



.. contents:: 
   :local:



Summary
-------

Defines the operations that can be performed on a JSON patch document.











Syntax
------

.. code-block:: csharp

   public interface IObjectAdapter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Adapters/IObjectAdapter.cs>`_





.. dn:interface:: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter

Methods
-------

.. dn:interface:: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter.Add(Microsoft.AspNet.JsonPatch.Operations.Operation, System.Object)
    
        
        
        
        :type operation: Microsoft.AspNet.JsonPatch.Operations.Operation
        
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
           void Add(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter.Copy(Microsoft.AspNet.JsonPatch.Operations.Operation, System.Object)
    
        
        
        
        :type operation: Microsoft.AspNet.JsonPatch.Operations.Operation
        
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
           void Copy(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter.Move(Microsoft.AspNet.JsonPatch.Operations.Operation, System.Object)
    
        
        
        
        :type operation: Microsoft.AspNet.JsonPatch.Operations.Operation
        
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
           void Move(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter.Remove(Microsoft.AspNet.JsonPatch.Operations.Operation, System.Object)
    
        
        
        
        :type operation: Microsoft.AspNet.JsonPatch.Operations.Operation
        
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
           void Remove(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter.Replace(Microsoft.AspNet.JsonPatch.Operations.Operation, System.Object)
    
        
        
        
        :type operation: Microsoft.AspNet.JsonPatch.Operations.Operation
        
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
           void Replace(Operation operation, object objectToApplyTo)
    

